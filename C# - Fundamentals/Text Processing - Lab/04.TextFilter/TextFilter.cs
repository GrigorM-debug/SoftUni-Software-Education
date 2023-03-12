string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

string text = Console.ReadLine();

foreach(string bannedWord in bannedWords)
{
    text = text.Replace(bannedWord, new string('*', bannedWord.Length));
}
Console.WriteLine(text);