int countOfStudents = int.Parse(Console.ReadLine());

List<Students> students = new List<Students>();

for (int i = 0; i < countOfStudents; i++)
{
    string[] studentsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    string firstName = studentsInfo[0];
    string lastName = studentsInfo[1];
    double grade = double.Parse(studentsInfo[2]);

    Students student = new Students(firstName, lastName, grade);

    students.Add(student);
}

foreach (var student in students.OrderByDescending(x=>x.Grade))
{
    Console.WriteLine(student);
}

class Students
{
    public Students(string firstName, string lastName, double grade) 
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; set; }    

    public string LastName { get; set; }

    public double Grade { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:f2}";
    }
}