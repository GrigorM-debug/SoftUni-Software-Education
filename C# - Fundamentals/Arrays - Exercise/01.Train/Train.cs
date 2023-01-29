int input = int.Parse(Console.ReadLine());

int[] people = new int[input];

for (int i = 0; i < people.Length; i++)
{
    people[i] = int.Parse(Console.ReadLine()); 

}
Console.WriteLine(string.Join(" ", people));
int peopleCount = people.Sum();

Console.WriteLine(peopleCount); 
