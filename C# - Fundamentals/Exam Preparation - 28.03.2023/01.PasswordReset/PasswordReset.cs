using System.Security;
using System.Text;

string password = Console.ReadLine();

string input = Console.ReadLine();

while (input != "Done")
{
    string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commandArgs[0];

    if (command == "TakeOdd")
    {
        string odd = string.Empty;
        for (int i =0; i < password.Length; i++)
        {
            if (i % 2 != 0)
            {
                odd += password[i];
            }
        }
        Console.WriteLine(odd);
        password = odd;
    }
    else if (command == "Cut")
    {
        int index = int.Parse(commandArgs[1]);
        int lenght = int.Parse(commandArgs[2]);

        password = password.Remove(index, lenght);

        Console.WriteLine(password);
    }
    else if (command == "Substitute")
    {
        string substring = commandArgs[1];
        string stringForReplacemnt = commandArgs[2];
        if (password.Contains(substring))
        {
            password = password.Replace(substring, stringForReplacemnt);

            Console.WriteLine(password);
        }
        else
        {
            Console.WriteLine("Nothing to replace!");
        }
    }
    input = Console.ReadLine();
}

Console.WriteLine($"Your password is: {password}");