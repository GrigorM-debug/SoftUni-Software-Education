using Microsoft.Win32.SafeHandles;

decimal balance = 0.0m;

while (true)
{
    string input = Console.ReadLine();

    if (input == "Start")
    {
        break;
    }
    decimal coin = decimal.Parse(input);
    if (coin == 0.1m || coin == 0.2m || coin == 0.5m || coin == 1m || coin == 2m)
    {
        balance += coin;
    }
    else
    {
        Console.WriteLine($"Cannot accept {coin}");
    }
}
while (true)
{
    string input = Console.ReadLine();
    if (input == "End")
    {
        break;
    }
    if (input == "Nuts")
    {
        if (balance >= 2m)
        {
            balance -= 2m;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Water")
    {
        if (balance >=0.7m)
        {
            balance-= 0.7m;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Crisps")
    {
        if (balance >= 1.5m)
        {
            balance -= 1.5m;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Soda")
    {
        if (balance >= 0.8m)
        {
            balance -= 0.8m;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else if (input == "Coke")
    {
        if (balance >= 1.0m)
        {
            balance -= 1.0m;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }
    else
    {
        Console.WriteLine("Invalid product");
    }
}
Console.WriteLine($"Change: {balance:f2}");