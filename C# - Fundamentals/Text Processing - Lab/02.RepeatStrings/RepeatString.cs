﻿string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string result = string.Empty;

foreach(string word in words)
{
    for (int i = 0; i < word.Length; i++)
    {
        result += word;
    }
}
Console.WriteLine(result);