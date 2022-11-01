using System;

namespace _08.Graduation
{
    internal class Graduation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currectClas = 1;
            double allGrades = 0;
            int badGrades = 0;

            while (currectClas <= 12)
            {
                double currectMark = double.Parse(Console.ReadLine());
                
                if (currectMark >= 4)
                {
                    currectClas++;
                    allGrades += currectMark;
                }
                else
                {
                    badGrades++;
                    if (badGrades > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {currectClas} grade");
                        return;
                    }
                }
            }
            double averageGrade = allGrades / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
