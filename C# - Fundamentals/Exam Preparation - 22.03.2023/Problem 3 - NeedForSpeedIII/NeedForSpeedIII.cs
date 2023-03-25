Dictionary<string, Car> cars = new Dictionary<string, Car>();   

int numberOfcars = int.Parse(Console.ReadLine());

for (int i =0; i< numberOfcars; i++)
{
    string[] carsInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

    string name = carsInfo[0];
    int mileage = int.Parse(carsInfo[1]);
    int fuel = int.Parse(carsInfo[2]);

    Car car = new Car(name, mileage, fuel);

    cars.Add(name, car);
}

string command = Console.ReadLine();

while (command != "Stop")
{
    string[] commandInfo = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string commandName= commandInfo[0];

    if (commandName == "Drive")
    {
        string carName = commandInfo[1];
        int requiredDistance = int.Parse(commandInfo[2]);
        int requiredFuel = int.Parse(commandInfo[3]);

        Car car = cars[carName];

        if (requiredFuel > car.Fuel)
        {
            Console.WriteLine("Not enough fuel to make that ride");
            command = Console.ReadLine();
            continue;
        }

        car.Mileage += requiredDistance;
        car.Fuel -= requiredFuel;
        Console.WriteLine($"{carName} driven for {requiredDistance} kilometers. {requiredFuel} liters of fuel consumed.");

        if (car.Mileage >= 100_000)
        {
            cars.Remove(carName);
            Console.WriteLine($"Time to sell the {carName}!");
        }
    }
    else if (commandName == "Refuel")
    {
        string carName = commandInfo[1];
        int fuelToRefill = int.Parse(commandInfo[2]);

        Car car = cars[carName];

        int actualFuel = 0;
        if (car.Fuel + fuelToRefill > 75)
        {
            actualFuel = 75 - car.Fuel;
        }
        else
        {
            actualFuel += fuelToRefill;
        }

        car.Fuel += actualFuel;

        Console.WriteLine($"{carName} refueled with {actualFuel} liters");
    }
    else if (commandName == "Revert")
    {
        string carName = commandInfo[1];
        int kilometers = int.Parse(commandInfo[2]);

        Car car = cars[carName];

        car.Mileage -= kilometers;

        if (car.Mileage <= 10_000)
        {
            car.Mileage = 10_000;
        }
        else
        {
            Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
        }
    }
    command = Console.ReadLine();
}

foreach(var (carName, car) in cars)
{
    Console.WriteLine($"{carName} -> Mileage: {car.Mileage} kms, Fuel in the rank: {car.Fuel} lt.");
}

class Car
{
    public Car(string name, int mileage, int fuel)
    {
        Name = name;
        Mileage = mileage;
        Fuel = fuel;
    }
    public string Name { get; set; }

    public int Mileage { get; set; }    

    public int Fuel { get; set; }   
}