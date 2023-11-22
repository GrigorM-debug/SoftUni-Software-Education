using System.Globalization;
using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDTO, Supplier>();

            CreateMap<ImportPartDTO, Part>()
                .ForMember(x => x.SupplierId, y => y.MapFrom(s => s.SupplierId.Value));

            CreateMap<ImportCustomerDTO, Customer>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(x => DateTime.Parse(x.BirthDate, CultureInfo.InvariantCulture)));

            CreateMap<ImportCarDTO, Car>()
                .ForSourceMember(x => x.Parts, y => y.DoNotValidate());

            CreateMap<ImportCarPartDTO, PartCar>();

            CreateMap<ImportSalesDTO, Sale>();

            CreateMap<Car, ExportCarDTO>();

            CreateMap<Car, ExportBMWCarDTO>();

            CreateMap<Supplier, ExportSupplersDTO>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(x => x.Parts.Count));

            CreateMap<Customer, ExportCustomer>()
                .ForMember(x => x.FullName, y => y.MapFrom(f => f.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.SpentMoney,
                    y => y.MapFrom(
                        x => x.IsYoungDriver ? x.Sales.Sum(x=> x.Select(x => x.Car.PartsCars.Select(x => x.Part.Price))) - x.Sales.Select(x=> x.Discount) : x.Sales.Sum(x => x.Select(x => x.Car.PartsCars.Select(x => x.Part.Price)))));
        }
    }
}
