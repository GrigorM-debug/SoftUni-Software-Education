List<int> wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int maxCapacityOfWagon = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

while(input!="end")
{
    string[] command = input.Split(" ");

    if (command.Length == 2)
    {
        int passengers = int.Parse(command[1]); 
        wagons.Add(passengers);
    }
    else
    {
        int passengers = int.Parse(command[0]);

        foreach (var peopleInWagon in wagons)
        {
            if (wagons[wagons.IndexOf(peopleInWagon)] + passengers <= maxCapacityOfWagon)
            {
                wagons[wagons.IndexOf(peopleInWagon)] += passengers;
                break;
            }
        }
    }
    input= Console.ReadLine();
}
Console.WriteLine(string.Join(" ", wagons));