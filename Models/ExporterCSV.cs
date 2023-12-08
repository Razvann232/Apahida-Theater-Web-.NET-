using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CsvHelper;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ApahidaTheatherWeb.Models
{
    public class ExporterCSV : IExporter
    {
        public StringBuilder Export(List<Ticket> ListTickets, HttpContext httpContext) {
            File.Delete("file.csv");
            using (var writer = new StreamWriter("file.csv"))
            {
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(ListTickets);
                    csv.Flush();
                }
                writer.Close();
            }

            httpContext.Response.Clear();
            httpContext.Response.ContentType = "text/csv";
            httpContext.Response.Headers["content-disposition"] = "attachment;filename=Tickets.csv";
            httpContext.Response.SendFileAsync("file.csv");
            httpContext.Response.CompleteAsync();

            return null;
        }
    }
}
