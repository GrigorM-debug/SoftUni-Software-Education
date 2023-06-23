namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();

                int age = int.Parse(personArgs[2]);
                decimal salary = decimal.Parse(personArgs[3]);
                Person person = new Person(personArgs[0], personArgs[1], age, salary);

                people.Add(person);
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (var person in people)
            {
                person.IncreaseSalary(percentage);
                Console.WriteLine(person.ToString());
            }
        }
    }
}