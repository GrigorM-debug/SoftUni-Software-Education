using System.Globalization;
using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore.Design.Internal;

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

            CreateMap<Part, ExportCarPartDTO>();

            CreateMap<Car, ExportCarsWithParts>()
                .ForMember(x => x.Parts,y => y.MapFrom(x =>
                        x.PartsCars.OrderByDescending(x => x.Part.Price).Select(x => x.Part).ToArray()));


        }
    }
}
