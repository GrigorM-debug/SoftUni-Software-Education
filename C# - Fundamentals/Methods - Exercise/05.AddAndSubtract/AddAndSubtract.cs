internal class AddAndSubtract
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int sum = SumOfFirstTwoNumbers(a, b);
        int substract = SubtractThirdNumberfromTheSum(sum, c);
        Console.WriteLine(substract);
    }

    static int SumOfFirstTwoNumbers(int a, int b)
    {
        int sum = a + b;
        return sum;
    }

    static int SubtractThirdNumberfromTheSum(int sum, int c)
    {
        int subtract = sum - c;

        return subtract;
    }
}