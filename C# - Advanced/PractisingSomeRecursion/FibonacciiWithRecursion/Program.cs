using System.Reflection.Metadata.Ecma335;

namespace FibonacciiWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonaccii(fib));
        }

        private static int Fibonaccii(int fib)
        {
            if(fib == 0)
            {
                return 0;
            }
            if(fib == 1 || fib == 2)
            {
                return 1;
            }

            return Fibonaccii(fib - 1) + Fibonaccii(fib - 2);
        }
    }
}