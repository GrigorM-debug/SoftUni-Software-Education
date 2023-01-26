int waterTankCapasity = 255;
int numberOfInput = int.Parse(Console.ReadLine());
int sumOfQuantities = 0;

for (int i = 0; i <= numberOfInput; i++)
{
    int quantitiesOfWater = int.Parse(Console.ReadLine());

    sumOfQuantities += quantitiesOfWater;

    if (sumOfQuantities > waterTankCapasity)
    {
        Console.WriteLine("Insufficient capacity!");
        sumOfQuantities = sumOfQuantities - quantitiesOfWater;
        Console.WriteLine(sumOfQuantities);
        continue;
    }
    else
    {
        Console.WriteLine(sumOfQuantities);
    }
}