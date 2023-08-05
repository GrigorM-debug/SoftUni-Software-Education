using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        IRepository<ILoan> loans;
        IRepository<IBank> banks;

        public Controller()
        {
            this.banks = new BankRepository();
            this.loans = new LoanRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if(bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
            {
                throw new ArgumentException("Invalid bank type.");
            }

            IBank bank = null;

            if(bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }

            this.banks.AddModel(bank);

            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if(clientTypeName != nameof(Adult) && clientTypeName != nameof(Student))
            {
                throw new ArgumentException("Invalid client type.");
            }

            var bank = this.banks.Models.FirstOrDefault(x => x.Name == bankName);

            if(bank.GetType().Name == "CentralBank" && clientTypeName == "Student" || bank.GetType().Name == "BranchBank" && clientTypeName == "Adult")
            {
                return "Unsuitable bank.";
            }

            IClient client = null;

            if(clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else if(clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }

            bank.AddClient(client);

            return $"{clientTypeName} successfully added to {bankName}.";
        }

        public string AddLoan(string loanTypeName)
        {
            if(loanTypeName != nameof(StudentLoan) && loanTypeName != nameof(MortgageLoan))
            {
                throw new ArgumentException("Invalid loan type.");
            }

            ILoan loan = null;

            if(loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else if(loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }

            this.loans.AddModel(loan);

            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            var bank = this.banks.Models.FirstOrDefault(x => x.Name == bankName);

            var sum = bank.Clients.Sum(x => x.Income) +bank.Loans.Sum(x=> x.Amount);

            return $"The funds of bank {bankName} are {sum:f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = this.loans.FirstModel(loanTypeName);

            if(loan is null){
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            var bank = this.banks.Models.FirstOrDefault(x=> x.Name == bankName);

            bank.AddLoan(loan);

            this.loans.RemoveModel(loan);

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var bank in this.banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
