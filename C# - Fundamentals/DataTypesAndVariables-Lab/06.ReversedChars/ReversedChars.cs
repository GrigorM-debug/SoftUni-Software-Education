char firstSymbol = char.Parse(Console.ReadLine());
char secondSymbol = char.Parse(Console.ReadLine());
char thirdSymbol = char.Parse(Console.ReadLine());

string firstSymbolToString = char.ToString(firstSymbol);
string secondSymbolToString = char.ToString(secondSymbol);  
string thirdSymbolToString = char.ToString(thirdSymbol);

Console.WriteLine($"{thirdSymbolToString} {secondSymbolToString} {firstSymbolToString}");