string input = Console.ReadLine();

List<Student> students = new List<Student>();

while (input != "end")
{
    string[] studentInfo = input.Split();

    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    int age = int.Parse(studentInfo[2]);
    string homeTown = studentInfo[3];

    bool isStudentExist = false;

    foreach (var student in students)
    {
        if (firstName == student.FirstName && lastName == student.LastName)
        {
            isStudentExist = true;
            break;
        }
    }

    if(isStudentExist)
    {
        foreach (var student in students)
        {
            if (firstName == student.FirstName && lastName == student.LastName)
            {
                student.Age = age;
                student.Hometown = homeTown;
            }
        }
    }
    else
    {
        Student student = new Student();
        {
            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;
            student.Hometown = homeTown;
        };
        students.Add(student);
    }
    input = Console.ReadLine();
}


string cityName = Console.ReadLine();

foreach (Student student in students)
{
    if (student.Hometown == cityName)
    {
        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
    }
}


class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Hometown { get; set; }
}