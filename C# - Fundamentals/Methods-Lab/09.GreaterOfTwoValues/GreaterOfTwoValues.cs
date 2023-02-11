using System;
using System.Dynamic;
using System.Net.Http.Headers;

namespace _09.GreaterOfTwoValues
{
    internal class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();   

            if (type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int maxValue = GetMax(a, b);
                Console.WriteLine(maxValue);
            }
            else if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                char maxValue = GetMax(a, b);
                Console.WriteLine(maxValue);
            }
            else if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string maxValue = GetMax(a, b);
                Console.WriteLine(maxValue);
            }
        }
        static int GetMax(int a,int b)
        {
            if (a>b)
            {
                return a;
            }

            return b;
        }
        static char GetMax(char a,char b)
        {
            if (a>b)
            {
                return a;
            }

            return b;
        }
        static string GetMax(string a,string b)
        {
            int result = a.CompareTo(b);
            //a == b -> 0
            //a > b -> 1
            //a < b -> -1
            if (result > 0)
            {
                return a;
            }
            return b;
        }
    }
}
