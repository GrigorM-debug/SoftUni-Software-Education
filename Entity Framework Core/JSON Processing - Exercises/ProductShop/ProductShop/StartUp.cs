using ProductShop.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));
            File.WriteAllText(@"users-and-products.json", GetUsersWithProducts(context));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        //01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            var validCategories = categories
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(validCategories);

            context.SaveChanges();

            return $"Successfully imported {validCategories.Length}";
        }

        //04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //05 - Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p=> p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p=> p.Price)
                .Select(p=> new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .ToArray();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            string json = JsonConvert.SerializeObject(productsInRange, options);

            return json;
        }

        //06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWitSoldProducts = context.Users
                .Where(x => x.ProductsSold.Any(p=> p.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    SoldProducts = e.ProductsSold
                        .Select(x => new
                        {
                            Name = x.Name,
                            Price = x.Price,
                            BuyerFirstName = x.Buyer.FirstName,
                            BuyerLastName = x.Buyer.LastName
                        })
                        .ToArray()
                }).ToArray();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            string json = JsonConvert.SerializeObject(usersWitSoldProducts, options);

            return json;
        }

        //07 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoriesProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoriesProducts.Count,
                    AveragePrice = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Average(p=> p.Product.Price) : 0).ToString("f2"),
                    TotalRevenue = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Sum(p=> p.Product.Price) : 0).ToString("f2")
                })
                .ToArray();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(categories, options);

            return json;
        }

        //08 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProduct = context.Users
                .Where(x => x.ProductsSold.Any(x => x.BuyerId != null))
                .Select(u => new 
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold
                        .Where(x=> x.BuyerId != null)
                        .Select(x=> new
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();

            var output = new 
            {
                UsersCount = usersWithProduct.Length,
                Users = usersWithProduct.Select(u=> new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }
                })
            };

            var usersWithProductsOnOneLine = new
            {
                usersCount = context.Users.Count(x=> x.ProductsSold.Any(p=> p.BuyerId != null)),
                users = context.Users
                    .Where(x => x.ProductsSold.Any(x => x.BuyerId != null))
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        SoldProducts = new
                        {
                            Count = u.ProductsSold.Count(p => p.BuyerId != null),
                            Products = u.ProductsSold
                                .Where(p => p.BuyerId != null)
                                .Select(p => new
                                {
                                    p.Name,
                                    p.Price
                                }).ToArray()
                        }
                    })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .ToArray()
            };

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(usersWithProductsOnOneLine, options);

            return json;
        }
    }
}