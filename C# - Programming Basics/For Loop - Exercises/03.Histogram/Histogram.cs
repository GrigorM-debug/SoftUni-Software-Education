using System;

namespace _03.Histogram
{
    internal class Histogram
    {
        static void Main(string[] args)
        {
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            int numbersCnt = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbersCnt; i++)
            {
                int n = int.Parse(Console.ReadLine());

                if (n < 200)
                {
                    p1++;   
                }
                else if (n >= 200 && n <= 399)
                {
                    p2++;
                }
                else if (n >= 400 && n <= 599)
                {
                    p3++;
                }
                else if (n >= 600 && n <= 799)
                {
                    p4++;
                }
                else 
                {
                    p5++;
                }
            }
            double p1InPercent = p1 / numbersCnt * 100;
            double p2InPercent = p2 / numbersCnt * 100;
            double p3InPercent = p3 / numbersCnt * 100;
            double p4InPercent = p4 / numbersCnt * 100;
            double p5InPercent = p5 / numbersCnt * 100;

            Console.WriteLine($"{p1InPercent:f2}%");
            Console.WriteLine($"{p2InPercent:f2}%");
            Console.WriteLine($"{p3InPercent:f2}%");
            Console.WriteLine($"{p4InPercent:f2}%");
            Console.WriteLine($"{p5InPercent:f2}%");
        }
    }
}
