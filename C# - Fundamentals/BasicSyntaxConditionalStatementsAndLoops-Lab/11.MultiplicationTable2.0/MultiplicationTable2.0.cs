int n = int.Parse(Console.ReadLine());
int multiplicater = int.Parse(Console.ReadLine());
int result = 0;

for (int i = multiplicater; i <= 10; i++)
{
    result = n * i;
    Console.WriteLine($"{n} X {i} = {result}");
}
if (multiplicater > 10)
{
    result = multiplicater * n;
    Console.WriteLine($"{n} X {multiplicater} = {result}");
    return;
}