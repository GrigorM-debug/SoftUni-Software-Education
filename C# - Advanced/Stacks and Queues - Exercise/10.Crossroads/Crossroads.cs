int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowsDuration = int.Parse(Console.ReadLine());

Queue<string> cars = new Queue<string>();

int carPassed = 0;

string input;

while ((input = Console.ReadLine()) != "END")
{
    if(input != "green")
    {
        cars.Enqueue(input);
        continue;
    }

    int currGreenLghtDuration = greenLightDuration;

    while (currGreenLghtDuration > 0 && cars.Any())
    {
        string currCar = cars.Dequeue();

        if (currGreenLghtDuration - currCar.Length >= 0) 
        { 
            currGreenLghtDuration -= currCar.Length;
            carPassed++;
            continue;
        }

        if (currGreenLghtDuration + freeWindowsDuration - currCar.Length >= 0)
        {
            carPassed++;
            continue;
        }

        int hittChar = currGreenLghtDuration + freeWindowsDuration;

        Console.WriteLine("A crash happened!");
        Console.WriteLine($"{currCar} was hit at {currCar[hittChar]}.");

        return;
    }
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carPassed} total cars passed the crossroads.");