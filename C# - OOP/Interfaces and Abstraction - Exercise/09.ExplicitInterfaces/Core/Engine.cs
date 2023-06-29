using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                person.GetName();
                resident.GetName();
            }
        }
    }
}
