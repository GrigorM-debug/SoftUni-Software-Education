namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCounts = new();

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadLine().Split(" ");

                foreach(var word in words)
                {
                    wordsCounts.Add(word.ToLower(), 0);
                }

                using (StreamReader inputReader = new StreamReader(textFilePath))
                {
                    string line = inputReader.ReadLine();

                    string[] inputWords = line.Split(" ");

                    foreach (var inputWord in inputWords)
                    {
                        string currWord = inputWord.ToLower();

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (currWord == words[i])
                            {
                                wordsCounts[currWord]++;
                            }
                        }
                    }

                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var wordCount in wordsCounts.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                }
            }
        }
    }
}
