using System.Net.Http.Headers;

List<Person> people = new List<Person>();

int numberOfInputs = int.Parse(Console.ReadLine()); 

for (int i =0; i < numberOfInputs; i++)
{
    string[] tokens = Console.ReadLine().Split(", ");
    string name = tokens[0];
    int age = int.Parse(tokens[1]);

    people.Add(new Person() { Name = name, Age = age});
}

string filterType = Console.ReadLine(); 
int ageFilter = int.Parse(Console.ReadLine());  
string formatType = Console.ReadLine();

Func<Person, bool> filter = GetFilter(filterType, ageFilter);

people= people.Where(filter).ToList();

Action<Person> printer = GetPrinter(formatType);

foreach (var person in people)
{
    printer(person);
}

Func<Person, bool> GetFilter(string filterType, int age)
{
    switch(filterType)
    {
        case "older":
            return person => person.Age >= age;
        case "younger":
            return person => person.Age < age;
        default:
            return null;
    }
}

Action<Person> GetPrinter (string formatType)
{
    switch(formatType)
    {
        case "name age":
        return person => Console.WriteLine($"{person.Name} - {person.Age}");
        case "name":
            return person => Console.WriteLine($"{person.Name}");
        case "age":
            return person => Console.WriteLine($"{person.Age}");
        default:
            return null;
    }
}

class Person
{
    public string Name;
    public int Age; 
}