string text = Console.ReadLine();

string input = Console.ReadLine();

while (input != "Done")
{
    string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commandArgs[0];

    if (command == "Change")
    {
        string character = commandArgs[1];
        string replacement = commandArgs[2];

        text = text.Replace(character, replacement);

        Console.WriteLine(text);
    }
    else if (command== "Includes")
    {
        string substring = commandArgs[1];

        if (text.Contains(substring))
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
    else if (command == "End")
    {
        string substring = commandArgs[1];

        if (text.EndsWith(substring))
        {
            Console.WriteLine("True");
        }
        else 
        { 
            Console.WriteLine("False"); 
        }
    }
    else if (command == "Uppercase")
    {
        text = text.ToUpper();

        Console.WriteLine(text);
    }
    else if (command == "FindIndex")
    {
        char character = char.Parse(commandArgs[1]);

        int index = text.IndexOf(character);

        Console.WriteLine(index);
    }
    else if (command == "Cut")
    {
        int startIndex = int.Parse(commandArgs[1]);
        int countt = int.Parse(commandArgs[2]);

        string subs = text.Substring(startIndex, countt);

        Console.WriteLine(subs);
    }
    input = Console.ReadLine();
}