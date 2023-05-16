using System;
using System.Data;

int quantityOfFood = int.Parse(Console.ReadLine());

Queue<int> orders = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Console.WriteLine(orders.Max());

while (orders.Any())
{
    quantityOfFood -= orders.Peek();

    if (quantityOfFood < 0)
    {
        break;
    }
    else
    {
        orders.Dequeue();
    }
}
if (orders.Any())
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}