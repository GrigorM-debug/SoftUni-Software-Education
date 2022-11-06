using System;

namespace _07.Moving
{
    internal class Moving
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());  
            int h = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int cubicMeters = 0;
            int leftSpace = w * l * h;

            while (input != "Done")
            {
                cubicMeters += int.Parse(input);

                if (cubicMeters > leftSpace)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            int diff = leftSpace - cubicMeters;

            if (diff >= 0)
            {
                Console.WriteLine($"{diff} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(diff)} Cubic meters more.");
            }
        }
    }
}
