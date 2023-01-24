int number = int.Parse(Console.ReadLine());

bool IsSpecialNum= false;

for (int i = 1; i <= number; i++)
{
    int currectNumber = i;
    int sum = 0;

    while (currectNumber > 0)
    {
        sum += currectNumber % 10;
        currectNumber /= 10;
    }
    if((sum == 5) || (sum == 7) || (sum == 11))
    {
        IsSpecialNum= true;
        Console.WriteLine("{0} -> {1}", i, IsSpecialNum);
    }
    else
    {
        IsSpecialNum = false;
        Console.WriteLine("{0} -> {1}", i, IsSpecialNum);
    }
}
