using System.Globalization;
using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

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
        }
    }
}
