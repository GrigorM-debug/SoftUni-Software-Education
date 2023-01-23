decimal britishPounds = decimal.Parse(Console.ReadLine());

decimal oneBritishPoundToDollars = 1.31m; // one british pound is equal to 1.31 dollars

decimal dollars = britishPounds * oneBritishPoundToDollars;

Console.WriteLine($"{dollars:f3}");