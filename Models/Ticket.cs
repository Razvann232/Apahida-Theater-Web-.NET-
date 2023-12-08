using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApahidaTheatherWeb.Models
{
    
    
    public class Ticket
    {
        public int Id { get; set; }
        public int PlayID { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }

        public Ticket()
        {
        }

        public Ticket(int playID, int row, int number)
        {
            PlayID = playID;
            Row = row;
            Number = number;
        }

        public Ticket(int id, int playID, int row, int number)
        {
            Id = id;
            PlayID = playID;
            Row = row;
            Number = number;
        }
    }


}
