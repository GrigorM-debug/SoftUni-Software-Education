using System.Text.Unicode;

Predicate<int[], int, string, int> EvenOrOdd = (start, end, command)=>
{
    List<int> odd = new();
    List<int> even = new();
    for (int i = start; i <= end; i++)
    {
        if (i % 2 == 0)
        {
            result.Add(i);
        }
        else if (command= "odd" && i % 2 != 0)
        {
            
        }
    }
};



int[] ranges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

int start = ranges[0];
int end = ranges[1];
string command = Console.ReadLine();