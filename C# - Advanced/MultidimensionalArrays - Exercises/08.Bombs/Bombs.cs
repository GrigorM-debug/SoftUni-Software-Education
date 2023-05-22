int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = numbers[col];
    }
}

string[] bombsIndecxes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach(var  indexPair in bombsIndecxes)
{
    int[] indecxes = indexPair.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); ;

    int bombRow = indecxes[0];
    int bombCol = indecxes[1];

    BombExploding(matrix, bombRow, bombCol, size);
}

int aliveCellsCount = 0;
int aliveCellsSum = 0;
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (matrix[row, col] > 0)
        {
            aliveCellsCount++;
            aliveCellsSum+= matrix[row, col];
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCellsCount}");
Console.WriteLine($"Sum: {aliveCellsSum}");
PrintTheMatrix(matrix, size);


//TODO method for bomb exploding
static void BombExploding(int[,] matrix, int bombRow, int bombCol, int size)
{
    int value = matrix[bombRow, bombCol];

    if (value > 0)
    {
        matrix[bombRow, bombCol] = 0;

        //up
        if (bombRow > 0 && matrix[bombRow - 1, bombCol] > 0)
        {
            matrix[bombRow - 1, bombCol] -= value;
        }

        //down
        if (bombRow < size - 1 && matrix[bombRow+1, bombCol] > 0)
        {
            matrix[bombRow + 1, bombCol] -= value;
        }

        //left
        if (bombCol > 0 && matrix[bombRow, bombCol - 1] > 0)
        {
            matrix[bombRow, bombCol - 1] -= value;
        }

        //right
        if (bombCol < size - 1 && matrix[bombRow, bombCol + 1] > 0)
        {
            matrix[bombRow, bombCol + 1] -= value;
        }

        //up and right
        if (bombRow > 0 && bombCol < size -1 &&  matrix[bombRow - 1, bombCol + 1] > 0)
        {
            matrix[bombRow - 1, bombCol + 1] -= value;
        }

        //up and left
        if (bombRow > 0 && bombCol> 0 && matrix[bombRow -1, bombCol -1] > 0)
        {
            matrix[bombRow - 1, bombCol -1] -= value;
        }

        //down and right
        if (bombRow < size - 1 && bombCol < size - 1 && matrix[bombRow + 1, bombCol + 1] > 0)
        {
            matrix[bombRow + 1, bombCol + 1] -= value;
        }

        //down and left
        if (bombRow < size - 1 && bombCol > 0 &&  matrix[bombRow + 1, bombCol -1] > 0)
        {
            matrix[bombRow + 1, bombCol - 1] -= value;
        }
    }
}

static void PrintTheMatrix(int[,] matrix, int size)
{
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }
        Console.WriteLine();
    }
}