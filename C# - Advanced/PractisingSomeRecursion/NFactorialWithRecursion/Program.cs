namespace NFactorialWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(NFactorial(n));
        }

        static int NFactorial(int n) 
        { 
            if (n == 1)
            {
                return 1;
            }

            return n * NFactorial(n - 1);
        }
    }
}