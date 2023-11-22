using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            //string ouput = ImportCategoryProducts(context, inputXml);

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var usersDTOs = xmlHelper.Deserialize<ImportUsersDTO[]>(inputXml, "Users");

            var users = mapper.Map<User[]>(usersDTOs);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var productsDTOs = xmlHelper.Deserialize<ImportProductsDTO[]>(inputXml, "Products");

            var products = mapper.Map<Product[]>(productsDTOs);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var categoriesDTOs = xmlHelper.Deserialize<ImportCategoriesDTO[]>(inputXml, "Categories");

            var validCategories = new HashSet<Category>();

            foreach (var categoryDTO in categoriesDTOs)
            {
                if (string.IsNullOrEmpty(categoryDTO.Name))
                {
                    continue;
                }

                var category = mapper.Map<Category>(categoryDTO);

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);

            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var categoryProductsDTOs = xmlHelper.Deserialize<ImportCategoryProductDTO[]>(inputXml, "CategoryProducts");

            var validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDTO in categoryProductsDTOs)
            {
                if (!context.Categories.Any(x => x.Id == categoryProductDTO.CategoryId) ||
                    !context.Products.Any(p => p.Id == categoryProductDTO.ProductId))
                {
                    continue;
                }

                var categoryProduct = mapper.Map<CategoryProduct>(categoryProductDTO);

                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);

            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDTO()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                }).ToArray();

            string xmlOutput = xmlHelper.Serialize(productsInRange, "Products");

            return xmlOutput;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUsersWithSoldProducts()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold
                        .Select(p=> new ExportProdutsDTO()
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                }).ToArray();

            string xmlOutput = xmlHelper.Serialize(usersWithSoldProducts, "Users");

            return xmlOutput;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var categorierByProdutsCount = context.Categories
                .Select(c => new ExportCategoriesByProductsCountDTO()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p=> p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p=> p.Product.Price)
                })
                .OrderByDescending(c=> c.Count)
                .ThenBy(c=> c.TotalRevenue)
                .ToArray();

            string xmlOutput = xmlHelper.Serialize(categorierByProdutsCount, "Categories");

            return xmlOutput;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var xmlHelper = new XmlHelper();

            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new ExportUsersWithProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsInfoDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new ExportProductSoldProductDTO()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p=> p.Price)
                            .ToArray()
                    }
                }).ToArray();

            string xmlOuput = xmlHelper.Serialize(usersWithProducts, "users");

            return xmlOuput;
        }

        //TODO - Try to decrease the .Zip file size for Problems: 6, 7 and 8. They are finished but Judge System says that file is too big.
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
    }
}