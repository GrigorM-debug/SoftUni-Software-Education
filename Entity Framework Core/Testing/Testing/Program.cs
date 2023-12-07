

int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();


List<int> tallestCandles = new List<int>();

for (int i = 0; i < candles.Count - 1; i++)
{
    int currTallCanddle =candles[i];


    if (candles[i + 1] >= currTallCanddle)
    {
        currTallCanddle = candles[i + 1];
        continue;
        //tallestCandles.Add(currTallCanddle);
    }
    tallestCandles.Add(currTallCanddle);
}

return tallestCandles.Count;