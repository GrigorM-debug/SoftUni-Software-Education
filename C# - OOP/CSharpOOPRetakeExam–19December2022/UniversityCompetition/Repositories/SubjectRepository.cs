using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private ICollection<ISubject> models;

        public SubjectRepository()
        {
            this.models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => models.ToList().AsReadOnly();

        public void AddModel(ISubject model)
        {
            this.models.Add(model);
        }

        public ISubject FindById(int id)
        {
            //var subject = models.FirstOrDefault(x => x.Id == id);

            return models.FirstOrDefault(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            //var subject= models.FirstOrDefault(x => x.Name == name);

            return models.FirstOrDefault(x => x.Name == name); 
        }
    }
}
