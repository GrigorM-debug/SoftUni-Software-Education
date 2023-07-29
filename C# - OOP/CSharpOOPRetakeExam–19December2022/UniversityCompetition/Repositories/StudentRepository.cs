using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private ICollection<IStudent> models;

        public StudentRepository()
        {
            this.models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models.ToList().AsReadOnly();

        public void AddModel(IStudent model)
        {
            this.models.Add(model);
        }

        public IStudent FindById(int id)
        {
            var student = this.models.FirstOrDefault(x=> x.Id == id);

            return student;
        }

        public IStudent FindByName(string name)
        {
            // Split the full name into first and last names using the space character as the separator
            string[] names = name.Split(' ');

                string firstName = names[0];
                string lastName = names[1];

                // Assuming 'students' is a collection of Student objects (e.g., a list or an array)
                // Check if a student with the given first and last names exists in the repository
                var student = this.models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

                return this.models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName); 
            
        }
    }
}
