int sumOfEvenNumbers = 0;
int sumOfOddNumbers = 0;
int difference = 0;

int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < numbers.Length;i++)
{
    if (numbers[i] % 2 == 0)
    {
        sumOfEvenNumbers += numbers[i];
    }
    else
    {
        sumOfOddNumbers += numbers[i];          
    }
}difference = sumOfEvenNumbers - sumOfOddNumbers;
Console.WriteLine(difference);