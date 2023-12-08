using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApahidaTheatherWeb.Models
{
    public class Play
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public DateTime Premiere { get; set; }
        
        [Display(Name = "Tickets Available")]
        public int NoTickets { get; set; }
    }
}
