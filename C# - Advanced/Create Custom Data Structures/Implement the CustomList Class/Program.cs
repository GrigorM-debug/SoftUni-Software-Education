﻿namespace Implement_the_CustomList_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new();

            list.Add(100);

            list[0] = 234;

            list.AddRange(new int[] { 1, 2, 3, 4 });

            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));
            Console.WriteLine(list.RemoveAt(2));

            Console.WriteLine();
            Console.WriteLine(list.Contains(234));
            Console.WriteLine(list.Contains(100));

            list.Insert(0, -5);

            list.Swap(0, 1);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine(list.Count); // == 3
        }
    }
}