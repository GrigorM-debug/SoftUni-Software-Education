﻿using System.Numerics;

int number = int.Parse(Console.ReadLine());

BigInteger result = 1;

for (int i = 1; i <= number; i++)
{
    result *= i;
}
Console.WriteLine(result);