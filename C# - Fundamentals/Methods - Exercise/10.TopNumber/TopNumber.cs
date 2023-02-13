using System.Globalization;

internal class TopNumber
{
    static void Main()
    {
        string n = Console.ReadLine();
        bool isTopNuimber = TopNumber(n);
        Console.WriteLine(isTopNuimber.ToString().ToLower());
    }
}