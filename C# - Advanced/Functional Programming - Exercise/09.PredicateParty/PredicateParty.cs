

List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

string command;
while((command = Console.ReadLine()) != "Party!")
{
    string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string action = commandArgs[0];
    string filter = commandArgs[1];
    string value = commandArgs[2];

    if(action == "Remove")
    {
        people.RemoveAll(GetPredicate(filter, value));
    }
    else
    {
        List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));

        foreach(var person in peopleToDouble)
        {
            int index = peopleToDouble.IndexOf(person);

            people.Insert(index, person);
        }
    }
}

if (people.Any())
{
    Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> GetPredicate (string filter, string value)
{
    switch (filter)
    {
        case "StartsWith":
            return n => n.StartsWith(value);
        case "EndsWith":
            return n => n.EndsWith(value);
        case "Length":
            return n => n.Length == int.Parse(value);
        default:
            return default; // return null
    }
}