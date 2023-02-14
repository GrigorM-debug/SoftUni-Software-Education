internal class PasswordValidator
{
    static void Main()
    {
        string input = Console.ReadLine();
        bool isTrue = CheckSixToTenCharacter(input) &&
                     CheckLettersOrDigits(input) &&
                     CheckAtLeastTwoDigits(input);

        if (isTrue)
        {
            Console.WriteLine("Password is valid");
        }
        else
        {
            if (!CheckSixToTenCharacter(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!CheckLettersOrDigits(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!CheckAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
    }

    static bool CheckSixToTenCharacter(string input)
    {
        if (input.Length >= 6 && input.Length <= 10)
        {
            return true;
        }
        return false;
    }

    static bool CheckLettersOrDigits(string input)
    {
        foreach (char c in input) 
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }
    
    static bool CheckAtLeastTwoDigits(string input)
    {
        int counter = 0;
        for (int i = 0; i < input.Length; i++) 
        {
            if (input[i]> 47 && input[i] < 58)
            {
                counter++;  
            }
        }

        if (counter > 1)
        {
            return true;
        }

        return false;
    }
}