using System;

namespace _07.FuelTank
{
    internal class FuelTank
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            int litters = int.Parse(Console.ReadLine());

            if (litters >= 25) 
            {
                switch (fuelType)
                {
                    case "Diesel":
                        Console.WriteLine($"You have enough diesel.");
                        break;
                    case "Gasoline":
                        Console.WriteLine($"You have enough gasoline.");
                        break;
                    case "Gas":
                        Console.WriteLine($"You have enough gas.");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;      
                }
            }
            else if (litters < 25)
            {
                switch (fuelType)
                {
                    case "Diesel":
                        Console.WriteLine($"Fill your tank with diesel!");
                        break;
                    case "Gasoline":
                        Console.WriteLine($"Fill your tank with gasoline!");
                        break;
                    case "Gas":
                        Console.WriteLine($"Fill your tank with gas!");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;
                }
            }
        }
    }
}
