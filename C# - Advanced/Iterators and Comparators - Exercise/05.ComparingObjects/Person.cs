using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person personToCompare)
        {
            int result = Name.CompareTo(personToCompare.Name);

            if (result != 0)
            {
                return result;
            }
            
            result = Age.CompareTo(personToCompare.Age);

            if (result != 0)
            {
                return result;
            }

            return Town.CompareTo(personToCompare.Town);
        }
    }
}
