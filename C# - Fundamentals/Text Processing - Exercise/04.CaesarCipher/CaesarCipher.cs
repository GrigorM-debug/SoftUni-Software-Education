string originalText = Console.ReadLine();

char[] encryptedText = new char[originalText.Length];

for (int i = 0; i < originalText.Length; i++)
{
    encryptedText[i] = (char)(originalText[i]+3);
}

Console.WriteLine(new string (encryptedText));