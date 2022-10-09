using System;

namespace _01.SumSeconds
{
    internal class SumSeconds
    {
        static void Main(string[] args)
        {
            //Input
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            //Actions
            int totalTime = firstTime + secondTime + thirdTime;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;
           
            //Output
            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
