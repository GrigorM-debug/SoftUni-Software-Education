
using System.Data;

Func<List<int>, string, List<int>> mathOperation = (numbers, command) =>
{
    List<int> result= new List<int>();

    switch (command)
    {
        case "add":
            foreach(var number in numbers)
            {
                result.Add(number + 1);
            }
            break;
        case "multiply":
            foreach (var number in numbers)
            {
                result.Add(number * 2);
            }
            break;
        case "subtract":
            foreach (var number in numbers)
            {
                result.Add(number - 1);
            }
            break;

    }

    return result;
};


List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

string command;

while((command = Console.ReadLine()) != "end")
{
    if(command == "print")
    {
        Console.WriteLine($"{string.Join(" ", numbers)}");
    }
    else
    {
        numbers = mathOperation(numbers, command);  
    }
}