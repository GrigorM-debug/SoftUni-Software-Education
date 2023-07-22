using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount; 

        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionsMessages.IdIsZroOrNegative);
                }

                this.id = value;
            }
        }
        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this.from;
            set
            {
                if(String.IsNullOrWhiteSpace(value
                    ))
                {
                    throw new ArgumentException(TransactionExceptionsMessages.FromIsNullOrWhiteSpace);
                }

                this.from = value;
            }
        }
        public string To
        {
            get => this.to;
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptionsMessages.ToIsNullOrWhiteSpace);
                }

                this.to = value;
            }
        }
        public decimal Amount
        {
            get => this.amount;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionsMessages.AmountIsZeroOrNegative);
                }

                this.amount = value;
            }
        }
    }
}
