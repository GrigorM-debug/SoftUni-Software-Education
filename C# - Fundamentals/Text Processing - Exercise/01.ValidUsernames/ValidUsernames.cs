internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] names = input.Split(", ");

        foreach (string name in names)
        {
            if (IsUserNameValid(name))
            {
                Console.WriteLine(name);
            }
        }
    }

    static bool IsUserNameValid(string name)
    {
        if (name.Length < 3 || name.Length > 16)
        {
            return false;
        }

        foreach (var character in name)
        {
            if (character != '_' && character != '-' && !char.IsLetterOrDigit(character))
            {
                return false;
            }
        }
        return true;
    }
}




