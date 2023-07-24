﻿using Chainblock.Models.Interfaces;
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

        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
        public void GetAllOrderedByAmountDecendingThenByIdShouldReturnTheCollectionOrderedProperly(TransactionStatus getStatus, TransactionStatus otherStatus)
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

            IEnumerable<ITransaction> expectedOutput = transactionsToAppend
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);

            IEnumerable<ITransaction> actualOutput = chainBlock
                .GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnEmptyCollectionWhenCollectionIsEmpty()
        {
            IEnumerable<ITransaction> transactions = chainBlock
                .GetAllOrderedByAmountDescendingThenById();

            Assert.IsEmpty(transactions);
        }

        [Test]
        public void GetAllInAmountRangeMethodShouldReturnEmptyCollectionIfCollectionIsEmpty()
        {
            IEnumerable<ITransaction> transactions = chainBlock
                .GetAllInAmountRange(100, 200);

            Assert.IsEmpty(transactions);
        }

        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
        public void GetAllAmountInRangeMethodShouldWorkProperly(TransactionStatus getStatus, TransactionStatus otherStatus)
        {
            decimal minRange = 100m;
            decimal maxRange = 200m;

            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, getStatus, "Ivan", "Peter", 100),
                new Transaction(2, getStatus, "Ivan", "Asen", 500),
                new Transaction(3, otherStatus, "Andrey", "Gosho", 700),
                new Transaction(4, otherStatus, "Pesho", "Stefan", 200),
                new Transaction(5, getStatus, "Mohamed", "Ali", 150)
            };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend
            .Where(t => t.Amount >= minRange && t.Amount <= maxRange);

            IEnumerable<ITransaction> actualResult = chainBlock.GetAllInAmountRange(minRange, maxRange);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverAndAmountRangeMethodShouldWorkProperly(string receiver)
        {
            decimal minRange = 100m;
            decimal maxRange = 700m;

            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, TransactionStatus.Successfull, "Ivan", receiver, 100),
                new Transaction(2, TransactionStatus.Successfull, "Ivan", receiver, 500),
                new Transaction(3, TransactionStatus.Unauthorised, "Andrey", receiver, 700),
                new Transaction(4, TransactionStatus.Failed, "Pesho", receiver, 200),
                new Transaction(5, TransactionStatus.Aborted, "Ali", receiver, 150)
            };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend.
            Where(t => t.To == receiver && t.Amount >= minRange && t.Amount < maxRange)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actualResult = chainBlock.GetByReceiverAndAmountRange(receiver, minRange, maxRange);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionIfCollectionIsEmpty(string receiver)
        {
            decimal minRange = 100m;
            decimal maxRange = 500m;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByReceiverAndAmountRange(receiver, minRange, maxRange));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver), ex.Message);
        }

        [TestCase("Ivan")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionIfTransactionIsNotFound(string receiver)
        {
            chainBlock.Add(transaction);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByReceiverAndAmountRange(receiver, 10, 15));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver), ex.Message);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldWorkProperly(string receiver)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, TransactionStatus.Successfull, "Ivan", receiver, 100),
                new Transaction(2, TransactionStatus.Successfull, "Ivan", receiver, 500),
                new Transaction(3, TransactionStatus.Unauthorised, "Andrey", receiver, 700),
                new Transaction(4, TransactionStatus.Failed, "Pesho", receiver, 200),
                new Transaction(5, TransactionStatus.Aborted, "Ali", receiver, 150)
            };

            foreach (ITransaction tx in transactionsToAppend)
            {
                chainBlock.Add(tx);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend.
            Where(t => t.To == receiver)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actualResult = chainBlock.GetByReceiverOrderedByAmountThenById(receiver);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowExceptionIfCollectionIsEmpty(string receiver)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByReceiverOrderedByAmountThenById(receiver));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver), ex.Message);
        }

        [TestCase("Ivan")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowExceptionIfCollectionIsNotFound(string receiver)
        {
            chainBlock.Add(transaction);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetByReceiverOrderedByAmountThenById(receiver));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver), ex.Message);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetBySenderOrderedByAmountDescendingMethodShouldWorkProperly(string sender)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, TransactionStatus.Successfull, sender, "Ali", 100),
                new Transaction(2, TransactionStatus.Successfull, sender, "Hasan", 500),
                new Transaction(3, TransactionStatus.Unauthorised, sender, "ss", 700),
                new Transaction(4, TransactionStatus.Failed, sender, "wdwd", 200),
                new Transaction(5, TransactionStatus.Aborted, sender, "wdfwf", 150)
            };

            foreach(var transaction in transactionsToAppend)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend.Where(tx => tx.From== sender).OrderByDescending(tx => tx.Amount);

            IEnumerable<ITransaction> actualResult = chainBlock.GetBySenderOrderedByAmountDescending(sender);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldThrowExceptionIfCollectionIsEmpty()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderOrderedByAmountDescending("Ivan"));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, "Ivan"), ex.Message);
        }

        [TestCase("Pesho")]
        [TestCase("Stefan")]
        [TestCase("Goshko")]
        [TestCase("Mohamed")]
        public void GetBySenderOrderedByDescendingMethodShouldThrowExceptionIfCollectionIsNotFound(string sender)
        {
            chainBlock.Add(transaction);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderOrderedByAmountDescending(sender));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender), ex.Message);
        }

        [TestCase("Ivan", 20)]
        [TestCase("Pesho", 40)]
        [TestCase("Stefan", 100)]
        [TestCase("Goshko", 300)]
        [TestCase("Mohamed", 10)]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldWorkProperly(string sender, decimal minAmount)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, TransactionStatus.Successfull, sender, "Ali", 100),
                new Transaction(2, TransactionStatus.Successfull, sender, "Hasan", 500),
                new Transaction(3, TransactionStatus.Unauthorised, sender, "ss", 700),
                new Transaction(4, TransactionStatus.Failed, sender, "wdwd", 200),
                new Transaction(5, TransactionStatus.Aborted, sender, "wdfwf", 150)
            };

            foreach (var transaction in transactionsToAppend)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend.Where(tx => tx.From == sender && tx.Amount > minAmount).OrderByDescending(tx => tx.Amount);

            IEnumerable<ITransaction> actualResult = chainBlock.GetBySenderAndMinimumAmountDescending(sender, minAmount);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldThrowExceptionIfCollectionIsEmpty()
        {
            string sender = "Ivan";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderAndMinimumAmountDescending(sender, 100));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender), exception.Message
                );
        }

        [TestCase("Pesho", 20)]
        [TestCase("Stefan", 100)]
        [TestCase("Goshko", 300)]
        [TestCase("Mohamed", 10)]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionIfTransactionIsNotFound(string sender, decimal minAmount)
        {
            chainBlock.Add(transaction);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => chainBlock.GetBySenderAndMinimumAmountDescending(sender, minAmount));

            Assert.AreEqual(
                string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender), exception.Message
                );
        }

        [TestCase(TransactionStatus.Successfull, 400)]
        [TestCase(TransactionStatus.Aborted, 300)]
        [TestCase(TransactionStatus.Failed, 100)]
        [TestCase(TransactionStatus.Unauthorised, 200)]
        [TestCase(TransactionStatus.Unauthorised, 150.44)]
        public void GetByTransactionStatusAndMaximumAmountMethodShouldWorkProperly(TransactionStatus status, decimal maxAmount)
        {
            IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
            {
                new Transaction(1, status, "Ivan", "Ali", 100),
                new Transaction(2, status, "Ali", "Hasan", 500),
                new Transaction(3, status, "Mohamed", "ss", 700),
                new Transaction(4, status, "Stefan", "wdwd", 200),
                new Transaction(5, status, "gosho", "wdfwf", 150)
            };

            foreach (var transaction in transactionsToAppend)
            {
                chainBlock.Add(transaction);
            }

            IEnumerable<ITransaction> expectedResult = transactionsToAppend.Where(tx=>tx.Status == status && tx.Amount <= maxAmount).OrderByDescending(tx=>tx.Amount);

            IEnumerable<ITransaction> actualResult = chainBlock.GetByTransactionStatusAndMaximumAmount(status, maxAmount);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodShouldReturnEmptyCollectionIdCollectionIsEmptyOrNotFound()
        {
            IEnumerable<ITransaction> transactions = chainBlock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorised, 100);

            Assert.IsEmpty(transactions);
        }
    }
}
