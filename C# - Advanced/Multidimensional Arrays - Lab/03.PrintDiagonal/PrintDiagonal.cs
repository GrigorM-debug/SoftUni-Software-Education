int rows = int.Parse(Console.ReadLine());

int[][] matrix = new int[rows][];

for (int i = 0; i < rows; i++)
{
    matrix[i] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
}

int diagonalSum = 0;
for (int row = 0; row < rows; row++)
{
    diagonalSum += matrix[row][row]; 
}
Console.WriteLine(diagonalSum);