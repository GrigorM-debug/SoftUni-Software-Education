Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();


string input = Console.ReadLine();

while (input != "end")
{
    string[] courseArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string courseName = courseArgs[0];
    string studentName = courseArgs[1];

    if (!courses.ContainsKey(courseName))
    {
        courses.Add(courseName, new List<string>());
    }

    courses[courseName].Add(studentName);

    input = Console.ReadLine();
}

foreach(var course in courses)
{
    Console.WriteLine($"{course.Key}: {course.Value.Count}");
    
    foreach(var user in course.Value) 
    {
        Console.WriteLine($"-- {user}");
    }
}
