List<int> people = new();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int person = int.Parse(Console.ReadLine());
    people.Add(person);
}

int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Swap(indexes[0], indexes[1], people);

foreach (var person in people)
{
    Console.WriteLine($"{typeof(int)}: {person}");
}

void Swap<T>(int firstIndex, int secondIndex, List<T> people)
{
    (people[secondIndex], people[firstIndex]) = (people[firstIndex], people[secondIndex]); //using tuple
}