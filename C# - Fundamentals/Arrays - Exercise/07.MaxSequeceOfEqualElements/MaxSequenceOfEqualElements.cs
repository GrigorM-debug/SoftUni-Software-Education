int[] arr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int mostNumber = 0; 
int longestSequece = 0;
int counter = 1;

for (int i = 0; i < arr.Length - 1; i++)
{
    if (arr[i] == arr[i+1])
    {
        counter++;
    }
    else
    {
        counter = 1;
    }

    if (counter > mostNumber)
    {
        mostNumber= counter;
        longestSequece = arr[i];
    }
}
for (int i = 0; i < mostNumber; i++)
{
    Console.Write(longestSequece + " ");
}