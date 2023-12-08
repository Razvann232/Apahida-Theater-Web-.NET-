using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApahidaTheatherWeb.Data;
using ApahidaTheatherWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using CsvHelper;
using System.IO;
using ApahidaTheatherWeb.BusinessLogic;

namespace ApahidaTheatherWeb.Controllers
{
   
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(await _ticketService.GetAll());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.Get((int)id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Row,Number,PlayID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // verificarea daca mai exista vre-un bilet exact la fel, daca mai sunt bilete disponibile
                // si scaderea din baza de date a numarului de bilete

                if (_ticketService.validTicket(ticket))
                {
                    await _ticketService.Create(ticket);
                    //await _ticketService._unitOfWork.Complete();
                    ViewBag.Message = "Ticket added successfully!";
                }
                else {
                    ViewBag.Message = "Error adding ticket (invalid play/no more tickets available)!";
                }
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.Get((int)id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Row,Number")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ticketService.Update(ticket);
                    //await _ticketService._unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_ticketService.Exists(ticket))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.Get((int)id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _ticketService.Get(id);
            _ticketService.Delete(ticket);
            await _ticketService._unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        public void Export(int exportID) {
            List<Ticket> ListTickets = _ticketService.GetAllTickets().ToList();

            ExportFactory exportFactory = new ExportFactory();
            IExporter exporter = exportFactory.GetExporter(exportID);

            exporter.Export(ListTickets, this.HttpContext);
        }
    }
}
