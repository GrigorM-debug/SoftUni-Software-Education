int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = array[col];
    }
}

int primaryDiagonalSum = PrimaryDiagonalSum(matrix, size);
int secondaryDiagonalSum = SecondaryDiagonalSum(matrix, size);

//int primaryDiagonalSum = 0;
//int secondaryDiagonalSum = 0;

//for (int i = 0; i < size; i++)
//{
//    primaryDiagonalSum += matrix[i, i];
//    secondaryDiagonalSum += matrix[size - 1 - i, i];
//}
Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));

static int PrimaryDiagonalSum(int[,] matrix, int size)
{
    int primarySum = 0;

    for (int i = 0; i < size; i++)
    {
        primarySum += matrix[i, i];
    }
    return primarySum;
}


static int SecondaryDiagonalSum(int[,] matrix, int size)
{
    int secondSum = 0;
    for (int j = 0; j < size; j++)
    {
        secondSum += matrix[size -
            1 - j, j];
    }
    return secondSum;
}

