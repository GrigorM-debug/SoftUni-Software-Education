using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Linq;
using AutoMapper.QueryableExtensions;
using CarDealer.DTOs.Export;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //string output = ImportSales(context, inputXml);

            string xml = GetLocalSuppliers(context);


            Console.WriteLine(xml);

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDTO[] suppliersDTOs = xmlHelper.Deserialize<ImportSupplierDTO[]>(inputXml, "Suppliers");

            var validSuplliers = new HashSet<Supplier>();

            foreach (var supplierDTO in suppliersDTOs)
            {
                if (string.IsNullOrEmpty(supplierDTO.Name))
                {
                    continue;
                }

                var supplier = mapper.Map<Supplier>(supplierDTO);

                validSuplliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuplliers);

            context.SaveChanges();

            return $"Successfully imported {validSuplliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var partsDTOs = xmlHelper.Deserialize<ImportPartDTO[]>(inputXml, "Parts");

            var validParts = new HashSet<Part>();


            foreach (ImportPartDTO partDTO in partsDTOs)
            {
                if (string.IsNullOrEmpty(partDTO.Name))
                {
                    continue;
                }

                if (!context.Suppliers.Any(x=> x.Id == partDTO.SupplierId) || !partDTO.SupplierId.HasValue)
                {
                    continue;
                }

                var part = mapper.Map<Part>(partDTO);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);

            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var carsDTOs = xmlHelper.Deserialize<ImportCarDTO[]>(inputXml, "Cars");

            var validCars = new HashSet<Car>();

            foreach (var carDTO in carsDTOs)
            {
                if (string.IsNullOrEmpty(carDTO.Make) || string.IsNullOrEmpty(carDTO.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDTO);

                foreach (var partDTO in carDTO.Parts.DistinctBy(x => x.PartId))
                {
                    if (!context.Parts.Any(x => x.Id == partDTO.PartId))
                    {
                        continue;
                    }

                    PartCar partcar = new PartCar()
                    {
                        PartId = partDTO.PartId,
                    };

                    car.PartsCars.Add(partcar);

                }
                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);

            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var customersDTOs = xmlHelper.Deserialize<ImportCustomerDTO[]>(inputXml, "Customers");

            var validCustomers = new HashSet<Customer>();

            foreach (var customerDTO in customersDTOs)
            {
                if (string.IsNullOrEmpty(customerDTO.Name) || string.IsNullOrEmpty(customerDTO.BirthDate))
                {
                    continue;
                }

                var customer = mapper.Map<Customer>(customerDTO);

                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);

            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var salesDTOs = xmlHelper.Deserialize<ImportSalesDTO[]>(inputXml, "Sales");

            var validSales = new HashSet<Sale>();

            foreach (var saleDTO in salesDTOs)
            {
                if (!context.Cars.Any(x => x.Id == saleDTO.CarId))
                {
                    continue;
                }

                var sale = mapper.Map<Sale>(saleDTO);

                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);

            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        //TODO - Judge test with different imformation. The Query is correct
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = InitializeAutoMapper();

            var cars = context.Cars
                .Take(10)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Where(x => x.TraveledDistance > 2000000)
                .ProjectTo<ExportCarDTO>(mapper.ConfigurationProvider)
                .ToArray();
            
            var xmlOutput = xmlHelper.Serialize(cars, "cars");

            return xmlOutput;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = InitializeAutoMapper();

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBMWCarDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlOutput = xmlHelper.Serialize(cars, "cars");

            return xmlOutput;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplersDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlOutput = xmlHelper.Serialize(suppliers, "suppliers");

            return xmlOutput;   
        }
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}