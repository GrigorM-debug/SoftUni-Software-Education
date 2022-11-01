using System;

namespace _06.MaxNumber
{
    internal class MaxNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int maxNumber = int.MinValue;
            
            while(number != "Stop")
            {
                int currectNumber = int.Parse(number);
                if (currectNumber > maxNumber)
                {
                    maxNumber = currectNumber;
                }
                number = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
