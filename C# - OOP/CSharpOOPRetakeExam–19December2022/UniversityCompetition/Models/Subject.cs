using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        //private int id;
        private string name;
        //private double rate;

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            this.Id= subjectId;
            this.Name=subjectName;
            this.Rate=subjectRate;
        }

        public int Id {get; set;}   

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public double Rate { get; private set; }
    }
}
