using System.Runtime.CompilerServices;
Dictionary<string, List<double>> academy = new Dictionary<string, List<double>>();  

int numberOfInputs = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfInputs; i++)
{
    string studentName = Console.ReadLine();    
    double grade = double.Parse(Console.ReadLine());    

    if (!academy.ContainsKey(studentName))
    {
        academy.Add(studentName, new List<double>());

    }

    academy[studentName].Add(grade);
}

foreach(var student in academy)
{
    if (student.Value.Average() >= 4.5)
    {
        Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
    }
}