//Field Size
int n = int.Parse(Console.ReadLine());
int[] field = new int[n];


int[] initialIndexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

foreach(int index in initialIndexes)
{
    if (index >= 0 && index < initialIndexes.Length)
    {
        field[index] = 1;
    }
}

string command = Console.ReadLine();

while (command != "end")
{
    string[] cmdArgs = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int ladybugCurrIndex = int.Parse(cmdArgs[0]);
    string direction = cmdArgs[1];
    int flyLenght = int.Parse(cmdArgs[2]);

    if (ladybugCurrIndex < 0 || ladybugCurrIndex >= field.Length)
    {
        continue;
    }

    if (field[ladybugCurrIndex] == 0)
    {
        continue;
    }

    field[ladybugCurrIndex] = 0;

    if (direction == "left")
    {
        flyLenght *= -1;
    }

    int nextIndex = ladybugCurrIndex + flyLenght;

    while(nextIndex >= 0 &&  nextIndex < field.Length && field[ladybugCurrIndex] == 1)
    {
        nextIndex += flyLenght;
    }

    if (nextIndex < 0 || nextIndex >= field.Length)
    {
        continue;
    }

    field[nextIndex] = 1;

    Console.WriteLine(string.Join(" ", field));
}
