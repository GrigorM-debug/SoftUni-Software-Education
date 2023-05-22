using System.Net.Http.Headers;

int numberOFInputs = int.Parse(Console.ReadLine());

Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();


for (int i =0; i < numberOFInputs; i++)
{
   var input = Console.ReadLine().Split();

    string name = input[0];
    decimal grade = decimal.Parse(input[1]);

    if (!students.ContainsKey(name))
    {
        students.Add(name, new List<decimal>());
    }

    students[name].Add(grade);
}


foreach(var student in students)
{
    Console.Write($"{student.Key} -> ");
    
    foreach(var grade in student.Value)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {student.Value.Average():f2})");
}
