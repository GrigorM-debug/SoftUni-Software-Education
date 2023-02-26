List<Cars> cars = new List<Cars>();
List<Trucks> trucks = new List<Trucks>();

string input = Console.ReadLine();

while (input != "end")
{
    string[] vehiclesInfo = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

    string type = vehiclesInfo[0];  
    string brand = vehiclesInfo[1]; 
    string model = vehiclesInfo[2]; 
    int value = int.Parse(vehiclesInfo[3]);
    if (type == "Car")
    {
        Cars car = new Cars();
        {
            car.Brand = brand;
            car.Model = model;
            car.Horsepower = value;

            cars.Add(car);
        };
    }
    else if (type == "Truck")
    {
        Trucks truck = new Trucks();
        {
            truck.Brand = brand;
            truck.Model = model;
            truck.Weight = value;

            trucks.Add(truck);
        };
    }

    input = Console.ReadLine(); 
}

Console.WriteLine("Cars:");
foreach (var car in cars.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{car.Brand}: {car.Model} - {car.Horsepower}hp");
}

Console.WriteLine("Trucks:");
foreach (var truck in trucks.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
}
class Cars
{
    public string Brand { get; set; }   

    public string Model { get; set; }   

    public int Horsepower { get; set; } 
}

class Trucks
{
    public string Brand { get; set; }

    public string Model { get; set; }   

    public int Weight { get; set; } 
}