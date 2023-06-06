using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DefiningClasses
{
    public class Family
    {
        private List<Person> persons;

        public Family() 
        { 
            persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public void AddMember(Person person)
        {
            persons.Add(person);
        }

        public Person GetOldestMember()
        {
            return persons.OrderByDescending(p => p.Age).First();
            //return persons.MaxBy(p => p.Age);
        }
    }
}
