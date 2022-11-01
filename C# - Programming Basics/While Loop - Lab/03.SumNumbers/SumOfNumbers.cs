using System;

namespace _03.SumNumbers
{
    internal class SumOfNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            while (sum < n)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;

            }
            Console.WriteLine(sum);

        }
    }
}
