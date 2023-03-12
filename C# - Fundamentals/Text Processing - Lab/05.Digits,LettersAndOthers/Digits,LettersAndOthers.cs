string input = Console.ReadLine();


Console.WriteLine(string.Join("", input.Where(char.IsDigit)));
Console.WriteLine(string.Join("", input.Where(char.IsLetter)));
Console.WriteLine(string.Join("", input.Where(x=> !char.IsDigit(x) && !char.IsLetter(x))));