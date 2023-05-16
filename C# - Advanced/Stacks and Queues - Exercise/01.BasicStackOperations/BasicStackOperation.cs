using System.Runtime.Serialization;

int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int numbersToPop = tokens[1];
int numbersToSearchFor = tokens[2];

Stack<int> stack = new Stack<int>(numbers);

for (int i = 0; i < numbersToPop; i++)
{
    stack.Pop();
}


if (stack.Contains(numbersToSearchFor))
{
    Console.WriteLine("true");
}
else
{
    if (stack.Any())
    {
        Console.WriteLine(stack.Min());
    }
    else
    {
        Console.WriteLine(0);
    }
}
