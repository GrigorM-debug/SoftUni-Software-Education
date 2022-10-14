using System;
using System.Linq.Expressions;

namespace _08._Lunch_Break
{
    internal class LunchBreak
    {
        static void Main(string[] args)
        {
            string tvSeriesName = Console.ReadLine();
            double episodeDuration = double.Parse(Console.ReadLine());
            double breakDuration = double.Parse(Console.ReadLine());

            double timeForLunch = breakDuration * 1 / 8;
            double restTime = breakDuration * 1 / 4;
            double leftTime = breakDuration - timeForLunch - restTime;

            if (leftTime >= episodeDuration)
            {
                double freeTime = leftTime - episodeDuration;
                Console.WriteLine($"You have enough time to wath {tvSeriesName} and left with {Math.Floor(freeTime)} minutes free time.");
            }
            else if (episodeDuration > leftTime)
            {
                double timeNeeded = episodeDuration - leftTime;
                Console.WriteLine($"You don't have enough time to watch {tvSeriesName}, you need {Math.Ceiling(timeNeeded)} more minutes.");
            }
        }
    }
}
