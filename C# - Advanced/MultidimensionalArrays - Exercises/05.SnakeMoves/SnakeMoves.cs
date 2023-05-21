using System.Runtime.ExceptionServices;

int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = matrixSize[0];
int cols = matrixSize[1];

char[,] matrix = new char[rows, cols];

string word = Console.ReadLine();

int currWordIndex = 0;

for (int row = 0; row < rows; row++)
{
    if (row %2 == 0)
    {
        for (int col =  0; col < cols; col++)
        {
            if (currWordIndex == word.Length)
            {
                currWordIndex = 0;
            }

            matrix[row, col] = word[currWordIndex];
            currWordIndex++;
        } 
    }
    else
    {
        for (int col = cols  - 1; col >=0; col--)
        {
            if(currWordIndex == word.Length)
            {
                currWordIndex = 0;
            }

            matrix[row, col] = word[currWordIndex];
            currWordIndex++;
        }
    }
}   

//Printing the Matrix 
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}