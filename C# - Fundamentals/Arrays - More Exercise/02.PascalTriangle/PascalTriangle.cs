int numberOfInputs = int.Parse(Console.ReadLine());

int[] arr = null;
int[] secondArr = null;

for (int i = 1;i <= numberOfInputs; i++)
{
    arr = new int[i];

    arr[0] = 1;
    arr[arr.Length-1] = 1;

    for (int j = 1; j < arr.Length-1;j++)
    {
        arr[j] = secondArr[j-1] + secondArr[j];
    }

    secondArr = arr;

    Console.WriteLine(string.Join(" ", arr));
}


