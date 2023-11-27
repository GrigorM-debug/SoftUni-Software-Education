using System.Text;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;
using Invoices.Extensions;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var clientsDtos = xmlString.DeserializeFromXml<ImportClientDto[]>("Clients");

            var validClients = new HashSet<Client>();

            foreach (var clientDto in clientsDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                };

                foreach (var clientAddress in clientDto.Addresses)
                {
                    if (!IsValid(clientAddress))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.Addresses.Add(new Address()
                    {
                        StreetName = clientAddress.StreetName,
                        StreetNumber = clientAddress.StreetNumber,
                        PostCode = clientAddress.PostCode,
                        City = clientAddress.City,
                        Country = clientAddress.Country
                    });
                }

                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(validClients);

            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var invoicesDtos = jsonString.DeserializeFromJson<ImportInvoicesDto[]>();

            var validInvoices = new HashSet<Invoice>();

            foreach (var invoiceDto in invoicesDtos)
            {
                if (!IsValid(invoiceDto) || invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                var invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId,
                };

                validInvoices.Add(invoice);

                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges(); 
            return sb.ToString();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var productsDtos = jsonString.DeserializeFromJson<ImportProductDto[]>();

            var validProducts = new HashSet<Product>();

            var clientIds = context.Clients.Select(x => x.Id).ToList();

            foreach (var productDto in productsDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType
                };

                foreach (var client in productDto.Clients.Distinct())
                {
                    if (!clientIds.Contains(client))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient()
                    {
                        ClientId = client
                    });
                }

                validProducts.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(validProducts);

            context.SaveChanges();

            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
