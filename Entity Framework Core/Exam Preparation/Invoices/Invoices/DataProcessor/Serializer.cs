using System.Globalization;
using System.Text;
using Invoices.DataProcessor.ExportDto;
using Invoices.Extensions;

namespace Invoices.DataProcessor
{
    using Invoices.Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clientsWithInvoices = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientsWithTheirInvoicesDto()
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i=> i.IssueDate)
                        .ThenByDescending(i=> i.DueDate)
                        .Select(i => new ExportInvoicesInfo()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = i.Amount,
                            DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                            Currency = i.CurrencyType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return clientsWithInvoices.SerializeToXml<ExportClientsWithTheirInvoicesDto[]>("Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var productsWithClients = context.Products
                .Where(p => p.ProductsClients.Any(x => x.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductWithClientDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(x => new ExportClientDto()
                        {
                            Name = x.Client.Name,
                            NumberVat = x.Client.NumberVat,
                        })
                        .OrderBy(x=> x.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return productsWithClients.SerializeToJson<ExportProductWithClientDto[]>();


        }
    }
}