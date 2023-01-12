string typeOfDay = Console.ReadLine();
int personAge = int.Parse(Console.ReadLine());
double price = 0.0;

switch (typeOfDay)
{
    case "Weekday":
        if (0<= personAge && personAge <=18)
        {
            price = 12;
            Console.WriteLine($"{price}$");
        }
        else if (18< personAge && personAge <=64)
        {
            price = 18;
            Console.WriteLine($"{price}$");
        }
        else if (64<personAge && personAge <= 122)
        {
            price = 12;
            Console.WriteLine($"{price}$");
        }
        else
        {
            Console.WriteLine("Error!");
        }
        break;
    case "Weekend":
        if (0 <= personAge && personAge <= 18) 
        {
            price = 15;
            Console.WriteLine($"{price}$");
        }
        else if (18 < personAge && personAge <= 64)
        {
            price = 20;
            Console.WriteLine($"{price}$");
        }
        else if (64 < personAge && personAge <= 122)
        {
            price = 15;
            Console.WriteLine($"{price}$");
        }
        else
        {
            Console.WriteLine("Error!");
        }
        break;
    case "Holiday":
        if (0 <= personAge && personAge <= 18)
        {
            price = 5;
            Console.WriteLine($"{price}$");
        }
        else if (18 < personAge && personAge <= 64)
        {
            price = 12;
            Console.WriteLine($"{price}$");
        }
        else if (64 < personAge && personAge <= 122)
        {
            price = 10;
            Console.WriteLine($"{price}$");
        }
        else
        {
            Console.WriteLine("Error!");
        }
        break;
}