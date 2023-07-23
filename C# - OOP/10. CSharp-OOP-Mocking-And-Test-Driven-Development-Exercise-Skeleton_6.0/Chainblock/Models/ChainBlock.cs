using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            if (Contains(tx.Id
                ))
            {
                throw new ArgumentException(
                    string.Format(ChainBlockExceptionsMessages.TransactionDuplicated, tx.Id));
            }
            transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, Enums.TransactionStatus newStatus)
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

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
        {
            IEnumerable<ITransaction> result = transactions.Values
            .Where(t => t.Amount >= lo && t.Amount <= hi);

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> result = transactions.Values
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(Enums.TransactionStatus status)
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

        public IEnumerable<string> GetAllSendersWithTransactionStatus(Enums.TransactionStatus status)
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

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver)
                    ); 
            }

            IEnumerable<ITransaction> result = transactions.Values
            .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver)
                    );
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if(!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver)
                    );
            }

            IEnumerable<ITransaction> result = transactions.Values.Where(t => t.To == receiver)
            .OrderByDescending(t => t.Amount)
            .ThenBy(t => t.Id);

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithReceiverDoesNotExit, receiver)
                    );
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender)
                    );
            }

            IEnumerable<ITransaction> result = transactions.Values.Where(tx => tx.From == sender && tx.Amount > amount).OrderByDescending(tx=> tx.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender)
                    );
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender)
                    ); 
            }

            IEnumerable<ITransaction> result = transactions.Values.Where(tx => tx.From == sender).OrderByDescending(tx => tx.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionWithSenderDoesNotExist, sender)
                    );
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(Enums.TransactionStatus status)
        {
            if (!transactions.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            IEnumerable<ITransaction> result = transactions.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionsWithStatusDoesNotExist, status));
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(Enums.TransactionStatus status, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException(
                    string.Format(ChainBlockExceptionsMessages.TransactionDoesNotExist, id));
            }

            transactions.Remove(id);
        }
    }
}
