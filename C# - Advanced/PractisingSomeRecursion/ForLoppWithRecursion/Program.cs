namespace ForLoppWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(10);
        }

        static void Print(int numberOfPrints)
        {
            if(numberOfPrints == 0)
            {
                return;
            }

            Console.WriteLine($"Dimitrichko is Top1! {numberOfPrints}");

            Print(numberOfPrints - 1);
        }
    }
}