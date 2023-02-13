using System.Runtime.Serialization;

internal class VowelsCount
{
    static void Main()
    {
        string input = Console.ReadLine();
        int vowelsCount = Vowels(input);
        Console.WriteLine(vowelsCount);
    }
    
    static int Vowels(string input)
    {
        int vowelsCount = 0;

        char[] vowels = { 'a', 'e', 'i', 'o', 'u','y', 'A', 'E', 'I', 'O', 'U', 'Y' };
        for (int i = 0; i < input.Length;i++)
        {
            if (vowels.Contains(input[i]))
            {
                vowelsCount++; 
            }
        }
        return vowelsCount;
    }
}