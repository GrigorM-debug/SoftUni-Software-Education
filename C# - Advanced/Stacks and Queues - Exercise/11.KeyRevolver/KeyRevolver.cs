int priceForBullets = int.Parse(Console.ReadLine());
int sizeOfGunBarrel = int.Parse(Console.ReadLine());

Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());    

Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

int intelligence = int.Parse(Console.ReadLine());

int currSizeOfBarrel = sizeOfGunBarrel;

int currBulletsCount = bullets.Count;

for (int i = 0; i < currBulletsCount; i++)
{
    if (bullets.Pop() <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    currSizeOfBarrel--;

    if (currSizeOfBarrel == 0 && bullets.Any())
    {
        Console.WriteLine("Reloading!");
        currSizeOfBarrel= sizeOfGunBarrel;
    }

    if (!bullets.Any() && locks.Any())
    {
        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        return;
    }
    else if (!locks.Any())
    {
        Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (currBulletsCount - bullets.Count) * priceForBullets}");
        return;
    }
}