using System;

namespace _07.MinNumber
{
    internal class MinNumber
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (input != "Stop")
            {
                int currectNumber = int.Parse(input);

                if (currectNumber < minNumber)
                {
                    minNumber = currectNumber;  
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}
