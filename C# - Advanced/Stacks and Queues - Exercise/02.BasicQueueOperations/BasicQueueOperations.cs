using System.Runtime.Serialization;

int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int numbersToPop = tokens[1];
int numbersToSearchFor = tokens[2];

Queue<int> queue = new Queue<int>(numbers);    

for (int i = 0; i < numbersToPop; i++)
{
    queue.Dequeue();
}


if (queue.Contains(numbersToSearchFor))
{
    Console.WriteLine("true");
}
else
{
    if (queue.Any())
    {
        Console.WriteLine(queue.Min());
    }
    else
    {
        Console.WriteLine(0);
    }
}
