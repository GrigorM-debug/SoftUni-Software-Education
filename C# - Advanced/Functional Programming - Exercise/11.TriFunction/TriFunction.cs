using System.Net.NetworkInformation;

// Logically it can be solve by prdicate but SoftUni wants Func in Func
Func<string, int, bool> validName = (name, validSum) =>
{
    int nameCharSum = name.Sum(ch => ch);

    return nameCharSum >= validSum;
};

Func<string[], Func<string, int, bool>, int, string> getFirstName = (names, validName, validSum) =>
{
    foreach(var name in names)
    {
        if(validName(name, validSum))
        {
            return name;
        }
    }

    return null;
};

int validSum = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

string foundName = getFirstName(names, validName, validSum);

Console.WriteLine(foundName);