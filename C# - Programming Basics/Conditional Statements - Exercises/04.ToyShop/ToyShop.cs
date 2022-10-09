using System;
using System.Diagnostics;

namespace _04.ToyShop
{
    internal class ToyShop
    {
        static void Main(string[] args)
        {
            double  tripPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());   
            int trucksCount = int.Parse(Console.ReadLine());
            int toysCount = puzzleCount + dollsCount + bearsCount + minionsCount + trucksCount;
            
            double puzzlePrice = puzzleCount * 2.60;
            double dollsPrice = dollsCount * 3;
            double bearsPrice = bearsCount * 4.10;
            double miniosPrice = minionsCount * 8.20;
            double trucksPrice = trucksCount * 2;
            double totalPrice = puzzlePrice + dollsPrice + bearsPrice + miniosPrice + trucksPrice;

            if (toysCount >= 50)
            {
                totalPrice = totalPrice - totalPrice * 0.25;
            }
            totalPrice =  totalPrice - totalPrice * 0.10;
            
            if (totalPrice >= tripPrice)
            {
                totalPrice = totalPrice - tripPrice;
                Console.WriteLine($"Yes! {totalPrice:f2} lv left.");
            }
            else if (totalPrice < tripPrice)
            {
                totalPrice = tripPrice - totalPrice;
                Console.WriteLine($"Not enough money! {totalPrice:f2} lv needed.");
            }
        }
    }
}
