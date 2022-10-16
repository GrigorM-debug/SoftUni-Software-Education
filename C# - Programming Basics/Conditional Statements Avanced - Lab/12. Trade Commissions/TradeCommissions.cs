using System;

namespace _12._Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commisions = 0.0;

            switch (city)
            {
                case "Sofia":
                    if (0 <= sales && sales <= 500)
                    {
                        commisions = 0.05;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commisions = 0.07;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commisions = 0.08;
                    }
                    else if (sales > 10000)
                    {
                        commisions = 0.12;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (0 <= sales && sales <= 500)
                    {
                        commisions = 0.045;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commisions = 0.075;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commisions = 0.10;
                    }
                    else if (sales > 10000)
                    {
                        commisions = 0.13;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (0 <= sales && sales <= 500)
                    {
                        commisions = 0.055;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commisions = 0.08;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commisions = 0.12;
                    }
                    else if (sales > 10000)
                    {
                        commisions = 0.145;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            double totalComisions = commisions * sales;

            if (totalComisions > 0)
            {
                Console.WriteLine("{0:F2}", totalComisions);
            }
        }
    }
}
