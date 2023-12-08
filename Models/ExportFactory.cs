using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApahidaTheatherWeb.Models
{
    public class ExportFactory
    {
        public IExporter GetExporter(int exporterID) {
            if (exporterID == 1) return new ExporterCSV();
            return new ExporterJSON();
        }
    }
}
