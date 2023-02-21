double days = double.Parse(Console.ReadLine());
double dailyPlunder = double.Parse(Console.ReadLine());   
double expectedPlunder = double.Parse(Console.ReadLine());

double gainedPlunder = 0.0;

for (double i = 1; i <= days; i++)
{
    gainedPlunder += dailyPlunder;

    if (i % 3 == 0)
    {
        gainedPlunder += dailyPlunder * 0.5;
    }
    if (i % 5 == 0) 
    {
        gainedPlunder -= gainedPlunder * 0.3;
    }
}
if (gainedPlunder >= expectedPlunder)
{
    Console.WriteLine($"Ahoy! {gainedPlunder:F2} plunder gained.");
}
else if (gainedPlunder < expectedPlunder)
{
    double gainedPlunderInPercentage = (gainedPlunder / expectedPlunder) * 100;
    Console.WriteLine($"Collected only {gainedPlunderInPercentage:F2}% of the plunder.");
}