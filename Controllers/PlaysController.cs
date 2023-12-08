using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApahidaTheatherWeb.Data;
using ApahidaTheatherWeb.Models;
using ApahidaTheatherWeb.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

namespace ApahidaTheatherWeb.Controllers
{
    public class PlaysController : Controller
    {
        private readonly PlayService _playService;

        public PlaysController(PlayService playService)
        {
            _playService = playService;
        }

        // GET: Plays
        
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(await _playService.GetAll());
        }

        // GET: Plays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _playService.Get((int)id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // GET: Plays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Director,Actors,Premiere,NoTickets")] Play play)
        {

            if (ModelState.IsValid)
            {
                if (_playService.Exists(play))
                {
                    ViewBag.Message = "Play already exists!";
                }
                else
                {
                    _playService.Create(play);
                    await _playService._unitOfWork.Complete();
                    ViewBag.Message = "Play added successfully!";
                }
            }
            return View(play);
        }

        // GET: Plays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _playService.Get((int)id);
            if (play == null)
            {
                return NotFound();
            }
            return View(play);
        }

        // POST: Plays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,Actors,Premiere,NoTickets")] Play play)
        {
            if (id != play.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _playService.Update(play);
                    await _playService._unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_playService.Exists(play))
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
            return View(play);
        }

        // GET: Plays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _playService.Get((int)id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // POST: Plays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var play = await _playService.Get(id);
            _playService.Delete(play);
            await _playService._unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
