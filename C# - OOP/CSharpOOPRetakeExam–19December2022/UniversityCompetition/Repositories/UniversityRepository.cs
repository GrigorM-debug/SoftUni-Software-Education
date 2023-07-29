using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private ICollection<IUniversity> models;

        public UniversityRepository()
        {
            this.models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => models.ToList().AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            //var university = this.models.FirstOrDefault(x=> x.Id == id);

            return this.models.FirstOrDefault(x => x.Id == id); ;
        }

        public IUniversity FindByName(string name)
        {
            //var university = this.models.FirstOrDefault(x => x.Name == name);

            return this.models.FirstOrDefault(x => x.Name == name); ;
        }
    }
}
