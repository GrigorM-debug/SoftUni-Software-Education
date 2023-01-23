decimal number = decimal.Parse(Console.ReadLine());
decimal sum = 0m;

for(decimal i = 0; i < number; i++)
{
    decimal newNumbers = decimal.Parse(Console.ReadLine());
    sum = sum + newNumbers;
}

Console.WriteLine(sum);