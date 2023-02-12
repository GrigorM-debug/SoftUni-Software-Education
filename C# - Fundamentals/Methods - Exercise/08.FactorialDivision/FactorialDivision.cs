internal class FactorialDivision
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        double result = Factorial(a, b);
        Console.WriteLine($"{result:f2}");
    }
    
    static double Factorial(int a, int b)
    {
        double firstNumberFactorial = 1;
        double secondNumberFacrial = 1;

        for (int i = 1; i <= a; i++)
        {
            firstNumberFactorial = firstNumberFactorial * i;
        }
        
        for (int j = 1; j <= b; j++)
        {
            secondNumberFacrial = secondNumberFacrial * j;
        }
        return firstNumberFactorial / secondNumberFacrial;
    }
}