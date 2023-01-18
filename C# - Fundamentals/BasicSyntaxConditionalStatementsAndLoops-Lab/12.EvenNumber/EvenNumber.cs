using System.ComponentModel.Design;

int input = int.Parse(Console.ReadLine());

while (true)
{
    if (input %2 == 0)
    {
        if (input < 0)
        {
            Console.WriteLine($"The number is: {Math.Abs(input)}");
            break;
        }
        else
        {
            Console.WriteLine($"The number is: {input}");
            break;
        }
    }

   if (input %2 != 0)
    {
        Console.WriteLine($"Please write an even number.");
        input = int.Parse(Console.ReadLine());
    }
}