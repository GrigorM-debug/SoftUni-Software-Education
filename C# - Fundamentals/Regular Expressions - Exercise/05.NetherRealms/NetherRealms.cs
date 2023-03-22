using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        var demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(demonName => new Demon(demonName)).OrderBy(demon => demon.Name);

        foreach(var demon in demons)
        {
            Console.WriteLine($"{demon.Name} - {demon.HealthPoints} health, {demon.DamagePoints:f2} damage");
        }
    }
}

class Demon
{
    public Demon(string name)
    {
        Name = name;
        DamagePoints = CalculateDamage(name);
        HealthPoints = CalculateHealth(name);
    }

    public string Name { get; set; }

    public double DamagePoints { get; set; }

    public int HealthPoints { get; set; }

    private int CalculateHealth(string name)
    {
        string pattern = @"[^\+\-\*\/\.\,0-9 ]";
        MatchCollection matches = Regex.Matches(name, pattern);

        int health = 0;
        foreach (Match match in matches)
        {
            char currCharacter = char.Parse(match.Value);
            health += currCharacter;
        }
        return health;
    }

    private double CalculateDamage(string name)
    {
        string pattern = @"-?\d+\.?\d*";
        MatchCollection matches = Regex.Matches(name, pattern);
        var baseDamage = matches.Select(d => double.Parse(d.Value)).Sum();

        foreach(char currCharacter in name)
        {
            if (currCharacter == '*')
            {
                baseDamage *= 2;
            }
            else if (currCharacter == '/')
            {
                baseDamage /= 2;
            }
        }

        return baseDamage;
    }
}