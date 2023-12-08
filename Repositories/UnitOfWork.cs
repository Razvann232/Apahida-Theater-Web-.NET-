using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Data;
using ApahidaTheatherWeb.Repositories;

namespace ApahidaTheatherWeb.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApahidaTheatherWebContext _context;
        public PlayRepository Plays { get; }
        public UserRepository Users { get; }
        public TicketRepository Tickets { get; }

        public UnitOfWork(ApahidaTheatherWebContext context,
            PlayRepository Plays, UserRepository Users, TicketRepository Tickets)
        {
            this._context = context;
            this.Plays = Plays;
            this.Users = Users;
            this.Tickets = Tickets;
        }
        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
