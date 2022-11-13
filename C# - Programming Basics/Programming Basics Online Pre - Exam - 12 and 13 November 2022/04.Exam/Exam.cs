using System;
using System.Diagnostics;

namespace _04.Exam
{
    internal class Exam
    {
        static void Main(string[] args)
        {
            int studentsCnt = int.Parse(Console.ReadLine());
            int groupOne = 0;
            int groupTwo = 0;
            int groupThree = 0;
            int groupFour = 0;

            
            double averageGrade = 0;

            for (int i = 1; i <= studentsCnt; i++)
            {
                double mark = double.Parse(Console.ReadLine());
                
                if (mark < 3)
                {
                    groupFour++;
                    averageGrade += mark;
                }
                else if (mark >= 3 && mark <= 3.99)
                {
                    groupThree++;
                    averageGrade += mark;
                }
                else if (mark >= 4 && mark <= 4.99)
                {
                    groupTwo++;
                    averageGrade += mark;
                }
                else if (mark >= 5)
                {
                    groupOne++;
                    averageGrade += mark;
                }

                //double groupOnePercent = groupOne / studentsCnt * 100;
                //double groupTwoPercent = groupTwo / studentsCnt * 100;
                //double groupThreePercent = groupThree / studentsCnt * 100;
                //double groupFourPercent = groupFour / studentsCnt * 100;

                //average = sum / studentsCnt;
            }
            double groupOnePercent = (groupOne / (studentsCnt * 1.0)) * 100;
            double groupTwoPercent = (groupTwo / (studentsCnt * 1.0)) * 100;
            double groupThreePercent = (groupThree / (studentsCnt * 1.0)) * 100;
            double groupFourPercent = (groupFour / (studentsCnt * 1.0)) * 100;

            averageGrade = averageGrade / studentsCnt;
            Console.WriteLine($"Top students: {groupOne:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {groupTwo:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {groupThree:f2}%");
            Console.WriteLine($"Fail: {groupFour:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
