using System;

namespace _01._USD_to_BGN
{
    internal class USDToBGN
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double oneUSDToBGN = 1.79549;
            double bgn = usd * oneUSDToBGN;
            Console.WriteLine(bgn);
        }
    }
}
