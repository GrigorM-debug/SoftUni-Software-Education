int size = int.Parse(Console.ReadLine());

if (size < 3)
{
    Console.WriteLine(0);
    return;
}

char[,] matrix = new char[size, size];

for (int row = 0; row < size; row++)
{
    string chars = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = chars[col];
    }
}

int knightsRemoved = 0;

while (true)
{
    int countMostAttacking = 0;
    int mostAttackingRow = 0;
    int mostAttackingCol = 0;

    for (int row = 0; row < size;row++)
    {
        for (int col = 0; col < size; col++)
        {
            if (matrix[row, col]  == 'K')
            {
                int attackedKnights = AttackedKnightsCount(row, col,size, matrix);

                if (attackedKnights > countMostAttacking)
                {
                    countMostAttacking = attackedKnights;
                    mostAttackingRow = row;
                    mostAttackingCol = col;
                }
            }
        }
    }

    if (countMostAttacking == 0)
    {
        break;
    }
    else
    {
        matrix[mostAttackingRow, mostAttackingCol] = '0';
        knightsRemoved++;
    }
}

Console.WriteLine(knightsRemoved);


static int AttackedKnightsCount(int row, int col, int size, char[,] matrix)
{
    int attackedKnights = 0;

    //In chest knight moves in L pattern directions

    // left and up
    if (IsValid(row - 1, col - 2, size) && matrix[row - 1, col - 2] == 'K')
    {
        attackedKnights++;
    }

    //left and down
    if (IsValid(row + 1, col - 2, size) && matrix[row + 1, col - 2] == 'K')
    {
        attackedKnights++;
    }

    //right and up
    if (IsValid(row - 1, col + 2, size) && matrix[row - 1, col + 2] == 'K')
    {
        attackedKnights++;
    }

    //right and down 
    if (IsValid(row + 1, col + 2, size) && matrix[row + 1, col + 2] == 'K')
    {
        attackedKnights++;
    }

    // up and left
    if (IsValid(row - 2, col - 1, size) && matrix[row - 2, col - 1] == 'K')
    {
        attackedKnights++;
    }

    // up and right
    if (IsValid(row - 2, col + 1, size) && matrix[row - 2, col + 1] == 'K')
    {
        attackedKnights++;
    }

    // down and left
    if (IsValid(row + 2, col - 1, size) && matrix[row + 2, col - 1] == 'K')
    {
        attackedKnights++;
    }

    //  down and right 
    if (IsValid(row + 2, col + 1, size) && matrix[row + 2, col + 1] == 'K')
    {
        attackedKnights++;
    }

    return attackedKnights;
}

static bool IsValid (int row, int col,int size)
{
    if (row >= 0
        && row < size
        && col >= 0
        && col < size)
    {
        return true;    
    }
    return false;
}