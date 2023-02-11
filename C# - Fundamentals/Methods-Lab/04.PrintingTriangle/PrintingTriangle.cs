using System;

namespace _04.PrintingTriangle
{
    internal class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= input; i++) 
            {
                PrintingTriangles(1, i);
            }

            for(int i = input - 1; i >=1; i--)
            {
                PrintingTriangles(1, i);
            } 
        }

        static void PrintingTriangles(int start , int end)
        {
            for (int i = start; i <= end; i++) 
            {
                Console.Write(i + " ");
            }   
            Console.WriteLine();
        }
    }
}
