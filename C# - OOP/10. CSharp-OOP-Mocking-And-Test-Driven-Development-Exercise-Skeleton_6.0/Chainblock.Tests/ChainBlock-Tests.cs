using Chainblock.Models.Interfaces;
using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Chainblock.Enums;
using Chainblock.Exceptions;
using System.Security.Cryptography;
using System.IO;
using NUnit.Framework.Interfaces;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlock_Tests
    {
        private ChainBlock chainBlock;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            chainBlock = new ChainBlock();

            transaction = new Transaction(1, TransactionStatus.Successfull, "Ivan", "Pesho", 200);
        }

        [Test]
        public void ConstructorShouldInitializeTransactionsCollection()
        {
            Type chainblockType = chainBlock.GetType();

            FieldInfo transactionsField = chainblockType
                .GetField("transactions", BindingFlags.Instance | BindingFlags.NonPublic);
            IDictionary<int, ITransaction> value =
                transactionsField.GetValue(chainBlock) as IDictionary<int, ITransaction>;

            Assert.IsNotNull(value);
        }

        [Test]
        public void AddMethodShouldAppendTransactionsToTheCollection()
        {
            chainBlock.Add(transaction);

            bool ISAdded = chainBlock.Contains(transaction.Id);

            Assert.IsTrue(ISAdded);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTransactionsIsAlreadyInCollectiopn()
        {
            chainBlock.Add(transaction);

            ArgumentException exception = Assert.Throws<ArgumentException>(() => chainBlock.Add(transaction));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionDuplicated, transaction.Id)
                , exception.Message);
        }

        [Test]
        public void AddMethodShouldIncreaseTheCount()
        {
            int expectedResult = 2;

            chainBlock.Add(transaction);

            ITransaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Stanimir", "Dimitar", 300);

            chainBlock.Add(transaction1);

            Assert.AreEqual(expectedResult, chainBlock.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingTransactionWithExistingId()
        {
            chainBlock.Add(transaction);

            ITransaction newTransaction = new Transaction(transaction.Id, TransactionStatus.Failed, "Ivan", "Kiro", 999);

            ArgumentException exception = Assert.Throws<ArgumentException>(
                 () => chainBlock.Add(newTransaction));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionDuplicated, transaction.Id),
                exception.Message);
        }

        [Test]
        public void ContainsByIdMethodReturnTrueIfTransactionExist()
        {
            bool IsAdded = chainBlock.Contains(transaction.Id);

            Assert.IsFalse(IsAdded);    
        }

        [Test]
        public void ContainsByIdMethodShouldReturnTrueIfTransactionIsInTheCollection()
        {
            chainBlock.Add(transaction);

            bool IsAdded = chainBlock.Contains(transaction.Id);

            Assert.IsTrue(IsAdded);
        }

        [Test]
        public void ContainsByTransactionMethodShouldReturnFalseIfTransactionDoesNotExist()
        {
            bool IsAdded = chainBlock.Contains(transaction);

            Assert.IsFalse(IsAdded);
        }

        [Test]
        public void ContainsByTransactionMethodShouldReturnTrueIfTransactionExist()
        {
            chainBlock.Add(transaction);

            bool IsAdded = chainBlock.Contains(transaction);

            Assert.IsTrue(IsAdded);
        }

        [Test]
        public void CountShouldBeZeroWhenNoTransactionIsAdded()
        {
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, chainBlock.Count);  
        }

        [Test]
        public void CountShouldReturnSameNumberAsNumberOfAddedTransactions()
        {
            int expectedResult = 2;

            chainBlock.Add(transaction);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Aborted, "Pesho", "Nikola", 500);
            chainBlock.Add(transaction2);

            Assert.AreEqual(expectedResult, chainBlock.Count);
        }

        [TestCase(TransactionStatus.Aborted, TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Successfull)]
        public void ChangeTransactionStatusMethodShouldWorkProperly(TransactionStatus fromStatus, TransactionStatus toStatus)
        {
            transaction.Status = fromStatus;

            chainBlock.Add(transaction);

            chainBlock.ChangeTransactionStatus(transaction.Id, toStatus);

            Assert.AreEqual(toStatus, transaction.Status);
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldThrowExceptionIfTransactionWithIdDoesNotExist()
        {
            ArgumentException exception = Assert.Throws<ArgumentException> (() => chainBlock.ChangeTransactionStatus(transaction.Id, transaction.Status));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, transaction.Id), exception.Message);    
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldWorkProperly()
        {
            chainBlock.Add(transaction);
            chainBlock.RemoveTransactionById(1);

            bool IsRemoved = chainBlock.Contains(transaction);

            Assert.IsFalse(IsRemoved);
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldThrowExceptionIfTransactionWithIdDoesNotExist()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => chainBlock.RemoveTransactionById(transaction.Id));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, transaction.Id), exception.Message
                ) ;
        }

        [Test]
        public void GetByIdMethodShouldWorkProperly()
        {
            chainBlock.Add(transaction);

            ITransaction actualResult = chainBlock.GetById(transaction.Id);

            Assert.AreEqual(transaction, actualResult);
        }

        [Test]
        public void GetByIdMethodShouldThrowExceptionIfTransactionDoesnotExist()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => chainBlock.GetById(transaction.Id));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, transaction.Id),
                exception.Message
                );
        }

        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
        public void GetByTransactionStatusShouldReturnTransactionsOrderedCorrecly(
        TransactionStatus getStatus, TransactionStatus otherStatus)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
            new Transaction(1, getStatus, "Aaa", "Bbb", 100),
            new Transaction(2, getStatus, "Ccc", "Ddd", 500),
            new Transaction(3, otherStatus, "Eee", "Ggg", 700)
        };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<ITransaction> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == getStatus)
                .OrderByDescending(tx => tx.Amount);

            IEnumerable<ITransaction> actualTransactions = chainBlock
                .GetByTransactionStatus(getStatus);

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        public void GetByTransactionStatusShouldThrowExceptionIfCollectionIfEmpty(TransactionStatus status)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByTransactionStatus(status));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status), ex.Message );
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        public void GetByTransactionStatusShouldThrowExceptionIfThereIsNoTracsactionWithGivenStatus(TransactionStatus status)
        {
            chainBlock.Add(transaction);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByTransactionStatus(status));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status), ex.Message);
        }

        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
        public void GetAllSendersWithTransactionStatusShouldReturnNamesOrderedCorrectly(TransactionStatus getStatus,
    TransactionStatus otherStatus)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, getStatus, "Ivan", "Peter", 100),
                new Transaction(2, getStatus, "Ivan", "Asen", 500),
                new Transaction(3, otherStatus, "Andrey", "Gosho", 700)
            };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == getStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();

            IEnumerable<string> actualOutput = chainBlock
                .GetAllSendersWithTransactionStatus(getStatus);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionIfCollectionIsEmpty(TransactionStatus getStatus)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetAllSendersWithTransactionStatus(getStatus));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, getStatus), ex.Message
                );
        }

        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
        public void GetAllReceiversWithTransactionStatusReturReceiversNameOrderedCorrectly(TransactionStatus getStatus,
    TransactionStatus otherStatus)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
                new Transaction(1, getStatus, "Ivan", "Peter", 100),
                new Transaction(2, getStatus, "Ivan", "Asen", 500),
                new Transaction(3, otherStatus, "Andrey", "Gosho", 700)
            };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == getStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();

            IEnumerable<string> actualOutput = chainBlock
                .GetAllReceiversWithTransactionStatus(getStatus);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Successfull)]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionIfCollectionIsEmpty(TransactionStatus status)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetAllReceiversWithTransactionStatus(status));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status), ex.Message
                );
        }

        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised)]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionIfThereIsNoTransactionWithGivenStatus(TransactionStatus status)
        {
            chainBlock.Add(transaction);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetAllReceiversWithTransactionStatus(status));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status), ex.Message);
        }
    }
}

