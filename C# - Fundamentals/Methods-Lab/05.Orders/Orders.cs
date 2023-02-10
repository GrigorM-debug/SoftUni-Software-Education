using System;
using System.Linq.Expressions;
using System.Security.Principal;

namespace _05.Orders
{
    internal class Orders
    {
        static void Main()
        {
            string product = Console.ReadLine();    
            int quantity = int.Parse(Console.ReadLine());

            ProductPrice(product, quantity);
        }

        static void ProductPrice(string product, int quantity)
        {
            decimal totalPrice = 0.0m;

            switch (product)
            {
                case "coffee":
                    decimal coffePrice = 1.50m;
                    totalPrice = coffePrice * quantity;
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                case "water":
                    decimal waterPrice = 1.0m;
                    totalPrice = waterPrice * quantity;
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                case "coke":
                    decimal cokePrice = 1.40m;
                    totalPrice = cokePrice * quantity;
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                case "snacks":
                    decimal snacksPrice = 2.00m;
                    totalPrice = snacksPrice * quantity;
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
            }
        }
    }
}
