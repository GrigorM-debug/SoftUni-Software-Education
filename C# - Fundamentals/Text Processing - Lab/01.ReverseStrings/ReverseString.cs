string input = Console.ReadLine();

while (input != "end")
{
    char[] reversedWord = input.Reverse().ToArray();

    Console.WriteLine($"{input} = { string.Join("", reversedWord)}");

    input = Console.ReadLine();
}