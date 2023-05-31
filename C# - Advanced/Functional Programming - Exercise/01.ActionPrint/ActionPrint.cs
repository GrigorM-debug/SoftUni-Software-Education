Action<string[]> printNames = input =>
{
    Console.WriteLine(string.Join(Environment.NewLine, input));
};

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printNames(input);