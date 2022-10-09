using System;

namespace _03.Time_15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            minute = minute + (hour * 60);
            int minutesAfter15Min = minute + 15;
            int hAfter = minutesAfter15Min / 60;
            int minAfter = minutesAfter15Min % 60;
        
            if (hAfter > 23)
            {
                hAfter = 0;
            }
            else if (minAfter < 10)
            {
                Console.WriteLine($"{hAfter}:0{minAfter}");
            }
            else
            {
                Console.WriteLine($"{hAfter}:{minAfter}");
            }
        }
    }
}
