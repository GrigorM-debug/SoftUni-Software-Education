using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsWithTheirInvoicesDto
    {
        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }
        public string ClientName { get; set; }

        public string VatNumber { get; set; }

        [XmlArray("Invoices")]
        public ExportInvoicesInfo[] Invoices { get; set; }
    }

    [XmlType("Invoice")]
    public class ExportInvoicesInfo
    {
        public int InvoiceNumber { get; set; }

        public decimal InvoiceAmount { get; set; }

        public string DueDate { get; set; }

        public string Currency { get; set; }
    }
}
