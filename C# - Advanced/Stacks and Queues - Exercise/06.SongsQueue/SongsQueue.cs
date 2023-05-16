using System.Net.Sockets;

Queue<string> songs = new(
    Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries));

while (songs.Any())
{
    string[] tokens = Console.ReadLine().Split();
    string command = tokens[0];

    string song = string.Join(" ", tokens.Skip(1));

    if (command == "Add")
    {
        if (!songs.Contains(song))
            {
            songs.Enqueue(song);
        }
        else
        {
            Console.WriteLine($"{song} is already contained!");
        }
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
    else if (command == "Play")
    {
        songs.Dequeue();
    }
}
if (songs.Count == 0)
{
    Console.WriteLine("No more songs!");
}

//This needs somr fixes
