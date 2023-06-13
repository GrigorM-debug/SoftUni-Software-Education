namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> numbers = new(30, 30);

            Console.WriteLine(numbers.AreEqual());
        }
    }
}