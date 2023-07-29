using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Repositories.Contracts
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Models { get; }

        void AddModel(T model);

        T FindById(int id);

        T FindByName(string name);
    }
}
