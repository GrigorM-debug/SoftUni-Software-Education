using System;

namespace _07._Food_Delivery
{
    internal class FoodDelivery
    {
        static void Main(string[] args)
        {
            //Вход
            int numberChickenMenus = int.Parse(Console.ReadLine());
            int numberFishMenus = int.Parse(Console.ReadLine());
            int numberVegeterianMenus = int.Parse(Console.ReadLine());
            //Цени
            double chickeOneMenuPrice = 10.35;
            double fishOneMenuPrice = 12.40;
            double vegeterianOneMenuPrice = 8.15;
            double deliveryPrice = 2.50;
            //Изчисления
            double chickenMenuPrice = numberChickenMenus * chickeOneMenuPrice;
            double fishMenuPrice = numberFishMenus * fishOneMenuPrice;
            double vegeterianMenuPrice = numberVegeterianMenus * vegeterianOneMenuPrice;    
            double menusTotalPrice = chickenMenuPrice + fishMenuPrice + vegeterianMenuPrice;
            double dessertPrice = (20*menusTotalPrice) / 100;
            double totalSum = menusTotalPrice + dessertPrice + deliveryPrice;
            Console.WriteLine(totalSum);

        }
    }
}
