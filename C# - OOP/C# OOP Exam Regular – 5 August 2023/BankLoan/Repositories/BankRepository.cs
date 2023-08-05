using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private ICollection<IBank> models;

        public BankRepository()
        {
            this.models = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IBank model)
        {
            this.models.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveModel(IBank model)
        {
            return this.models.Remove(model);
        }
    }
}
