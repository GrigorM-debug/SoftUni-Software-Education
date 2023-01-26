int waterTankCapasity = 255;
int pipesCount = int.Parse(Console.ReadLine());
int currentVolume = 0;

while (pipesCount>0)
{
    int quantitiesOfWater = int.Parse(Console.ReadLine());

    if (quantitiesOfWater + currentVolume  <= waterTankCapasity)
    {
        currentVolume += quantitiesOfWater;
    }
    else
    {
        Console.WriteLine("Insufficient capacity!");
    }
    pipesCount--;
}
Console.WriteLine(currentVolume);