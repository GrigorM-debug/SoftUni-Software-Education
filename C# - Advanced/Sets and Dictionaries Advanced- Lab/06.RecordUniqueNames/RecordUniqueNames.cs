int numberOfInputs = int.Parse(Console.ReadLine());

HashSet<string> names = new HashSet<string>(); 

for (int i =0; i < numberOfInputs; i++)
{
    names.Add(Console.ReadLine());
}

foreach(var name in names)
{
    Console.WriteLine(name);
}