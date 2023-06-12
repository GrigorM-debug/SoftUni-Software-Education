using _08.Threeuple;

string[] peopleTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] beerTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] bamkTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Theeuple<string, string, string> nameAddressTown = new($"{peopleTokens[0]} {peopleTokens[1]}", peopleTokens[2], string.Join(" ", peopleTokens[3..]));

Theeuple<string, int, bool> beer = new(beerTokens[0], int.Parse(beerTokens[1]), beerTokens[2] == "drunk");

Theeuple<string, double, string> bank = new(bamkTokens[0], double.Parse(bamkTokens[1]), bamkTokens[2]);

Console.WriteLine(nameAddressTown);
Console.WriteLine(beer);
Console.WriteLine(bank);
