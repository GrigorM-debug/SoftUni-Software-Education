internal class CharacterMultiplier
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
        int maxLenght = Math.Max(firstString.Length, secondString.Length);
        int sum = 0;

        for ( int i = 0; i < maxLenght; i++ )
        {
            int charOne = i < firstString.Length ? firstString[i] : 1;

            int charTwo = i < secondString.Length ? secondString[i] : 1;

            sum += charOne * charTwo;
        }

        return sum;
    }
}