using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models;
using Chainblock.Models.Interfaces;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TransactionConstructorShouldWorkProperly()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", 400);

            Assert.IsNotNull(transaction);  
        }

        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            int expectedResult = 1;

            ITransaction transaction = new Transaction(expectedResult, TransactionStatus.Successfull, "Gosho", "Pesho", 400);

            int actualResult = transaction.Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldInitializeTransactioStatusProperly()
        {
            TransactionStatus status = TransactionStatus.Failed;

            ITransaction transaction = new Transaction(1, status, "Ivan", "Peter", 300);

            Assert.AreEqual(status, transaction.Status);
        }

        [Test]
        public void ConstructorShouldInitializeFromProperly()
        {
            string expectedResult = "Gosho";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedResult, "Peter", 3000);

            Assert.AreEqual(expectedResult, transaction.From);
        }

        [Test]
        public void ConstructorShouldinitializeToProperly()
        {
            string expectedResult = "Ivan";

            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Goshow", expectedResult, 9000);

            Assert.AreEqual(expectedResult, transaction.To);
        }

        [Test]
        public void ConstructorShouldInitializeAmountProperly()
        {
            decimal expectedAmount = 340.99m;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Peter", expectedAmount);

            Assert.AreEqual(expectedAmount, transaction.Amount);    
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void IdSetterShouldthrowExceptionForZeroOrNegativeId(int id)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(id, TransactionStatus.Aborted, "Ivan", "Pesho", 100));

            Assert.AreEqual(TransactionExceptionsMessages.IdIsZroOrNegative, exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("         ")]
        public void FromSetterShouldThrowExceptionForNullOrWhiteSpace(string from)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, from, "Ivan", 100));

            Assert.AreEqual(TransactionExceptionsMessages.FromIsNullOrWhiteSpace, exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("         ")]
        public void ToSetterShouldThrowExceptionForNullOrWthiteSpace(string to)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, "Ivan", to, 100));

            Assert.AreEqual(TransactionExceptionsMessages.ToIsNullOrWhiteSpace, exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1.1)]
        [TestCase(-200.99)]
        public void AmountSetterShouldThrowExceptionForZeroOrNegative(decimal amount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, "Ivan", "Grigor", amount));

            Assert.AreEqual(TransactionExceptionsMessages.AmountIsZeroOrNegative, exception.Message);
        }
    }
}