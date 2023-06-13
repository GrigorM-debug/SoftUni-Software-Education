namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            int[] numbers = ArrayCreator.Create(32, 32);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}