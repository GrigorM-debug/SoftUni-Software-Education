string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Random random = new Random();

for (int i = 0; i < words.Length; i++)
{
    int randomIndex = random.Next(0, words.Length);

    string currentWord = words[i];
    string wordToSwap = words[randomIndex];

    words[i] = wordToSwap;
    words[randomIndex] = currentWord;
}
Console.WriteLine(string.Join(Environment.NewLine, words));