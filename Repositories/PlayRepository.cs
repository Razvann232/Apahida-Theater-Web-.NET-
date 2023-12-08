using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApahidaTheatherWeb.Models;
using ApahidaTheatherWeb.Data;

namespace ApahidaTheatherWeb.Repositories
{
    public class PlayRepository : GenericRepository<Play>
    {
        public PlayRepository(ApahidaTheatherWebContext context) : base(context)
        {

        }
        public Play GetPlay(int playId)
        {
            return _context.Play.FirstOrDefault(x => x.Id == playId);
        }
        public Play GetPlay(String title, String director, DateTime premiere)
        {
            return _context.Play.FirstOrDefault(x => x.Title == title && x.Title == director && x.Premiere == premiere);
        }
    }
}
