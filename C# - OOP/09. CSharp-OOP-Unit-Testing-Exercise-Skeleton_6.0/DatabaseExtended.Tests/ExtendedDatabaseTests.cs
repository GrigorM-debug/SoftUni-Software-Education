namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            Person[] persons =
            {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(persons);
        }

        [Test]
        public void CreatingDatabaseShouldWorkCorrectly()
        {
            int expedtedResult = 11;

            Assert.AreEqual(expedtedResult, database.Count);
        }

        [Test]
        public void CreatingDataBaseShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan_Ivan"),
                new Person(4, "Pesho_ivanov"),
                new Person(5, "Gosho_Naskov"),
                new Person(6, "Pesh-Peshov"),
                new Person(7, "Ivan_Kaloqnov"),
                new Person(8, "Ivan_Draganchov"),
                new Person(9, "Asen"),
                new Person(10, "Jivko"),
                new Person(11, "Toshko"),
                new Person(12, "Moshko"),
                new Person(13, "Foshko"),
                new Person(14, "Loshko"),
                new Person(15, "Roshko"),
                new Person(16, "Boshko"),
                new Person(17, "Kokoshko")
            };

            string expectedMessage = "Provided data length should be in range [0..16]!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Database(persons));

            Assert.AreEqual(expectedMessage, ex.Message);   
        }

        [Test]
        public void DataseCountShouldWorkCorrectly()
        {
            int expectedResult = 11;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void AddMethodShoudIncreaseCount()
        {
            int expectedResult = 12;

            Person person = new(18, "Stefan");

            database.Add(person);

            Assert.AreEqual(expectedResult, database.Count);    
        }

        [Test]
        public void AddMethodShoudWorkCorrectly()
        {
            int expectedResult = 12;

            Person person = new(18, "Stefan");

            database.Add(person);

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person person1 = new(12, "John");
            Person person2 = new(13, "Paul");
            Person person3 = new(14, "Green");
            Person person4 = new(15, "Brown");
            Person person5 = new(16, "Killer");

            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);

            string expectedMessage = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException> (() => database.Add(person5 = new(17, "Chester")));

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void AddMethodShouldthrowExceptionIfThereAreTwoPersonWiththeSameUsername()
        {
            Person person = new(12, "Pesho");

            string expectedMessage = "There is already user with this username!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfThereAreTwoPersonsWithTheSameID()
        {
            Person person = new(11, "Jackson");

            string expectedMessage = "There is already user with this Id!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            int expectedResult = 10;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void RemoveMethodShouldDecreaseTheCount()
        {
            int expectedResult = 10;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountISZero()
        {
            Database database= new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase("Pesho")]
        [TestCase("Gosho")]
        [TestCase("Asen")]
        public void FindByNameMethodShouldWorkCorrectly(string name)
        {
            //Person actualResult = database.FindByUsername(name);

            Assert.AreEqual(name, database.FindByUsername(name).UserName);
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldBeCaseSensitive()
        {
            string expectedResult = "peShO";
            string actualResult = database.FindByUsername("Pesho").UserName;

            Assert.AreNotEqual(expectedResult, actualResult);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByNameMethodShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        { 

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));

            Assert.AreEqual("Username parameter is null!", ex.ParamName);
        }

        [Test]
        [TestCase("Paul")]
        [TestCase("Kiro")]
        public void FindByNameMethodShouldThrowExceptionIfUsernameIsNotFount(string username)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));

            Assert.AreEqual("No user is present by this username!", ex.Message);
        }

        [Test]
        public void FindByIdShouldWorkCorrectly()
        {
            string expectedResult = "Gosho";

            string actualresult = database.FindById(2).UserName;

            Assert.AreEqual(expectedResult, actualresult);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-50)]
        public void FindByIDShouldThrowExceptionIfIdIsNegative(long id)
        {
            string expectedMessage = "Id should be a positive number!";

            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));

            Assert.AreEqual(expectedMessage, ex.ParamName);
        }

        [TestCase(18)]
        [TestCase(19)]
        [TestCase(50)]
        public void FindByIdShouldThrowExceptionIfThereNoPersonWithGivenId(long id)
        {
            string expectedMessage = "No user is present by this ID!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindById(id));   

            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}