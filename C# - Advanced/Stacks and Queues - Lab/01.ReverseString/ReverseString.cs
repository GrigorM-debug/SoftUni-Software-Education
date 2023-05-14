string input = Console.ReadLine();

Stack<char> reversedString = new Stack<char>();

foreach(var item in input)
{
    reversedString.Push(item);
}

while (reversedString.Any())
{
    Console.Write(reversedString.Pop());
}