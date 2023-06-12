using _07.Tuple;

string[] peopleTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] beerTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numbersTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> names = new($"{peopleTokens[0]} {peopleTokens[1]}", peopleTokens[2]);

CustomTuple<string, int> beer = new(beerTokens[0], int.Parse(beerTokens[1]));

CustomTuple<int, double> numbers = new(int.Parse(numbersTokens[0]), double.Parse(numbersTokens[1]));

Console.WriteLine(names);
Console.WriteLine(beer);
Console.WriteLine(numbers);
