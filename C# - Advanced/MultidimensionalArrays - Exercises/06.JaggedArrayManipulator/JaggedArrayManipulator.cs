using System.Data.Common;

int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for (int row = 0; row < rows; row++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    jagged[row] = cols;
}


for (int row = 0; row < rows - 1; row++)
{
    if (jagged[row].Length == jagged[row + 1].Length)
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] *= 2;
            jagged[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < jagged[row].Length; col++)
        {
            jagged[row][col] /= 2;
        }

        for (int col = 0; col < jagged[row + 1].Length; col++)
        {
            jagged[row + 1][col] /= 2;
        }
    }
}

string command = Console.ReadLine();
while (command != "End")
{
    string[] commandArgs = command.Split(' ');
    int row = int.Parse(commandArgs[1]);
    int col = int.Parse(commandArgs[2]);
    int value = int.Parse(commandArgs[3]);

    if (row >= 0 && jagged.Length > row
        && col >= 0 && jagged[row].Length > col)
    {
        switch (commandArgs[0])
        {
            case "Add":
                jagged[row][col] += value;
                break;
            case "Subtract":
                jagged[row][col] -= value;
                break;
        }
    }

    command = Console.ReadLine();
}

for (int row = 0; row < jagged.Length; row++)
{
    for (int col = 0; col < jagged[row].Length; col++)
    {
        Console.Write($"{jagged[row][col]} ");
    }
    Console.WriteLine();
}