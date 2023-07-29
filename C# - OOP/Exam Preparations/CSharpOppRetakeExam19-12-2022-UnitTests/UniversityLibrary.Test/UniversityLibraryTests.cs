using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary.Test
{
    public class UniversityLibraryTests
    {
        [Test]
        public void ConstructorShouldInitializeTextBookCollectionAsEmpty()
        {
            var universityLibrary = new UniversityLibrary();

            Assert.IsEmpty(universityLibrary.Catalogue);
        }

        [Test]
        public void CataloguePropertyShouldWorkProperly()
        {
            var universityLibrary = new UniversityLibrary();

            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            universityLibrary.Catalogue.Add(textBook);

            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void CotaloguePropertyShouldBeEmptyAsDefault()
        {
            var universityLibrary = new UniversityLibrary();

            Assert.IsEmpty(universityLibrary.Catalogue);
        }

        [Test]
        public void AddTextBookToLibraryShouldReturnTextBookToString()
        {
            var universityLibrary = new UniversityLibrary();

            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            //universityLibrary.AddTextBookToLibrary(textBook);

            var expectedStringBuilder = new StringBuilder();
            expectedStringBuilder = new StringBuilder();
            expectedStringBuilder.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber+1}");
            expectedStringBuilder.AppendLine($"Category: {textBook.Category}");
            expectedStringBuilder.AppendLine($"Author: {textBook.Author}");

            Assert.AreEqual(expectedStringBuilder.ToString().TrimEnd(), universityLibrary.AddTextBookToLibrary(textBook));
        }

        [Test]
        public void AddTextBookToLibraryShouldIncreaseTheInventoryNumber()
        {
            var universityLibrary = new UniversityLibrary();

            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, textBook.InventoryNumber);
        }

        [Test]
        public void AddTextBookToLibraryShouldAddBookToTheCatalogue()
        {
            var universityLibrary = new UniversityLibrary();

            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            universityLibrary.AddTextBookToLibrary(textBook);

            CollectionAssert.Contains(universityLibrary.Catalogue, textBook);
        }

        [Test]
        public void LoanTextBookShouldWorkProperly()
        {
            UniversityLibrary library = new UniversityLibrary();

            // Add test textbooks to the library's collection
            TextBook book1 = new TextBook("Book", "Ivan", "Rakia");

            book1.InventoryNumber = 1;

            TextBook book2 = new TextBook("Pesho", "Kiro", "Mastika");

            book2.InventoryNumber = 2;

            library.Catalogue.Add(book1);
            library.Catalogue.Add(book2);

            // Prepare test input parameters
            int bookInventoryNumber = 1;
            string studentName = "John Doe";

            // Act
            string result = library.LoanTextBook(bookInventoryNumber, studentName);

            // Assert
            Assert.AreEqual($"Book loaned to {studentName}.", result);
            Assert.AreEqual(studentName, book1.Holder);
        }

        [Test]
        public void LoanTextBook_ShouldReturnErrorMessageWhenBookAlreadyLoaned()
        {
            // Arrange
            UniversityLibrary library = new UniversityLibrary();

            // Add test textbooks to the library's collection
            TextBook book1 = new TextBook("Batman", "Robin", "The Dark knight");

            book1.InventoryNumber = 1;

            book1.Holder = "John Doe";

            library.Catalogue.Add(book1);

            // Prepare test input parameters
            int bookInventoryNumber = 1;
            string studentName = "John Doe";

            // Act
            string result = library.LoanTextBook(bookInventoryNumber, studentName);

            // Assert
            Assert.AreEqual($"{studentName} still hasn't returned {book1.Title}!", result);
            Assert.AreEqual("John Doe", book1.Holder); // Verify that the holder remains unchanged
        }

        [Test]
        public void ReturnTextBookShouldWorkProperly()
        {
            UniversityLibrary library = new UniversityLibrary();

            // Add test textbooks to the library's collection
            TextBook book1 = new TextBook("Batman", "Jokera", "Tamna no6t");

            book1.InventoryNumber = 1;
            book1.Holder = "John Doe";

            library.Catalogue.Add(book1);

            // Prepare test input parameter
            int bookInventoryNumber = 1;

            // Act
            string result = library.ReturnTextBook(bookInventoryNumber);

            // Assert
            Assert.AreEqual($"{book1.Title} is returned to the library.", result);
            Assert.AreEqual(string.Empty, book1.Holder);
        }
    }
}
