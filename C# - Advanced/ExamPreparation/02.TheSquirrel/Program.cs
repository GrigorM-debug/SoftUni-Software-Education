using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

int fieldSize = int.Parse(Console.ReadLine());

string[] directions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

char[,] matrix = new char[fieldSize, fieldSize];

int squirrelRow = -1;
int squirrelCol = -1;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];

        if (matrix[row, col] == 's')
        {
            squirrelRow = row;
            squirrelCol = col;
        }
    }
}

int hazelnutsCount = 0;


foreach(var direction in directions)
{
    if(direction == "left")
    {
        if(IsValid(matrix, squirrelRow, squirrelCol - 1))
        {
            if (matrix[squirrelRow, squirrelCol - 1] == 'h')
            {
                hazelnutsCount++;
            }
            else if (matrix[squirrelRow, squirrelCol - 1] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            matrix[squirrelRow, squirrelCol - 1] = 's';
            matrix[squirrelRow, squirrelCol] = '*';

            squirrelCol--;
        }
        else if(!IsValid(matrix, squirrelRow, squirrelCol - 1))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
            return;
        }
    }
    else if(direction == "right")
    {
        if (IsValid(matrix, squirrelRow, squirrelCol + 1))
        {
            if (matrix[squirrelRow, squirrelCol + 1] == 'h')
            {
                hazelnutsCount++;
            }
            else if (matrix[squirrelRow, squirrelCol + 1] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            matrix[squirrelRow, squirrelCol + 1] = 's';
            matrix[squirrelRow, squirrelCol] = '*';

            squirrelCol++;
        }
        else if(!IsValid(matrix, squirrelRow, squirrelCol + 1))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
            return;
        }
    }
    else if(direction == "up")
    {
        if(IsValid(matrix, squirrelRow - 1, squirrelCol))
        {
            if (matrix[squirrelRow - 1, squirrelCol] == 'h')
            {
                hazelnutsCount++;
            }
            else if (matrix[squirrelRow - 1, squirrelCol] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            matrix[squirrelRow - 1, squirrelCol] = 's';
            matrix[squirrelRow, squirrelCol] = '*';

            squirrelRow--;
        }
        else if(!IsValid(matrix, squirrelRow - 1, squirrelCol))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
            return;
        }
    }
    else if (direction == "down")
    {
        if(IsValid(matrix, squirrelRow + 1, squirrelCol))
        {
            if (matrix[squirrelRow + 1, squirrelCol] == 'h')
            {
                hazelnutsCount++;
            }
            else if (matrix[squirrelRow + 1, squirrelCol] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            matrix[squirrelRow + 1, squirrelCol] = 's';
            matrix[squirrelRow, squirrelCol] = '*';

            squirrelRow++;
        }
        else if(!IsValid(matrix, squirrelRow + 1, squirrelCol))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
            return;
        }
    }
}

if(hazelnutsCount == 3)
{
    Console.WriteLine("Good job! You have collected all hazelnuts!");
    Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
}
else if (hazelnutsCount < 3)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}

bool IsValid(char[,] matrix, int row, int col)
{
    return row >= 0 && row < matrix.GetLength(0) &&
        col >= 0 && col < matrix.GetLength(1);
}

//Need some fix. It gives 90/100