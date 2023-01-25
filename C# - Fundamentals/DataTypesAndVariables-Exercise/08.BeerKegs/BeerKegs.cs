int numberOfInputs = int.Parse(Console.ReadLine());
double max = double.MinValue;
double volume = 0.0;
string model = "";
string biggestKeg = "";
for (int i = 0; i < numberOfInputs; i++)
{
    model = Console.ReadLine();
    double rasdius = double.Parse(Console.ReadLine());  
    int height = int.Parse(Console.ReadLine());

    volume = Math.PI * (rasdius * rasdius) * height;
    
    if (volume > max)
    {
        max = volume;
        biggestKeg = model; 
    }
}
Console.WriteLine(biggestKeg);

