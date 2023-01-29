int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < inputNumbers.Length - 1; i++)
{
    for(int j = 0; j < inputNumbers.Length - 1 - i;j++)
    {
        inputNumbers[j] = inputNumbers[j] + inputNumbers[j + 1];
    }
}
Console.WriteLine(inputNumbers[0]);