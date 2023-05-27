int count = int.Parse(Console.ReadLine());

Dictionary<int, int> numbersCNT = new();  

for (int i = 0; i < count; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (!numbersCNT.ContainsKey(number))
    {
        numbersCNT.Add(number, 0);
    }
    numbersCNT[number]++;
}

foreach(var number in numbersCNT)
{
    if (number.Value % 2 == 0)
    {
        Console.WriteLine(number.Key);
    }
}

//Second way
//Console.WriteLine(numbersCNT.Single(x => x.Value % 2 == 0).Key);