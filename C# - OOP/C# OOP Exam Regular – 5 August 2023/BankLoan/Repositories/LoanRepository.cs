using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private ICollection<ILoan> models;

        public LoanRepository()
        {
            this.models = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models => this.models.ToList().AsReadOnly();

        public void AddModel(ILoan model)
        {
            this.models.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
            return this.models.Remove(model);
        }
    }
}
