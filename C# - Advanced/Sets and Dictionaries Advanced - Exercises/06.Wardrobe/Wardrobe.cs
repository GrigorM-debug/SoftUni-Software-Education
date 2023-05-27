int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> colorsClothes = new();

for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine()
        .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

    string color = tokens[0];

    if (!colorsClothes.ContainsKey(color))
    {
        colorsClothes.Add(color, new Dictionary<string, int>());
    }
    for(int j = 1; j < tokens.Length; j++)
    {
        string wear = tokens[j];
        if (!colorsClothes[color].ContainsKey(wear))
        {
            colorsClothes[color].Add(wear, 0);
        }

        colorsClothes[color][wear]++;
    }
}
string[] itemToFind = Console.ReadLine().Split(" ");

foreach (var colorClothe in colorsClothes)
{
    Console.WriteLine($"{colorClothe.Key} clothes:");

    foreach(var wearCnt in colorClothe.Value)
    {
        string textToPrint = $"* {wearCnt.Key} - {wearCnt.Value}";

        if (colorClothe.Key == itemToFind[0] && wearCnt.Key == itemToFind[1])
        {
            textToPrint += " (found!)";
        }
        Console.WriteLine(textToPrint);
    }
}

