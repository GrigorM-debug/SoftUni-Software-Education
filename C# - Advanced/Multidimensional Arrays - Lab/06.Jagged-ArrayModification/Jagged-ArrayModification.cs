using System.Data.Common;

int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for (int row= 0; row < rows; row++)
{
    jagged[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
}    

string command = Console.ReadLine().ToLower();    

while (command != "end")
{
    string[] commandArgs = command.Split(' ');
    int row = int.Parse(commandArgs[1]);
    int col = int.Parse(commandArgs[2]);
    int value = int.Parse(commandArgs[3]);

    bool isValid = true;

    if (row < 0 || jagged.Length <= row)
    {
        isValid = false;
    }
    else 
    {
        if (col < 0 || jagged[row].Length <= col)
        {
            isValid = false;
        }
    }

    if (isValid) 
    {
        switch (commandArgs[0])
        {
            case "add":
                jagged[row][col] += value;
                break;
            case "subtract":
                jagged[row][col] -= value;
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid coordinates");
    }
    command= Console.ReadLine().ToLower();
}

for (int row = 0; row < jagged.Length; row++)
{
    for (int col =0; col < jagged[row].Length; col++)
    {
        Console.Write($"{jagged[row][col]} ");
    }
    Console.WriteLine();
}