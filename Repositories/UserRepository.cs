using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Models;
using ApahidaTheatherWeb.Data;

namespace ApahidaTheatherWeb.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ApahidaTheatherWebContext context) : base(context)
        {

        }
        public User GetUser(String username)
        {
            return _context.User.FirstOrDefault(x => x.Username == username);
        }
    }
}
