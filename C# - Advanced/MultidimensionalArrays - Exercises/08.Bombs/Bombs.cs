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

string[] bombsIndecxes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

foreach(var  indexPair in bombsIndecxes)
{
    int[] indecxes = indexPair.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    
    int row = indecxes[0];
    int col = indecxes[1];

    //TODO use method for exploding
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

static void PrintTheMatrix(int[,] matrix, int size)
{
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            Console.WriteLine($"{matrix[row, col]} ");
        }
        Console.WriteLine();
    }
}