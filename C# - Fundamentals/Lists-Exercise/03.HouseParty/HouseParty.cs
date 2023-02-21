using System.Net.Http.Headers;

int n = int.Parse(Console.ReadLine());

List<string> guestList = new List<string>();

for (int i = 0; i< n; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = input[0]; 

    if (input.Length == 3)
    {
        if (guestList.Contains(name))
        {
            Console.WriteLine($"{name} is already in the list!");
        }
        else
        {
            guestList.Add(name);
        }
    }
    else if (input.Length == 4)
    {
        if (!guestList.Contains(name))
        {
            Console.WriteLine($"{name} is not in the list!");
        }
        else
        {
            guestList.Remove(name);
        }
    }
}
Console.WriteLine(string.Join(Environment.NewLine, guestList));