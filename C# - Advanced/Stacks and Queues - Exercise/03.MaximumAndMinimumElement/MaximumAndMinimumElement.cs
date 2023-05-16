using System.ComponentModel;

int queries = int.Parse(Console.ReadLine());

Stack<int> elements = new Stack<int>(); 

for (int i = 0; i < queries; i++)
{
    int[] commandArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

    if (commandArgs[0] == 1)
    {
        int elementToPush = commandArgs[1];
        elements.Push(elementToPush);
    }
    else if (commandArgs[0] == 2)
    {
        elements.Pop();
    }
    else if (commandArgs[0] == 3)
    {
        if (elements.Any())
        {
            Console.WriteLine(elements.Max());
        }
    }
    else if (commandArgs[0] == 4)
    {
        if (elements.Any())
        {
            Console.WriteLine(elements.Min());
        }
    }
}
Console.WriteLine(string.Join(", ", elements));