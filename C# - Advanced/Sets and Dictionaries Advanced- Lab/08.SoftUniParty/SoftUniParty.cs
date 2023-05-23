HashSet<string> regulars = new HashSet<string>();   
HashSet<string> VIPS = new HashSet<string>();

string command;
while((command = Console.ReadLine()) != "PARTY")
{
    char firstLetter = command[0];

    if (char.IsDigit(firstLetter))
    {
        VIPS.Add(command);
    }
    else
    {
        regulars.Add(command);
    }
}

while ((command = Console.ReadLine()) != "END")
{
    if (regulars.Contains(command) || VIPS.Contains(command))
    {
        regulars.Remove(command);
        VIPS.Remove(command);
    }
}
int count = VIPS.Count + regulars.Count;

Console.WriteLine(count);

foreach (var vip in VIPS)
{
    Console.WriteLine(vip);
}

foreach (var regular in regulars)
{
    Console.WriteLine(regular);
}


