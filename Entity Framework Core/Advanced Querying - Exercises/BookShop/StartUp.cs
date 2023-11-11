using System.Text;
using BookShop.Initializer;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            // string input = Console.ReadLine();

            //int lengthCheck = int.Parse(Console.ReadLine());

            //string date = Console.ReadLine();
            //Console.WriteLine(GetMostRecentBooks(db));

            //IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db));
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

        //Exercise 7: Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b=> b.ReleaseDate.HasValue && b.ReleaseDate < parsedDate)
                .OrderByDescending(b=>b.ReleaseDate)
                .Select(b=> new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
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

        //Exercise: 9 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b=> b.Title.ToLower().Contains(input.ToLower()))
                .Select(b=>b.Title)
                .OrderBy(b=>b)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //Exercise: 10 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b=> b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b=> b.BookId)
                .Select(b=> new
                {
                    BookTitle = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Exercise: 11 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return booksCount;

            //var books = context.Books
            //    .Where(b=> b.Title.Length > lengthCheck)
            //    .ToList();

            //return books.Count();
        }

        //Exercise: 12 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsBooksCount = context.Authors
                //.OrderByDescending(a => a.Books.Sum(b=> b.Copies))
                .Select(a=>new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    BookCopiesCount = a.Books.Sum(b=>b.Copies)
                })
                .OrderByDescending(a => a.BookCopiesCount)
                .ToArray();

            var sb = new StringBuilder();
 
            foreach (var a in authorsBooksCount)
            {
                sb.AppendLine($"{a.AuthorName} - {a.BookCopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }

        //Exercise: 13 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c=> new
                {
                    BookCategory = c.Name,
                    Profit = c.CategoryBooks.Sum(bc=>bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c=> c.Profit)
                .ThenBy(c=>c.BookCategory)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.BookCategory} ${c.Profit:f2}");
            }

            return sb.ToString().TrimEnd(); 
        }

        //Exercise: 14 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var bookByCategories = context.Categories
                .Select(c => new
                {
                    BookCategory = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b=>b.Book.ReleaseDate)
                        .Select(b => new
                        {
                            BookTitle = b.Book.Title,
                            ReleaseDate = b.Book.ReleaseDate.Value.Year,
                        })
                        //.OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.BookCategory)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var c in bookByCategories)
            {
                sb.AppendLine($"--{c.BookCategory}");

                foreach (var b in c.Books)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Exercise: 15 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncreasePrices = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in booksToIncreasePrices)
            {
                b.Price += 5;
            }

            //context.BulkInsert(booksToIncreasePrices);
            context.SaveChanges();
        }

        //Exercise: 16 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksCategoriesToRemove = context.BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToArray();

            var booksToRemove = context.Books
                .Where(b=> b.Copies < 4200)
                .ToArray();

            int removedBooks = booksToRemove.Count();
            context.BooksCategories.RemoveRange(booksCategoriesToRemove);
            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            //int numberOfAffectedRows = context.SaveChanges();

            return removedBooks;
        }
    }
}


