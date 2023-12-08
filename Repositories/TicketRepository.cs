using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Models;
using ApahidaTheatherWeb.Data;

namespace ApahidaTheatherWeb.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository(ApahidaTheatherWebContext context) : base(context)
        {

        }
        public Ticket GetTicket(int row, int number, int playID)
        {
            return _context.Ticket.FirstOrDefault(x => x.Row == row && x.Number == number && x.PlayID == playID);
        }
        public Ticket GetTicket(int ticketId)
        {
            return _context.Ticket.FirstOrDefault(x => x.Id == ticketId);
        }
        public IEnumerable<Ticket> GetTicketsByPlayId(int playID)
        {
            return _context.Ticket.Where(x => x.PlayID == playID);
        }
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Ticket.ToList();
        }
    }
}
