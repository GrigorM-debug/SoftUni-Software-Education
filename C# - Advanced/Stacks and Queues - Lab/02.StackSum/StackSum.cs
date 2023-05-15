int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> stackOfNumbers = new Stack<int>(inputNumbers);

string command = Console.ReadLine().ToLower();

while(command != "end")
{
    string[] commandInfo = command.Split();

    if (commandInfo[0] == "add")
    {
        int[] numbers = commandInfo.Skip(1).Select(int.Parse).ToArray();

        foreach(var number in numbers)
        {
            stackOfNumbers.Push(number);
        }

    }
    else if (commandInfo[0] == "remove")
    {
        int n = int.Parse(commandInfo[1]);

        //if (stackOfNumbers.Count > n) // This is the second way for remove command
        //{
        //    while(n > 0)
        //    {
        //        stackOfNumbers.Pop();
        //        n--;
        //    }
        //}

        while (stackOfNumbers.Count > n && n > 0)
        {
            stackOfNumbers.Pop();
            n--;
        }
    }
    command = Console.ReadLine().ToLower();
}
Console.WriteLine($"Sum: {stackOfNumbers.Sum()}");