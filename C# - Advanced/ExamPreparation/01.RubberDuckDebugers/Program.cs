
int[] programmerTime = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] programmerTask = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> times = new Queue<int>(programmerTime);

Stack<int> tasks = new Stack<int>(programmerTask);

Dictionary<string, int> awards = new Dictionary<string, int>
{
    {"Darth Vader Ducky", 0},
    {"Thor Ducky", 0},
    {"Big Blue Rubber Ducky", 0},
    {"Small Yellow Rubber Ducky", 0}
};

while(times.Any() && tasks.Any())
{
    int sum = times.Peek() * tasks.Peek();

    if(sum >= 0 && sum <= 60)
    {
        awards["Darth Vader Ducky"]++;

        times.Dequeue();
        tasks.Pop();
    }
    else if (sum >= 61 && sum <= 120)
    {
        awards["Thor Ducky"]++;

        times.Dequeue();
        tasks.Pop();
    }
    else if(sum >= 121 && sum <= 180)
    {
        awards["Big Blue Rubber Ducky"]++;

        times.Dequeue();
        tasks.Pop();
    }
    else if (sum >= 181 && sum <= 240)
    {
        awards["Small Yellow Rubber Ducky"]++;

        times.Dequeue();
        tasks.Pop();
    }
    else
    {
        int currTask = tasks.Pop();
        currTask -= 2;

        tasks.Push(currTask);
        int currTime = times.Dequeue();
        times.Enqueue(currTime);
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach (var award in awards)
{
    Console.WriteLine($"{award.Key}: {award.Value}");
}