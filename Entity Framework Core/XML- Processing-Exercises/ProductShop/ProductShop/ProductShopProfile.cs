using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUsersDTO, User>();

            CreateMap<ImportCategoriesDTO, Category>();

            CreateMap<ImportProductsDTO, Product>();

            CreateMap<ImportCategoryProductDTO, CategoryProduct>();
        }
    }
}
