string[] matrixSize = Console.ReadLine().Split(", ");

int rows = int.Parse(matrixSize[0]);
int cols = int.Parse(matrixSize[1]);

int[,] matrix = new int[rows, cols];


for (int row = 0; row < rows; row++)
{
    int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = array[col];
    }
}

//int sumOfMatrixColumns = 0;

for (int col = 0; col < cols; col++)
{
    int sumOfMatrixColumns = 0;
    for (int row = 0; row < rows; row++)
    {
        sumOfMatrixColumns += matrix[row, col];
    }
    
    Console.WriteLine(sumOfMatrixColumns);
}

