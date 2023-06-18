using System.Security.Cryptography.X509Certificates;

int[] toolsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] substancesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> tools = new(toolsInput);
Stack<int> substances = new(substancesInput);

HashSet<int> challenges = new HashSet<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));


while (challenges.Count > 0 && tools.Count > 0 && substances.Count > 0)
{
    int sum = tools.Peek() * substances.Peek();


    if (challenges.Contains(sum))
    {
        tools.Dequeue();
        substances.Pop();

        challenges.Remove(sum);
    }
    else
    {
        int currTool = tools.Dequeue();
        currTool += 1;
        tools.Enqueue(currTool);

        int currSubstance = substances.Pop();
        currSubstance -= 1;

        if (currSubstance > 0)
        {
            substances.Push(currSubstance);
        }
    }
}

if (challenges.Count == 0)
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
}
else if (tools.Count == 0 || substances.Count == 0)
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
}

if (tools.Count > 0)
{
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");
}

if (substances.Count > 0)
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}

if (challenges.Count > 0)
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}
