using System;

namespace _11._Fruit_Shop
{
    internal class FruitShop
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double price = 0.0;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Friday":
                    switch (fruit)
                    {
                        case "banana":
                            price = amount * 2.50;
                            break;
                        case "apple":
                            price = amount * 1.20;
                            break;
                        case "orange":
                            price = amount * 0.85;
                            break;
                        case "grapefruit":
                            price = amount * 1.45;
                            break;
                        case "kiwi":
                            price = amount * 2.70;
                            break;
                        case "pineapple":
                            price = amount * 5.50;
                            break;
                        case "grapes":
                            price = amount * 3.85;
                                break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            price = amount * 2.70;
                            break;
                        case "apple":
                            price = amount * 1.25;
                            break;
                        case "orange":
                            price = amount * 0.90;
                            break;
                        case "grapefruit":
                            price = amount * 1.60;
                            break;
                        case "kiwi":
                            price = amount * 3.00;
                            break;
                        case "pineapple":
                            price = amount * 5.60;
                            break;
                        case "grapes":
                            price = amount * 4.20;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break ;
                    }
                    break;
                    default:
                    Console.WriteLine("Error");
                      break;
            }

            Console.WriteLine("{0:F2}", price);
        }
    }
}
