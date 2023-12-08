using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.BusinessLogic;
using ApahidaTheatherWeb.Models;

namespace ApahidaTheatherWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsAPIController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketsAPIController(TicketService ticketService)
        {

            _ticketService = ticketService;
        }

        [HttpGet("Get tickets by title")]
        public List<Ticket> Get(int playId)
        {

            return _ticketService.GetTicketsByPlay(playId).ToList();
        }

        [HttpGet("GetAllTickets")]
        public List<Ticket> Get()
        {
            return _ticketService.GetAllTickets().ToList();
        }

        [HttpDelete("DeleteTicket")]
        public async Task<IActionResult> Delete(int ticketId) {
            if (!_ticketService.Exists(ticketId)) return NotFound();
            await _ticketService.Delete(ticketId);
            return Ok();
        }

        [HttpPost("AddTicket")]
        public async Task<IActionResult> Add(int playId, int row, int number)
        {
            Ticket ticket = new Ticket(playId, row, number);
            if (_ticketService.Exists(ticket)) return NotFound();
            

            await _ticketService.Create(ticket);
            return Ok();
        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> Update(int ticketId, int playId, int row, int number) {
            if (!_ticketService.Exists(ticketId)) return NotFound();

            Ticket ticket = _ticketService.Get(ticketId).Result;
            ticket.PlayID = playId;
            ticket.Row = row;
            ticket.Number = number;
            await _ticketService.Update(ticket);
            return Ok();
        }
    }
}
