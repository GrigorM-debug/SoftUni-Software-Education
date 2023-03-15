using System.Collections.Immutable;

int numberOfInputs = int.Parse(Console.ReadLine());

int vowelSum = 0;
int consonantSum = 0;
int totalSum = 0;

string vowels = "EeUuIiOoAa";

int[] allSums = new int[numberOfInputs];

for (int i = 0; i < numberOfInputs; i++)
{
    string input = Console.ReadLine();

    for (int j = 0; j < input.Length; j++)
    {
        char currChar = input[j];

        if (vowels.Contains(currChar))
        {
            vowelSum += currChar * input.Length;
        }
        else
        {
            consonantSum+= currChar /input.Length;
        }
    }
    totalSum = vowelSum + consonantSum;

    allSums[i] = totalSum;


    vowelSum = 0;
    consonantSum= 0;
    
}

Array.Sort(allSums);

for (int i = 0; i < allSums.Length; i++)
{
    Console.WriteLine(allSums[i]);
}