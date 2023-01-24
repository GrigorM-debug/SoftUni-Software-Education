int startingPoint = int.Parse(Console.ReadLine());
int endPoint = int.Parse(Console.ReadLine());   

for (int i = startingPoint; i<= endPoint; i++)
{
    char symbols = (char)i;

    Console.Write(symbols + " ");
}