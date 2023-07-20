namespace Database.Tests
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            int expectedResult = 2;

            Database database = new Database(1, 2);

            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDataBaseShouldAddElementsCorrectly(int[] data)
        {
            Database database = new Database(data);

            int[] actualResults = database.Fetch();

            Assert.AreEqual(data, actualResults);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            string expectedMessage = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new Database(data));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void DataBaseCountShouldWorkCorrectly()
        {
            Database database = new Database(1, 2, 3);

            int expectedResult = 3;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16()
        {
            Database database = new Database(1, 2);

            for(int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            string expectedMessage = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(3));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AddMethodShouldIncreaseTheDatabaseCount()
        {
            Database database = new Database(1, 2, 3);

            int expectedResult = 4;

            database.Add(4);

            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7})]
        public void AddMethodShouldAddElementsCorrectly(int[] data)
        {
            Database database = new Database();

            foreach(var number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCollectionIsEmpty()
        {
            Database database = new Database(1, 2);

            database.Remove();
            database.Remove();

            string expectedMessage = "The collection is empty!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6})]
        public void RemoveMethodShouldDecreaseTheDatabaseCount(int[] data)
        {
            Database database = new Database(data);

            int expedtedResult = 5;

            database.Remove();

            Assert.AreEqual(expedtedResult, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            Database database= new Database(1, 2);

            int[] expectedResult = { };

            database.Remove();
            database.Remove();

            Assert.AreEqual(expectedResult, database.Fetch());
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6})]  
        public void DataBaseFetchMethodShouldWorkCorrectly(int[] data)
        {
            Database database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
