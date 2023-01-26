int power = int.Parse(Console.ReadLine());
int distance = int.Parse(Console.ReadLine());  
int factor = int.Parse(Console.ReadLine());

int pokedTargetsCnt = 0;
double percent = power * 0.5;
while (power >= distance)
{
    pokedTargetsCnt++;
    power = power - distance;
    if (power == percent && factor !=0)
    {
        power = power / factor;
        if (power < distance)
        {
            break;
        }
    }
}
Console.WriteLine(power);
Console.WriteLine(pokedTargetsCnt);