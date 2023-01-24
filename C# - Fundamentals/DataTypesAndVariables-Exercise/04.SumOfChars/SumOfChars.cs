int number = int.Parse(Console.ReadLine());

int sum = 0;
for(int i = 1; i <= number; i++)
{
    char input = char.Parse(Console.ReadLine());
    sum = sum + (int)input;
}
Console.WriteLine($"The sum equals: {sum}");