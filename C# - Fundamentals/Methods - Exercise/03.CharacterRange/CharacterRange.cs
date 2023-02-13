internal class CharacterRange
{
    static void Main()
    {
        char firstCharacter = char.Parse(Console.ReadLine());
        char secondCharacter = char.Parse(Console.ReadLine());

        PrintCharacter(firstCharacter, secondCharacter);
       
    }
    static void PrintCharacter (char firstCharacter, char secondCharacter)
    {
        int startChracter = Math.Min(firstCharacter, secondCharacter);
        int endCharacter = Math.Max(firstCharacter, secondCharacter);

        for (int i = ++startChracter; i < endCharacter; i++)
        {
            char currentCharacter = (char)i;
            Console.Write(currentCharacter + " ");
        }
    }
}