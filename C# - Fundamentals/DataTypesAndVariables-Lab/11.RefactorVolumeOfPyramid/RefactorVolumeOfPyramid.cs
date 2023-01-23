Console.Write("Length: ");
double lenght = double.Parse(Console.ReadLine());

Console.Write("Width: ");
double width = double.Parse(Console.ReadLine());

Console.Write("Height: ");
double height = double.Parse(Console.ReadLine());  

double volumeOfPiramid = (lenght * width * height) / 3;

Console.WriteLine($"Pyramid Volume: {volumeOfPiramid:f2}");
