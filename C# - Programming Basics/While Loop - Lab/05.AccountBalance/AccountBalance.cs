using System;

namespace _05.AccountBalance
{
    internal class AccountBalance
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            double sum = 0;

            while (n != "NoMoreMoney")
            {
                double amount = double.Parse(n);
                if (amount >= 0)
                {
                    sum = sum + amount;
                    Console.WriteLine($"Increase: {amount:f2}");
                    n = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
