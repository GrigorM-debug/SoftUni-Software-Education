Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();


string input = Console.ReadLine();

while (input != "end")
{
    string[] courseArgs = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string courseName = courseArgs[0];
    string studentName = courseArgs[1]; 

    if (!courses.ContainsKey(courseName))
    {
        courses.Add(courseName, new List<string>());
    }
    else
    {
        courses[courseName].Add(studentName);
    }

    input = Console.ReadLine();
}

foreach(var course in courses)
{
    Console.WriteLine($"{course.Key}: {courses.Count}");
    
    foreach(var user in course.Value) 
    {
        Console.WriteLine($"--{user}");
    }
}

//TODO