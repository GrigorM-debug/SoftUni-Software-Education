int initialEnergy = int.Parse(Console.ReadLine());

string input  = Console.ReadLine();

bool flag = true;
int battlesWon = 0;

while (input != "End of battle")
{
    int distance = int.Parse(input);

    if (initialEnergy - distance < 0)
    {
        flag= false;
        break;
    }

    initialEnergy-= distance;
    battlesWon++;

    if (battlesWon % 3 == 0)
    {
        initialEnergy += battlesWon;
    }

    input = Console.ReadLine(); 
}
if (flag)
{
    Console.WriteLine($"Won battles: {battlesWon}. Energy left: {initialEnergy}");
}
else
{
    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {initialEnergy} energy");
}