Dictionary<string,Piece> pieces= new Dictionary<string,Piece>();

int numberOfInputs = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfInputs; i++)
{
    string[] pieceArgs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

    string pieceName = pieceArgs[0];
    string composer = pieceArgs[1];
    string key = pieceArgs[2];

    pieces[pieceName] = new Piece(pieceName, composer, key);
}

string input = Console.ReadLine();

while (input != "Stop")
{
    string[] commandArgs = input.Split("|");

    string command = commandArgs[0];    
    string pieceName = commandArgs[1];

    if (command == "Add")
    {
        if (!pieces.ContainsKey(pieceName))
        {
            string composer = commandArgs[2];
            string key = commandArgs[3];
            pieces[pieceName] = new Piece(pieceName, composer, key);
            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
        }
        else
        {
            Console.WriteLine($"{pieceName} is already in the collection!");
        }
    }
    else if (command == "Remove")
    {
        if (pieces.ContainsKey(pieceName))
        {
            pieces.Remove(pieceName);
            Console.WriteLine($"Successfully removed {pieceName}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
        }
    }
    else if (command == "ChangeKey")
    {
        string keyToReplace = commandArgs[2];

        if (pieces.ContainsKey(pieceName))
        {
            pieces[pieceName].Key = keyToReplace;
            Console.WriteLine($"Changed the key of {pieceName} to {keyToReplace}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
        }
    }
    input = Console.ReadLine();
}
foreach(var piece in pieces.Values)
{
    Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
}

class Piece
{
    public string Name { get; set; }

    public string Composer { get; set;}

    public string Key { get; set;}

    public Piece(string pieceName, string composer, string key)
    {
        Name = pieceName;
        Composer = composer;
        Key = key;
    }
}