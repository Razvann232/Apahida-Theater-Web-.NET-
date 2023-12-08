using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApahidaTheatherWeb.Data;
using ApahidaTheatherWeb.Models;
using CsvHelper;
using System.IO;
using ApahidaTheatherWeb.BusinessLogic;
using System.Web;

namespace ApahidaTheatherWeb.Models
{
    public class ExporterJSON : IExporter
    {
        public StringBuilder Export(List<Ticket> ListTickets, HttpContext httpContext) {
            StringBuilder sb = new StringBuilder();

            var CollectionWrapper = new
            {
                Tickets = ListTickets
            };

            sb.Append(JsonSerializer.Serialize(CollectionWrapper, new JsonSerializerOptions { WriteIndented = true }));

            httpContext.Response.Clear();
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.Headers["content-disposition"] = "attachment;filename=Tickets.json";

            httpContext.Response.WriteAsync(sb.ToString());
            httpContext.Response.CompleteAsync();

            
            return sb;
        }
    }
}
