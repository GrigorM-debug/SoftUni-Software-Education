using System.Diagnostics.Tracing;
using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;
using FastFood.Core.ViewModels.Items;
using FastFood.Core.ViewModels.Orders;

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
            CreateMap<RegisterEmployeeInputModel, Employee>();
            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x=> x.Position, y=> y.MapFrom(e=> e.Position.Name));

            //Items
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(c => c.Id));

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x=> x.Category, y=> y.MapFrom(i=> i.Category.Name));


            //Orders
            CreateMap<CreateItemInputModel, Order>();
            CreateMap<Order, OrderAllViewModel>();
        }
    }
}
