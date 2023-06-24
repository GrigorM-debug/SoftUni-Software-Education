using System.Runtime.CompilerServices;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            Team team = new Team("SoftUni");

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();

                int age = int.Parse(personArgs[2]);
                decimal salary = decimal.Parse(personArgs[3]);

                Person person = new Person(personArgs[0], personArgs[1], age, salary);

                persons.Add(person);
                
                //try
                //{
                //    Person person = new Person(personArgs[0],       personArgs[1], age, salary);

                //    people.Add(person);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");

            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
            //decimal percentage = decimal.Parse(Console.ReadLine());

            //foreach (Person person in people)
            //{
            //    person.IncreaseSalary(percentage);
            //    Console.WriteLine(person.ToString());
            //}
        }
    }
}