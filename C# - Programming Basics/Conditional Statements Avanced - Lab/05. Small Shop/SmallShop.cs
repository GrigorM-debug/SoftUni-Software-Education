﻿using System;

namespace _05._Small_Shop
{
    internal class SmallShop
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double sum = 0.0;

            switch (town)
            {
                case "Sofia":
                    switch (product)
                    {
                        case "coffee":
                            sum = 0.50 * amount;
                            break;
                        case "water":
                            sum = 0.80 * amount;
                            break;
                        case "beer":
                            sum = 1.20 * amount;
                            break;
                        case "sweets":
                            sum = 1.45 * amount;
                            break;
                        case "peanuts":
                            sum = 1.60 * amount;
                            break;
                    }
                    break;
                case "Plovdiv":
                    switch (product)
                    {
                        case "coffee":
                            sum = 0.40 * amount;
                            break;
                        case "water":
                            sum = 0.70 * amount;
                            break;
                        case "beer":
                            sum = 1.15 * amount;
                            break;
                        case "sweets":
                            sum = 1.30 * amount;
                            break;
                        case "peanuts":
                            sum = 1.50 * amount;
                            break;
                    }
                    break;
                case "Varna":
                    switch (product)
                    {
                        case "coffee":
                            sum = 0.45 * amount;
                            break;
                        case "water":
                            sum = 0.70 * amount;
                            break;
                        case "beer":
                            sum = 1.10 * amount;
                            break;
                        case "sweets":
                            sum = 1.35 * amount;
                            break;
                        case "peanuts":
                            sum = 1.55 * amount;
                            break;
                    }
                    break;
            }
            
            Console.WriteLine(sum);
        }
    }
}
