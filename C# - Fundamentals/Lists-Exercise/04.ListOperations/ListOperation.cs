List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

string command = Console.ReadLine();

while (command != "End")
{
    string[] commandInfo = command.Split(" ");

    if (commandInfo[0] == "Add")
    {
        int number = int.Parse(commandInfo[1]);
        numbers.Add(number);
        
    }
    else if (commandInfo[0] == "Insert")
    {
        int number = int.Parse(commandInfo[1]);
        int index = int.Parse(commandInfo[2]);
        if (index < 0 || index >= numbers.Count)
        {
            Console.WriteLine("Invalid index");
        }
        else
        {
            numbers.Insert(index, number);
        }
    }
    else if (commandInfo[0] == "Remove")
    {
        int index = int.Parse(commandInfo[1]);
        if (index < 0 || index >= numbers.Count)
        {
            Console.WriteLine("Invalid index");
        }
        else
        {
            numbers.RemoveAt(index);
        }
    }
    else if (commandInfo[0] == "Shift")
    {
        if (commandInfo[1] == "left")
        {
            int count = int.Parse(commandInfo[2]);
            for (int i = 0; i < count; i++)
            {
                int firstNum = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(firstNum);
            }
        }
        else if (commandInfo[1] == "right")
        {
            int count = int.Parse(commandInfo[2]);
            for (int i = 0; i < count; i++)
            {
                int lastNum = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastNum);
            }
        }
    }
    command = Console.ReadLine();
}
Console.WriteLine(string.Join(" ", numbers));