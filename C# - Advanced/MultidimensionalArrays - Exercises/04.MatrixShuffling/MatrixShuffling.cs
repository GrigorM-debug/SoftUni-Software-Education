using System.Runtime.InteropServices;

int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = matrixSize[0];
int cols = matrixSize[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = strings[col];
    }
}

string command;

while((command = Console.ReadLine()) != "END")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    
    if (tokens[0] != "swap" || tokens.Length != 5 
        || int.Parse(tokens[1]) < 0 || int.Parse(tokens[1]) >= rows
        || int.Parse(tokens[2]) < 0 || int.Parse(tokens[2]) >= cols
        || int.Parse(tokens[3]) < 0 || int.Parse(tokens[3]) >= rows
        || int.Parse(tokens[4]) < 0 || int.Parse(tokens[4]) >= cols
        )
    {
        Console.WriteLine("Invalid input!");
    }
    else
    {
        string temp = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])];
        matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])];
        matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = temp;

        PrintingMatrix(matrix, rows, cols);
    }
}

static void PrintingMatrix(string[,] matrix, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }
        Console.WriteLine();
    }
}