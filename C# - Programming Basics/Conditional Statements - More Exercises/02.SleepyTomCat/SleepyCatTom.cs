using System;

namespace _02.SleepyTomCat
{
    internal class SleepyCatTom
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());

            int tomYearPlayingTime = 30000;

            int workingDays = 365 - restDays;
            int timePlaying = workingDays * 63 + restDays * 127;

            if (timePlaying > tomYearPlayingTime)
            {
                int difference = timePlaying- tomYearPlayingTime;
                int differenceInHours = difference / 60;
                differenceInHours = Math.Abs(differenceInHours);
                int differenceInMinutes = difference%60;
                differenceInMinutes= Math.Abs(differenceInMinutes); 
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{differenceInHours} hours and {differenceInMinutes} minutes more for play");
            }
            else if (timePlaying < tomYearPlayingTime)
            {
                int difference = tomYearPlayingTime - timePlaying;  
                int differenceInHours = difference / 60;
                differenceInHours = Math.Abs(differenceInHours);
                int differenceInMinutes = difference%60;
                differenceInMinutes = Math.Abs(differenceInMinutes);
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{differenceInHours} hours and {differenceInMinutes} minutes less for play");
            }

        }
    }
}
