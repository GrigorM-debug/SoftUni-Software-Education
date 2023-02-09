int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int number = int.Parse(Console.ReadLine());

int specialNumbers = 0;

for (int i = 0; i < arr.Length - 1; i++)
{
    int sumOfElements = 0;

    for (int k = i + 1; k < arr.Length; k++)
    {
        sumOfElements= arr[i] + arr[k];

        if (sumOfElements == number)
        {
            Console.WriteLine(string.Join(" ", arr[i], arr[k]));
        }
    }
}
