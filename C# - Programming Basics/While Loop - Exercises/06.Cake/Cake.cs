using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeHeight = int.Parse(Console.ReadLine());
            int cakeSize = cakeWidth * cakeHeight;
            int cakePieces = 0;
            string input = Console.ReadLine();


            while (input != "STOP")
            {
                cakePieces += int.Parse(input);

                if (cakePieces>cakeSize)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            int diff = cakeSize - cakePieces;

            if (input == "STOP" && diff >= 0)
            {
                Console.WriteLine($"{diff} pieces are left.");    
            }
            else
            {
                 Console.WriteLine($"No more cake left! You need {Math.Abs(diff)} pieces more.");
            }
        }
    }
}
