int number = int.Parse(Console.ReadLine());

try
{
    double numberRoot =  Math.Sqrt(number);

    if(number < 0)
    {
        throw new ArithmeticException("Invalid number.");
    }
    Console.WriteLine(numberRoot);
}
catch(ArithmeticException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}