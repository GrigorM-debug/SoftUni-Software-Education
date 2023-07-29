using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;
        //private readonly IReadOnlyCollection<int> requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            this.Id= universityId;
            this.Name= universityName;
            this.Category = category;
            this.Capacity= capacity;
            this.RequiredSubjects = requiredSubjects.ToList().AsReadOnly();
        }

        public int Id {get; private set;}

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public string Category
        {
            get => this.category;
            private set
            {
                if(value.ToLower() != "technical" && value.ToLower() != "economical" && value.ToLower() != "humanity")
                {
                    throw new ArgumentException(ExceptionMessages.CategoryNotAllowed, value);
                }
                this.category = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects {get; private set;}
    }
}
