using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Repositories;
using ApahidaTheatherWeb.Models;

namespace ApahidaTheatherWeb.BusinessLogic
{
    public class TicketService
    {
        public readonly UnitOfWork _unitOfWork;
        public TicketService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ticket> Get(int id)
        {
            return await _unitOfWork.Tickets.Get(id);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _unitOfWork.Tickets.GetAll();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _unitOfWork.Tickets.GetAllTickets();
        }

        public IEnumerable<Ticket> GetTicketsByPlay(int playId)
        {
            return _unitOfWork.Tickets.GetTicketsByPlayId(playId);
        }

        public async Task Update(Ticket ticket)
        {
             _unitOfWork.Tickets.Update(ticket);
            await _unitOfWork.Complete();
        }

        public async void Delete(Ticket ticket)
        {
            Play play = _unitOfWork.Plays.GetPlay(ticket.PlayID);
            if (play != null)
            {
                play.NoTickets++;
                _unitOfWork.Plays.Update(play);
            }
            _unitOfWork.Tickets.Delete(ticket);
        }

        public async Task Delete(int ticketId)
        {
            Ticket ticket = _unitOfWork.Tickets.GetTicket(ticketId);
            Play play = _unitOfWork.Plays.GetPlay(ticket.PlayID);
            if (play != null)
            {
                play.NoTickets++;
                _unitOfWork.Plays.Update(play);
            }
            _unitOfWork.Tickets.Delete(ticket);
            await _unitOfWork.Complete();
        }
        public bool validTicket(Ticket ticket) {
            Play play = _unitOfWork.Plays.GetPlay(ticket.PlayID);
            Ticket ticket1 = _unitOfWork.Tickets.GetTicket(ticket.Row, ticket.Number, ticket.PlayID);
            if (play != null && ticket1 == null && play.NoTickets > 0)
            {
                return true;
            }

            return false;
        }

        public async Task Create(Ticket ticket)
        {
            Play play = _unitOfWork.Plays.GetPlay(ticket.PlayID);
            Ticket ticket1 = _unitOfWork.Tickets.GetTicket(ticket.Row, ticket.Number, ticket.PlayID);
            if (play != null && ticket1 == null && play.NoTickets > 0)
            {
                play.NoTickets--;
                _unitOfWork.Plays.Update(play);
                await _unitOfWork.Tickets.Add(ticket);
            }


            await _unitOfWork.Complete();
        }

        public async void UpdatePlay(Play play) {

            _unitOfWork.Plays.Update(play);
            await _unitOfWork.Complete();
        }
        public Play getPlay(Ticket ticket)
        {
            return (_unitOfWork.Plays.GetPlay(ticket.PlayID));
        }
        public Ticket GetTicket(Ticket ticket)
        {

            return (_unitOfWork.Tickets.GetTicket(ticket.Row, ticket.Number, ticket.PlayID));

        }

        public bool Exists(Ticket ticket)
        {
            if (_unitOfWork.Tickets.GetTicket(ticket.Row, ticket.Number, ticket.PlayID) != null) return true;
            return false;
        }

        public bool Exists(int ticketId)
        {
            if (_unitOfWork.Tickets.GetTicket(ticketId) != null) return true;
            return false;
        }
    }
}
