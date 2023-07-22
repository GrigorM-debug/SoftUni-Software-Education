﻿using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models
{
    public class ChainBlock : IChainblock
    {
        IDictionary<int, ITransaction> transactions;
        
        public ChainBlock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if(Contains(tx.Id
                ))
            {
                throw new ArgumentException(
                    string.Format(ChainBlockExceptionsMessages.TransactionDuplicated, tx.Id));
            }
            transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException(
                    string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, id)
                    ); ;
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(int id)
         => transactions.ContainsKey(id);

        public bool Contains(ITransaction tx)
        => Contains(tx.Id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            IEnumerable<string> result = transactions.Values.Where(tx => tx.Status == status)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            IEnumerable<string> result = transactions.Values.Where(tx => tx.Status == status)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            return result;
        }

        public ITransaction GetById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException(
                string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, id));
            }

            return transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            IEnumerable<ITransaction> result = transactions.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount);

            if(!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if(!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, id));
            }

            transactions.Remove(id);    
        }
    }
}
