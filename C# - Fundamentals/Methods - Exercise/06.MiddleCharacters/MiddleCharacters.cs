internal class MiddleCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        MiddleCharacter(input);
    }

    static void MiddleCharacter(string input)
    {
        int midCharacters = 0;

        if (input.Length % 2 == 0)
        {
            midCharacters = input.Length / 2;
            Console.WriteLine($"{input[midCharacters-1]}{input[midCharacters]}");
        }
        else
        {
            midCharacters = input.Length / 2;
            Console.WriteLine(input[midCharacters]);
        }
        
    }
}