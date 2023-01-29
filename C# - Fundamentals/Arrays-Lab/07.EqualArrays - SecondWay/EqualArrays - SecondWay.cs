int[] firstArray = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] secondArray = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int sumOfArray = 0;
bool areSame = true;

for (int i = 0; i< firstArray.Length;i++)
{
    sumOfArray += firstArray[i];

    if (firstArray[i] != secondArray[i])
    {
        areSame = false;
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        break;
    }
}
if (areSame)
{
    Console.WriteLine($"Arrays are identical. Sum: {sumOfArray}");
}