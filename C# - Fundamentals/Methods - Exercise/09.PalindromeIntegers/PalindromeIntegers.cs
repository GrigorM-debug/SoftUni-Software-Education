internal class PalindromeIntegers
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            bool isPalindrome = IsPalidrome(input);
            Console.WriteLine(isPalindrome.ToString().ToLower());
            input = Console.ReadLine();
        }
    }

    private static bool IsPalidrome(string input)
    {
        string reverse = string.Empty;
        
        for (int i = input.Length -1; i >= 0; i--)
        {
            reverse += input[i];
        }

        if (input == reverse)
        {
            return true;
        }

        return false;
    }
}
