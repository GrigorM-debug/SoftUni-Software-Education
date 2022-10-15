﻿using System;

namespace _09._Fruit_or_Vegetable
{
    internal class FruitOrVegetable
    {
        static void Main(string[] args)
        {
            string fruitType = Console.ReadLine();

            switch(fruitType)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
