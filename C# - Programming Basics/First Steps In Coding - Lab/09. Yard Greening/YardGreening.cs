using System;

namespace _09._Yard_Greening
{
    internal class YardGreening
    {
        static void Main(string[] args)
        {
            double squareMetersForGreening = double.Parse(Console.ReadLine());
            double priceForOneSquereMeter = 7.61;
            double discout = 0.18; // Остъпката е 18%
            double price = squareMetersForGreening * priceForOneSquereMeter;
            double priceWithDiscount = price * discout;
            double finalPrice = price - priceWithDiscount;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discout is: {priceWithDiscount}");
        }
    }
}
