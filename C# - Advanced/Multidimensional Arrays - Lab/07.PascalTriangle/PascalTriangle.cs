using System.Globalization;

int rows = int.Parse(Console.ReadLine());

long[][] pascalTriangle = new long[rows][];

pascalTriangle[0] = new long[1] { 1 };

for (int row = 1; row < pascalTriangle.Length; row++)
{
    pascalTriangle[row] = new long[row + 1];

    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        if (pascalTriangle[row-1].Length > col)
        {
            pascalTriangle[row][col] += pascalTriangle[row - 1][col];
        }
        
        if (col > 0)
        {
            pascalTriangle[row][col] += pascalTriangle[row - 1][col - 1];
        }
    }
}

for (int row = 0; row < pascalTriangle.Length; row++)
{
    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        Console.Write($"{pascalTriangle[row][col]} ");
    }
    Console.WriteLine();
}