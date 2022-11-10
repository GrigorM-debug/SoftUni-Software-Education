using System;

namespace _04.SumOfTwoNumbers
{
    internal class SumOfTwoNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;
            bool yes = true;
            for (int i = start; i <= finish; i++)
            {
                for (int j = start; j <= finish; j++)
                {
                    sum = i + j;
                    counter++;
                    if (sum == n)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {n})");
                        i = finish;
                        yes = false;
                    }
                }
            }
            if (yes)
            {
                Console.WriteLine($"{counter} combinations - neither equals {n}");
            }
            
        }
    }
}
