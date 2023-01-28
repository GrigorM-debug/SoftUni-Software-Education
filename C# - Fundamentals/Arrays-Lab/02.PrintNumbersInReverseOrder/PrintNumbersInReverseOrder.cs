using System.Globalization;

int numbersOfInputs = int.Parse(Console.ReadLine());

int[] numbers = new int [numbersOfInputs];

for (int i = 0; i< numbersOfInputs; i++)
{
    int n = int.Parse(Console.ReadLine());
    numbers[i] = n;
}

int[] reversedNumbers = numbers.Reverse().ToArray();

for (int i = 0; i < reversedNumbers.Length; i++)
{
    Console.Write(reversedNumbers[i] + " ");
}    


//Second for reversing the numbers 
/* for (int i = numbers.Lenght-1; i = 0; i--)
 {
    Console.Write(numbers[i] + " ");
 }

*/