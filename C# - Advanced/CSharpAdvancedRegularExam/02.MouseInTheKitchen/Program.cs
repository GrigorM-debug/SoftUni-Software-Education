string[] dimensions = Console.ReadLine().Split(',');
int rows = int.Parse(dimensions[0]);
int cols = int.Parse(dimensions[1]);

char[][] matrix = new char[rows][];
int mouseRow = 0;
int mouseCol = 0;

for (int row = 0; row < rows; row++)
{
    string input = Console.ReadLine();
    matrix[row] = input.ToCharArray();

    if (input.Contains('M'))
    {
        mouseRow = row;
        mouseCol = input.IndexOf('M');
    }
}

bool isMouseSleeping = false;
int cheeseCount = matrix.SelectMany(row => row).Count(cell => cell == 'C');

while (true)
{
    string command = Console.ReadLine();

    if (command == "danger")
    {
        Console.WriteLine("Mouse will come back later!");
        break;
    }

    int newRow = mouseRow;
    int newCol = mouseCol;

    switch (command)
    {
        case "up":
            newRow--;
            break;
        case "down":
            newRow++;
            break;
        case "left":
            newCol--;
            break;
        case "right":
            newCol++;
            break;
    }

    if (!IsValidMove(newRow, newCol, rows, cols))
    {
        Console.WriteLine("No more cheese for tonight!");
        break;
    }

    char newPosition = matrix[newRow][newCol];

    if (newPosition == '@')
    {
        continue; // Wall, skip the command
    }

    matrix[mouseRow][mouseCol] = '*'; // Mark previous position as empty

    if (newPosition == 'C')
    {
        matrix[newRow][newCol] = '*'; // Cheese eaten
        cheeseCount--;

        if (cheeseCount == 0)
        {
            isMouseSleeping = true;
            break;
        }
    }

    matrix[newRow][newCol] = 'M'; // Move to the new position

    mouseRow = newRow;
    mouseCol = newCol;
}

if (isMouseSleeping)
{
    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
}

// Print the final state of the matrix
foreach (char[] row in matrix)
{
    Console.WriteLine(string.Join("", row));
}
        
static bool IsValidMove(int row, int col, int numRows, int numCols)
{
    return row >= 0 && row < numRows && col >= 0 && col < numCols;
}