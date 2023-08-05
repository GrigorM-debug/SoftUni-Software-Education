using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private ICollection<ILoan> loans;
        private ICollection<IClient> clients;

        protected Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name cannot be null or empty.");
                }

                if(value != Name)
                {
                    this.name = value;
                }
                //this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => this.loans.ToList();

        public IReadOnlyCollection<IClient> Clients => this.clients.ToList();

        public void AddClient(IClient Client)
        {
            if(this.clients.Count < Capacity)
            {
                this.clients.Add(Client);
            }
            else
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            sb.Append($"Clients: ");

            if (clients.Any())
            {
                foreach(var client in Clients)
                {
                    sb.Append($"{client.Name}, ");
                }
                sb.Length -= 2;
            }
            else
            {
                sb.Append("none");
            }
            sb.AppendLine();
            sb.AppendLine($"Loans: {this.loans.Count}, Sum of Rates: {this.SumRates()}");


            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
        }

        public double SumRates()
        {
            return this.loans.Sum(x => x.InterestRate);
        }
    }
}
