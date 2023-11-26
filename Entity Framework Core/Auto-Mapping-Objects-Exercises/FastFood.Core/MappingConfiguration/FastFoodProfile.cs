using System.Diagnostics.Tracing;
using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;

namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(c => c.CategoryName));
            CreateMap<Category, CategoryAllViewModel>();

            //Employees
            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(p => p.Id));
            CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(p => p.Position.Name, x => x.MapFrom(e => e.PositionName));
            CreateMap<Employee, EmployeesAllViewModel>();
        }
    }
}
