﻿using System;

namespace _01.NumbersEndingIn7
{
    internal class NumbersEnding7
    {
        static void Main(string[] args)
        {
            for (int i = 7; i <= 997; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
