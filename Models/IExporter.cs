using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ApahidaTheatherWeb.Models
{
    public interface IExporter
    {
        public StringBuilder Export(List<Ticket> tickets, HttpContext httpContext);
    }
}
