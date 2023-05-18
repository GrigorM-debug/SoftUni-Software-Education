Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int rackCapasity = int.Parse(Console.ReadLine());

int racksCount = 1;

int currRackCapasity = rackCapasity;

while (clothes.Any())
{
    currRackCapasity -= clothes.Peek();

    if (currRackCapasity < 0)
    {
        currRackCapasity = rackCapasity;
        racksCount++;
        continue;
    }
    clothes.Pop();
}
Console.WriteLine(racksCount);