string message = Console.ReadLine();

string input = Console.ReadLine();

while (input != "Decode")
{
    string[] commandInfo = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

    string command = commandInfo[0];

    if (command == "Move")
    {
        int numberOfLetters = int.Parse(commandInfo[1]);
        string substring = message.Substring(0, numberOfLetters);
        message = message.Remove(0, numberOfLetters);
        message += substring;

    }
    else if (command == "Insert")
    {
        int index = int.Parse(commandInfo[1]);
        string value = commandInfo[2];  

        message = message.Insert(index, value);
    }
    else if (command == "ChangeAll")
    {
        string substring = commandInfo[1];
        string replacement = commandInfo[2];

        message = message.Replace(substring, replacement);
    }
    input = Console.ReadLine();
}

Console.WriteLine($"The decrypted message is: {message}");