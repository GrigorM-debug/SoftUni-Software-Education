using System.Linq;

string input = Console.ReadLine();

List<Vehicle> catalogue = new List<Vehicle>();   

while (input != "End")
{
    string[] vehicleInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vehicleType = vehicleInfo[0].ToLower();
    string vehicleModel = vehicleInfo[1];
    string vehicleColor = vehicleInfo[2].ToLower();
    int vehicleHoursePower = int.Parse(vehicleInfo[3]);

    Vehicle car = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHoursePower);

    catalogue.Add(car);  

    if (input == "End")
    {
        break;
    }

    input = Console.ReadLine(); 
}


string secondInput = Console.ReadLine();

while (secondInput != "Close the Catalogue")
{
    string vehicle = secondInput;    

    if (vehicle == "Close the catalogue")
    {
        break;
    }

    Console.WriteLine(catalogue.Find (x=> x.Model == vehicle));

    secondInput= Console.ReadLine();
}

double totalCarsHoursePower = 0;
double totalTrucksHoursePower = 0;

List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

foreach (var car in onlyCars)
{
    totalCarsHoursePower += car.HorsePower;
}

foreach (var truck in onlyTrucks)
{
    totalTrucksHoursePower += truck.HorsePower;
}

double averageCarsHorsePower = 0;
double averageTrucksHorsePower = 0;


if (onlyCars.Count > 0)
{
    averageCarsHorsePower = totalCarsHoursePower / onlyCars.Count;
}
if (onlyTrucks.Count > 0)
{
    averageTrucksHorsePower = totalTrucksHoursePower / onlyTrucks.Count;
}

Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:f2}.");
Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:f2}.");


class Vehicle
{
    public Vehicle(string vehicleType, string vehicleModel, string vehicleColor, int vehicleHoursePower) 
    { 
        Type = vehicleType; 
        Model= vehicleModel;
        Color= vehicleColor;
        HorsePower= vehicleHoursePower;
    }    

    public string Type { get; set; }    

    public string Model { get; set; }   

    public string Color { get; set; }

    public int HorsePower { get; set; }

    public override string ToString()
    {
        return $"Type: {(Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
            $"Model: {Model}{Environment.NewLine}" +
            $"Color: {Color}{Environment.NewLine}" +
            $"Horsepower: {HorsePower}";
    }
}

