string studentName = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
double averageGrade = double.Parse(Console.ReadLine());

Console.Write($"Name: {studentName}, Age: {age}, Grade: {averageGrade:f2}");