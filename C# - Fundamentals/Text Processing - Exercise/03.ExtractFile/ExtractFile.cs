string[] input = Console.ReadLine().Split("\\");
string file = input[input.Length - 1];
string[] splitLastWord = file.Split('.'); 
string fileName = splitLastWord[0];
string fileExtension = splitLastWord[1];    

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");