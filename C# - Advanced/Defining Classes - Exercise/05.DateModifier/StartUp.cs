using _05.DateModifier;
using System;

namespace _05.DateModifier;

public class StartUp
{
    static void Main(string[] args)
    {
        string startDate = Console.ReadLine();
        string endDate = Console.ReadLine();

        int differenceInDays = DateModifier.GetDifferenceInDays(startDate, endDate);

        Console.WriteLine(Math.Abs(differenceInDays));
    }
}