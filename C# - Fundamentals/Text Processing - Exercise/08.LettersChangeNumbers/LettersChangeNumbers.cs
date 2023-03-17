using System.Net.Http.Headers;
using System.Runtime.InteropServices;

//English alphabet
string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string lowerLetters = "abcdefghijklmnopqrstuvwxyz";

//The input from console
string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

double sum = 0;

foreach(var item in input)
{
    char firstLetter = item[0];

    char lastLetter = item[item.Length - 1];

    string numberString = item.Substring(1, item.Length - 2);

    double number = double.Parse(numberString);

    //1.Starting with the firstLetter
    if(upperLetters.Contains(firstLetter))
    {
        number/= (upperLetters.IndexOf(firstLetter) + 1);
    }
    else if (lowerLetters.Contains(firstLetter))
    {
        number *= (lowerLetters.IndexOf(firstLetter) + 1);
    }

    //2. Now is time for the last letter
    if (upperLetters.Contains(lastLetter))
    {
        number -= (upperLetters.IndexOf(lastLetter) + 1);
    }
    else if (lowerLetters.Contains(lastLetter))
    {
        number += (lowerLetters.IndexOf(lastLetter) + 1);
    }

    sum += number;
}

//Printing the sum
Console.WriteLine($"{sum:f2}");





