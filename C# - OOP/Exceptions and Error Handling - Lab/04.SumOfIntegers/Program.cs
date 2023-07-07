﻿string[] elements = Console.ReadLine().Split(" ");

int sum = 0;

foreach(var element in elements)
{
    try
    {
        int currElement = int.Parse(element);
        sum += currElement;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally 
    { 
        Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");
