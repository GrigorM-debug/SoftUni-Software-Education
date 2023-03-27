using System.Linq.Expressions;
using System.Runtime.InteropServices;

string message = Console.ReadLine();

string input = Console.ReadLine();

while (input != "Reveal")
{
    string[] commandArgs = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

    string command = commandArgs[0];

    if (command == "InsertSpace")
    {
        string spaceToInsert = " ";
        int index = int.Parse(commandArgs[1]);
        message = message.Insert(index, spaceToInsert);

        Console.WriteLine(message);
    }
    else if (command == "Reverse")
    {
        string substring = commandArgs[1];

        if (message.Contains(substring))
        {
            string reversedString = string.Empty;
            int substringIndex = message.IndexOf(substring);
            message = message.Remove(substringIndex, substring.Length);
            
            for (int i = substring.Length - 1; i>= 0; i--)
            {
                reversedString += substring[i];
            }
            message = message.Insert(substringIndex, reversedString);
        }
        else
        {
            Console.WriteLine("error");
        }
        Console.WriteLine(message);
    }
    else if (command == "ChangeAll")
    {
        string substring = commandArgs[1];
        string replaceString = commandArgs[2];

       message = message.Replace(substring, replaceString);

        Console.WriteLine(message);
    }
    input = Console.ReadLine();
}
Console.WriteLine($"You have a new text message: {message}");