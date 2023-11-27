using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductWithClientDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public ExportClientDto[] Clients { get; set; }
    }

    public class ExportClientDto
    {
        public string Name { get; set; }
        public string NumberVat { get; set; }
    }
}
