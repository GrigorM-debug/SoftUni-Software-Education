using System.Data.Common;
using System.Linq;

List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

string command = Console.ReadLine();

bool isChaged = false;

while (command != "end")
{
    string[] commandInfo = command.Split();

    if (commandInfo[0] == "Add")
    {
        int number = int.Parse(commandInfo[1]);
        numbers.Add(number);
        isChaged = true;
    }
    else if (commandInfo[0] == "Remove")
    {
        int number = int.Parse(commandInfo[1]);
        numbers.Remove(number);
        isChaged = true;
    }
    else if (commandInfo[0] == "RemoveAt")
    {
        int index = int.Parse(commandInfo[1]);
        numbers.RemoveAt(index);
        isChaged = true;
    }
    else if (commandInfo[0] == "Insert")
    {
        int number = int.Parse(commandInfo[1]);
        int index = int.Parse(commandInfo[2]);
        numbers.Insert(index, number);
        isChaged = true;
    }
    else if (commandInfo[0] == "Contains")
    {
        int number = int.Parse(commandInfo[1]);
        if (numbers.Contains(number))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No such number");
        }
    }    
    else if (commandInfo[0] == "PrintEven")
    {
        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
    }
    else if (commandInfo[0] == "PrintOdd")
    {
     
        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
    }
    else if (commandInfo[0] == "GetSum")
    {
        Console.WriteLine(string.Join(" ", numbers.Sum()));
    }
    else if (commandInfo[0] == "Filter")
    {
        string operators = commandInfo[1];
        int number = int.Parse(commandInfo[2]);

        if (operators == ">")
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x > number)));
        }
        else if (operators == "<") 
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x < number)));
        }
        else if (operators == ">=")
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x >= number)));
        }
        else if (operators == "<=")
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x <= number)));
        }   
    }
    command = Console.ReadLine();
}
if (isChaged)
{
    Console.WriteLine(string.Join(" ", numbers));
}
