using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            string output = ImportCars(context, inputXml);

            Console.WriteLine(output);
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

        //TODO
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

        //TODO - Delete the database and execute methods again. Mistakes happen.
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}