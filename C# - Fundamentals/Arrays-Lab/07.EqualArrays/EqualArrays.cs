using System.Security;

int[] firstArray = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] secondArray = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int sumOfArrays = 0;

for (int i = 0; i < firstArray.Length; i++)
{
    if (firstArray[i] != secondArray[i])
    {
        Console.Write($"Arrays are not identical. Found difference at {i} index");
        return;
    }
}
sumOfArrays = firstArray.Sum();
Console.Write($"Arrays are identical. Sum: {sumOfArrays}");
