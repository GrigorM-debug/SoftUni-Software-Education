internal class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string firstString = input[0];
        string secondString = input[1]; 

        int sumOfStrings = GetSum(firstString, secondString);

        Console.WriteLine(sumOfStrings);
    }

    static int GetSum(string firstString, string secondString)
    {
        int sum = 0;

        if (firstString.Length < secondString.Length)
        {
            for(int i = 0; i < firstString.Length; i++)
            {
                sum += firstString[i] * secondString[i];
            }

            for (int i = firstString.Length; i < secondString.Length; i++)
            {
                sum += secondString[i];
            }
        }
        else 
        {
            for(int i = 0; i < secondString.Length;i++)
            {
                sum += firstString[i] * secondString[i];
            }

            for (int i = secondString.Length; i < firstString.Length; i++)
            {
                sum += firstString[i];
            }
        }

        return sum;
    }
}