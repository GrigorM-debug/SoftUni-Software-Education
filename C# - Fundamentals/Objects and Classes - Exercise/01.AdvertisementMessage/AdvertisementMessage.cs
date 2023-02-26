using System.Runtime.Intrinsics.X86;
using System;
int numberOfGeneratateMassages = int.Parse(Console.ReadLine());

string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };

string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

for (int i = 0; i < numberOfGeneratateMassages; i++)
{
    Random random = new Random();
    string randomPhrases = phrases[random.Next(phrases.Length)];
    string randomEvents = events[random.Next(events.Length)];
    string randomAuthors = authors[random.Next(authors.Length)];
    string randomCities = cities[random.Next(cities.Length)];

    Console.WriteLine($"{randomPhrases} {randomEvents} {randomAuthors} - {randomCities}");
}
