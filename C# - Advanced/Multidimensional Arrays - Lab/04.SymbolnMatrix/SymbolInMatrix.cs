int rows = int.Parse(Console.ReadLine());
int cols = rows;

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    string array = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        char symbol = array[col];

        matrix[row, col] = symbol;
    }
}

char symbolToFind = char.Parse(Console.ReadLine());

bool isFound = false;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row, col] == symbolToFind)
        {
            Console.WriteLine($"({row}, {col})");
            isFound = true;
            return;
        }
    }
}

if (isFound == false)
{
    Console.WriteLine($"{symbolToFind} does not occur in the matrix");
}
