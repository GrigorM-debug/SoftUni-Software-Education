using _05.ComparingObjects;
using System.Net.Http.Headers;

List<Person> list = new List<Person>();

string command;
while((command = Console.ReadLine()) != "END")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Person person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);

    list.Add(person);
}


int personToCompareIndex = int.Parse(Console.ReadLine()) - 1;

int equalCount = 0;
int differentCount = 0;

int totalPeopleCount = list.Count;

Person personToCompare = list[personToCompareIndex];

foreach(var person in list)
{
    if(person.CompareTo(personToCompare) == 0)
    {
        equalCount++;
    }
    else
    {
        differentCount++;
    }
}

if(equalCount == 1)
{
    Console.WriteLine("No matches");
}
else
{
    Console.WriteLine($"{equalCount} {differentCount} {totalPeopleCount}");
}