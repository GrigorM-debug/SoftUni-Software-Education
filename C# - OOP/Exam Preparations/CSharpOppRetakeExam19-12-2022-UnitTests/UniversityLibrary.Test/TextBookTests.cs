namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class TextBookTests
    {

        [Test]
        public void ConstructorShouldInitializeProperly()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            string expectedTitle = "Harry Poter";
            string expectedAuthor = "J.K. Rowling";
            string expectedCategory = "Fantasy";

            Assert.AreEqual(expectedTitle, textBook.Title);
            Assert.AreEqual(expectedAuthor, textBook.Author);
            Assert.AreEqual(expectedCategory, textBook.Category);
        }

        [Test]
        public void TitlePropertyShouldInitializeProperly()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");
            string expectedTitle = "Harry Poter";
            Assert.AreEqual(expectedTitle, textBook.Title);
        }

        [Test]
        public void AuthorPropertyShouldInitializeProperly()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");
            string expectedAuthor = "J.K. Rowling";
            Assert.AreEqual(expectedAuthor, textBook.Author);
        }

        [Test]
        public void CategoryPropertyShouldInitializeProperty()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");
            string expectedCategory = "Fantasy";
            Assert.AreEqual(expectedCategory, textBook.Category);
        }

        [Test]
        public void InvertoryNumberPropertyShouldWorkProperly()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            var expectedResult = 2;

            textBook.InventoryNumber = 2;

            Assert.AreEqual(expectedResult, textBook.InventoryNumber);
        }

        [Test]
        public void InvertoryNumberShouldHaveZeroForDefaultValue()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            Assert.AreEqual(0, textBook.InventoryNumber);
        }

        [Test]
        public void HolderShouldInitializePropety()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            textBook.Holder = "Pesho";

            Assert.AreEqual("Pesho", textBook.Holder);
        }

        [Test]
        public void HolderPropertyShouldHaveNullForDefaultValue()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            Assert.AreEqual(null, textBook.Holder);
        }

        [Test]
        public void OverriteToStringMethodShouldWorkProperly()
        {
            var textBook = new TextBook("Harry Poter", "J.K. Rowling", "Fantasy");

            StringBuilder expectedStringBuilder = new StringBuilder();
            expectedStringBuilder.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            expectedStringBuilder.AppendLine($"Category: {textBook.Category}");
            expectedStringBuilder.AppendLine($"Author: {textBook.Author}");

            string expected = expectedStringBuilder.ToString().TrimEnd();
            Assert.AreEqual(expected, textBook.ToString());
        }
    }
}