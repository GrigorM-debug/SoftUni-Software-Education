using System.Linq;
using System.Runtime.ExceptionServices;

List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();

List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

List<int> result = new List<int>();

int minList = Math.Min(listOne.Count, listTwo.Count);

for(int i = 0; i < minList; i++)
{
    result.Add(listOne[i]);
    result.Add(listTwo[i]);
}

if (listOne.Count > listTwo.Count)
{
    for (int i = minList; i < listOne.Count; i++)
    {
        result.Add(listOne[i]); 
    }
}
else if (listOne.Count < listTwo.Count)
{
    for (int i = minList; i < listTwo.Count; i++)
    {
        result.Add(listTwo[i]);
    }
}
Console.WriteLine(string.Join(" ", result));