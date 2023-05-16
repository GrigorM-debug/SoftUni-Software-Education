using System.Net.NetworkInformation;

int n = int.Parse(Console.ReadLine());

Queue<string> trafficJam = new Queue<string>(); 

string input = Console.ReadLine();

int totalCarsPassed = 0;

while (input != "end")
{
    if (input != "green")
    {
        trafficJam.Enqueue(input);
        input = Console.ReadLine();
        continue;
    }
    else
    {
        int currNumber = n;
        while (trafficJam.Count > 0 && currNumber > 0)
        {
            Console.WriteLine($"{trafficJam.Dequeue()} passed!");
            currNumber--;
            totalCarsPassed++;
        }
    }
    input = Console.ReadLine(); 
}
Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");