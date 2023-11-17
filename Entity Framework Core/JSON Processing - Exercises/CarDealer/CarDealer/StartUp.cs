using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(context, inputJson));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            var suppliersIds = context.Suppliers.Select(x => x.Id).ToArray();

            var validParts = parts.Where(p => suppliersIds.Contains(p.SupplierId)).ToArray();

            context.Parts.AddRange(validParts);

           context.SaveChanges();

            return $"Successfully imported {validParts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            MapperConfiguration configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(configuration);

            ImportCarDto[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            //Mapping the Cars from their DTOs
            ICollection<Car> carsToAdd = new HashSet<Car>();

            foreach (var carDto in importCarDtos)
            {
                Car currentCar = mapper.Map<Car>(carDto);

                foreach (var id in carDto.PartsId)
                {
                    if (context.Parts.Any(p=> p.Id == id))
                    {
                        currentCar.PartsCars.Add(new PartCar
                        {
                            PartId = id,
                        });
                    }
                }

                carsToAdd.Add(currentCar);
            }

            //Adding the Cars
            context.Cars.AddRange(carsToAdd);
            context.SaveChanges();

            //Output
            return $"Successfully imported {carsToAdd.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}