int numberOfPeople = int.Parse(Console.ReadLine());
int capasityP = int.Parse(Console.ReadLine());

int courses = (int)Math.Ceiling((double)numberOfPeople / capasityP);

Console.WriteLine(courses);