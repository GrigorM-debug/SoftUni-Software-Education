using System;

namespace _01.Oscars_ceremony
{
    internal class OscarCeremony
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statuettePrice = rent - rent * 0.30;
            double cateringPrice = statuettePrice - statuettePrice * 0.15;
            double soundingPrice = cateringPrice / 2;
            double totalPrice = rent + statuettePrice + cateringPrice + soundingPrice;

            Console.WriteLine($"{totalPrice:f2}");  
        }
    }
}
