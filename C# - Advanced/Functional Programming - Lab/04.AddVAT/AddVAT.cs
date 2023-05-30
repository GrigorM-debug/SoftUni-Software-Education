//Func<double, double> AddVAT = n => n * 1.2;

double[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(n => n * 1.2)
    //.Select(n => AddVAT(n))
    .ToArray();

foreach(double number in numbers)
{
    Console.WriteLine($"{number:f2}");
}