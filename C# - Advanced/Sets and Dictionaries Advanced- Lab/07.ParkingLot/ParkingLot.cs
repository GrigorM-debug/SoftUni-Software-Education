string input = Console.ReadLine();

HashSet<string> cars = new HashSet<string>();

while (input != "END")
{
    string[] tokens = input.Split(", ");

    string command = tokens[0];
    string plate = tokens[1];
    
    if (command == "IN")
    {
        cars.Add(plate);
    }  
    else if (command == "OUT")
    {
        cars.Remove(plate);
    }
    input = Console.ReadLine();
}

if (cars.Count > 0)
{
    foreach (var car in cars)
    {
        Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}