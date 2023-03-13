string input = Console.ReadLine();

string fileName = Path.GetFileNameWithoutExtension(input);
string fileExtension = Path.GetExtension(input).Trim('.');

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");