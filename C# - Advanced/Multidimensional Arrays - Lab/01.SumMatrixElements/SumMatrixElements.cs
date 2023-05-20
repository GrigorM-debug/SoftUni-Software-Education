string[] matrixSize = Console.ReadLine().Split(", ");

int rows = int.Parse(matrixSize[0]);
int cols = int.Parse(matrixSize[1]);

int[,] matrix = new int [rows, cols];


for (int row = 0; row < rows; row++)
{
    int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

    for (int col =0; col < cols; col++)
    {
        matrix[row, col] = array[col];
    }
}

int sumOfMatrix = 0;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        sumOfMatrix += matrix[row, col];
    }
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sumOfMatrix);