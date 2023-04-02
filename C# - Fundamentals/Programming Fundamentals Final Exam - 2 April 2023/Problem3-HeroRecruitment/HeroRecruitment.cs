using System.Reflection.Metadata;
using System.Linq;
using System.Collections.Generic;

string input = Console.ReadLine();

Dictionary<string, List<string>> heroes = new Dictionary<string, List<String>>();   

while (input != "End")
{
    string[] commandArgs = input.Split();

    string command = commandArgs[0];

    if (command == "Enroll")
    {
        string name = commandArgs[1];
        if (!heroes.ContainsKey(name))
        {
            heroes[name] = new List<string>();
        }
        else
        {
            Console.WriteLine($"{name} is already enrolled.");
        }
    }
    else if (command == "Learn")
    {
        string name = commandArgs[1];
        string spellName = commandArgs[2];

        if (heroes.ContainsKey(name))
        {
            if (!heroes[name].Contains(spellName))
            {
                heroes[name].Add(spellName);
            }
            else
            {
                Console.WriteLine($"{name} has already learnt {spellName}.");
            }
        }
        else
        {
            Console.WriteLine($"{name} doesn't exist.");
        }
    }
    else if (command == "Unlearn")
    {
        string name = commandArgs[1];
        string spellName = commandArgs[2];

        if (!heroes.ContainsKey(name))
        {
            Console.WriteLine($"{name} doesn't exist.");
        }
        else if (!heroes[name].Contains(spellName))
        {
            Console.WriteLine($"{name} doesn't know {spellName}.");
        }
        else
        {
            heroes[name].Remove(spellName);
        }
    }
    input = Console.ReadLine();
}
Console.WriteLine("Heroes:");
foreach (var (hero,spell) in heroes)
{
    Console.WriteLine($"== {hero}: {string.Join(", ", spell)}");
}



