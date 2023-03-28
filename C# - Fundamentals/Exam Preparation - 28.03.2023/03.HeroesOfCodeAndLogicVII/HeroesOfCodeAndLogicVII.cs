using System.Reflection;

Dictionary<string , Hero> heroes = new Dictionary<string , Hero>(); 

int numberOfInputs = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfInputs; i++)
{
    string[] heroInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = heroInfo[0];
    int HP = int.Parse(heroInfo[1]);
    int MP = int.Parse(heroInfo[2]);

    if (HP > 100)
    {
        HP = 100;
    }
    if (MP > 200)
    {
        MP = 200;
    }

    Hero hero = new Hero (name, HP, MP);    

    if (!heroes.ContainsKey(name))
    {
        heroes.Add(name, hero);
    }
}

string input = Console.ReadLine();


while (input != "End")
{
    string[] commandArgs = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
    
    string command = commandArgs[0];

    //string name = commandArgs[1];   
    if (command == "CastSpell")
    {
        string name = commandArgs[1];
        int MPNeeded = int.Parse(commandArgs[2]);
        string spellName = commandArgs[3];

        Hero hero = heroes[name];

        if (hero.ManaPoints >= MPNeeded)
        {
            heroes[name].ManaPoints -= MPNeeded;
            Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].ManaPoints} MP!");
        }
        else
        {
            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
        }
    }
    else if (command == "TakeDamage")
    {
        string name = commandArgs[1];
        int damage = int.Parse(commandArgs[2]);
        string attacker = commandArgs[3];

        Hero hero = heroes[name];
        
        hero.HealthPoints -= damage;
        
        if (hero.HealthPoints > 0)
        {
            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hero.HealthPoints} HP left!");
        }
        else
        {
            heroes.Remove(name);
            Console.WriteLine($"{name} has been killed by {attacker}!");
        }
    }
    else if (command == "Recharge")
    {
        string name = commandArgs[1];
        int MPToRestore = int.Parse(commandArgs[2]);

        Hero hero = heroes[name];

        hero.ManaPoints += MPToRestore;

        if (hero.ManaPoints > 200)
        {
            int restoreMP = 200 - (hero.ManaPoints - MPToRestore);
            hero.ManaPoints = 200;
            Console.WriteLine($"{name} recharged for {restoreMP} MP!");
        }
        else
        {
            Console.WriteLine($"{name} recharged for {MPToRestore} MP!");
        }
    }
    else if (command == "Heal")
    {
        string name = commandArgs[1];
        int HPToRestore = int.Parse(commandArgs[2]);

        Hero hero = heroes[name];

        hero.HealthPoints += HPToRestore;

        if (hero.HealthPoints > 100)
        {
            int restoreHP = 100 - (hero.HealthPoints -= HPToRestore);
            hero.HealthPoints = 100;
            Console.WriteLine($"{name} healed for {restoreHP} HP!");
        }
        else
        {
            Console.WriteLine($"{name} healed for {HPToRestore} HP!");
        }
    }
    input = Console.ReadLine();
}

foreach ( var (name, hero) in heroes)
{
    Console.WriteLine($"{name}");
    Console.WriteLine($" HP: {hero.HealthPoints}");
    Console.WriteLine($" MP: {hero.ManaPoints}");
}

class Hero
{
    public string Name { get; set; }

    public int HealthPoints { get; set; }

    public int ManaPoints { get; set; }

    public Hero(string name, int HP, int MP)
    {
        Name = name;
        HealthPoints = HP;
        ManaPoints = MP;
    }
}