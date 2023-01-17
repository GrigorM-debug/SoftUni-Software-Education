int inputCnt = int.Parse(Console.ReadLine());

int sum = 0;
int counter = 0;

for (int i=1; i<=100; i+=2)
{
    if (i %2 != 0)
    {
        Console.WriteLine(i);
    }
    sum = sum + i;
    counter++;
    if (counter == inputCnt)
    {
        Console.WriteLine($"Sum: {sum}");
        break;
    }
}
