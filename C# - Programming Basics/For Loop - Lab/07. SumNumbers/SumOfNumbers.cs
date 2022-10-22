using System;

namespace _07._SumNumbers
{
    internal class SumOfNumbers
    {
        static void Main(string[] args)
        {
            int numbersCnt = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numbersCnt; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
