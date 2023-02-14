internal class SmallestOfThreeNumbers
{
    static void Main()
    {
        int numberOne = int.Parse(Console.ReadLine());
        int numberTwo = int.Parse(Console.ReadLine());  
        int numberThree = int.Parse(Console.ReadLine());
        Console.WriteLine(MinNumber(numberOne, numberTwo, numberThree));
    }

    static int MinNumber(int numberOne, int numberTwo, int numberThree)
    {
        int minNumberOfFirstTwo = Math.Min(numberOne, numberTwo);
        int minNumber = Math.Min(minNumberOfFirstTwo, numberThree);
        return minNumber;
    }
}