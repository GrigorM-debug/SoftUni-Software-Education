using System;

namespace _01.ReadText
{
    internal class ReadText
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                Console.WriteLine(input);
              
                input = Console.ReadLine();
            }
        }
    }
}
