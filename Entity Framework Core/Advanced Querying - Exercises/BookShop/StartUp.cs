using System.Security.Authentication.ExtendedProtection;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Console.WriteLine(GetAuthorNamesEndingIn(db, input));
        }

        //Exercise: 2 - Age Restriction in two ways
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //if (!Enum.TryParse<AgeRestriction>(command.ToLower(), true, out var ageRestriction))
            //{
            //    return $"{command} is not valid age restriction";
            //}

            //var books = context.Books
            //    .Where(b => b.AgeRestriction.Equals(ageRestriction))
            //    .OrderBy(b => b.Title)
            //    .Select(b => b.Title)
            //    .ToArray();

            //return string.Join(Environment.NewLine, books);

            try
            {
                var ageRestriction = Enum.Parse<AgeRestriction>(command.ToLower(), true);
                var books = context.Books
                    .Where(b => b.AgeRestriction.Equals(ageRestriction))
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, books);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{command} is not valid age restriction");
            }

            return null;
        }

        //Exercise: 3 - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b=> b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b=> b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //Exercise: 4 - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b=> b.Price > 40)
                .OrderByDescending(b=> b.Price)
                .Select(b=> new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb
                    .AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        
        //Exercise: 5 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b=> b.ReleaseDate.Value.Year != year)
                .OrderBy(b=>b.BookId)
                .Select(b=> b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //Exercise: 6 - Book Titles By Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                .Where(b=> b.BookCategories.Any(bc=>categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b=> b.Title)
                .Select(b=> b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }


        //Exercise: 8 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(b => b.FirstName.EndsWith(input))
                //.OrderBy(b=> b.Author.FirstName)
                //.ThenBy(b=> b.Author.LastName)
                .Select(b => b.FirstName + " " + b.LastName)
                .OrderBy(b=>b)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }
    }
}


