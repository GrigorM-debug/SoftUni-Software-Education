int waterTankCapasity = 255;
int numberOfInput = int.Parse(Console.ReadLine());
int littersInTank = 0;
int sumOfQuantities = 0;
for(int i = 0; i <= numberOfInput; i++)
{
    int quantitiesOfWater = int.Parse(Console.ReadLine());

    sumOfQuantities += quantitiesOfWater;
    if (sumOfQuantities >= waterTankCapasity)
    {
        Console.WriteLine("Insufficient capacity!");
        sumOfQuantities = sumOfQuantities - quantitiesOfWater;
        continue;
    }
        //Console.WriteLine(sumOfQuantities);
}
littersInTank = sumOfQuantities; 
Console.WriteLine(littersInTank);