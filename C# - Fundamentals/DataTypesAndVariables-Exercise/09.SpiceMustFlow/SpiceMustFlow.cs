int startingYield = int.Parse(Console.ReadLine());

int days = 0;
int produced = 0;

if (startingYield >= 100)
{
    while (startingYield >= 100)
    {
        produced += startingYield - 26;
        startingYield -= 10;
        days++;
    }
    produced -= 26;
    Console.WriteLine(days);
    Console.WriteLine(produced);
}
else
{
    Console.WriteLine(days);
    Console.WriteLine(produced);
}