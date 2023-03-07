Dictionary<string, string> parking = new Dictionary<string, string>();  

int numberOfCommands = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfCommands; i++)
{
    string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = cmdArgs[0];
    string username = cmdArgs[1];

    if (command == "register")
    {
        string plateNumber = cmdArgs[2];

        if (parking.ContainsKey(username))
        {
            Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
        }
        else
        {
            parking[username] = plateNumber;
            Console.WriteLine($"{username} registered {plateNumber} successfully");
        }
    }
    else if (command == "unregister")
    {
        if(!parking.ContainsKey(username))
        {
            Console.WriteLine($"ERROR: user {username} not found");
        }
        else
        {
            parking.Remove(username);
            Console.WriteLine($"{username} unregistered successfully");
        }
    }
}

foreach(var car in parking)
{
    Console.WriteLine($"{car.Key} => {car.Value}");
}