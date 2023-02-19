using System.Transactions;

double numberOfCities = double.Parse(Console.ReadLine());

decimal profitForCity = 0.0M;
decimal totalProfit = 0.0m;

for (int i = 1; i <= numberOfCities; i++)
{
    string nameOfCity = Console.ReadLine(); 
    decimal ownerIncomes = decimal.Parse(Console.ReadLine()); 
    decimal ownerExpences = decimal.Parse(Console.ReadLine());    

    if (i % 3 == 0 && i % 5 != 0)
    {
        ownerExpences *= 1.5m;
    }
    else if (i % 5 == 0)
    {
        ownerIncomes *= 0.9m;
    }

    profitForCity = ownerIncomes - ownerExpences;

    Console.WriteLine($"In {nameOfCity} Burger Bus earned {profitForCity:f2} leva.");

    totalProfit += profitForCity;
}

Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");