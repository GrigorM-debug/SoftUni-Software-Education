string[] names = Console.ReadLine().Split();

int n = int.Parse(Console.ReadLine());

Queue<string> hotPotato = new Queue<string>(names);

while(hotPotato.Count > 1)
{
    for(int i = 1; i < n; i++)
    {
        hotPotato.Enqueue(hotPotato.Dequeue());
    }
    Console.WriteLine($"Removed {hotPotato.Dequeue()}");
}
Console.WriteLine($"Last is {hotPotato.Peek()}");