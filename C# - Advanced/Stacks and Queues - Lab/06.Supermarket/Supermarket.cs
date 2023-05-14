Queue<string> customerNames = new Queue<string>();

string command = Console.ReadLine();

while (command != "End")
{
    if (command != "Paid")
    {
        customerNames.Enqueue(command);
        command = Console.ReadLine();
        continue;
    }
    
    while (customerNames.Any())
    {
        Console.WriteLine(customerNames.Dequeue());
    }
    command = Console.ReadLine();
}
Console.WriteLine($"{customerNames.Count} people remaining.");