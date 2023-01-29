int evenNumbersSum = 0;
int oddNumbersSum = 0;
int difference = 0;

int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

foreach (var currentNumber in numbers)
{
    if (currentNumber % 2 == 0)
    {
        evenNumbersSum += currentNumber;   
    }
    else
    {
        oddNumbersSum += currentNumber;
    }
}
difference = evenNumbersSum - oddNumbersSum;

Console.WriteLine(difference);