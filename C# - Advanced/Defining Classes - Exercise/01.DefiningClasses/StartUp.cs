using _01.DefiningClasses;
using System;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        //Person person = new Person();
        //person.Name = "Gosho";
        //person.Age = 10;

        //Person person2 = new Person()
        //{
        //    Name = "Ivan",
        //    Age = 16
        //};

        //Person noNameDefault = new Person();
        //Person noNameWithAge = new Person(45);
        //Person withNameAndAge = new Person("Pesho", 80);

        //Console.WriteLine($"{person.Name} {person.Age}");
        //Console.WriteLine($"{person2.Name} {person2.Age}");

        //Console.WriteLine($"{noNameDefault.Name} {noNameDefault.Age}");
        //Console.WriteLine($"{noNameWithAge.Name} {noNameWithAge.Age}");
        //Console.WriteLine($"{withNameAndAge.Name} {withNameAndAge.Age}");

        List<Person> personOver30 = new List<Person>();

        Family family = new Family();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] peoples = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = peoples[0];
            int age = int.Parse(peoples[1]);

            Person person = new Person(name, age);
            if (person.Age > 30)
            {
                personOver30.Add(person);
            }

            family.AddMember(person);
        }

        //Person oldes= family.GetOldestMember();

        //Console.WriteLine($"{oldes.Name} {oldes.Age}");


        foreach(var person in personOver30.OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}