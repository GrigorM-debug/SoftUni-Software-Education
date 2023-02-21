List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

string input = Console.ReadLine();  

while (input != "end")
{
    string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (commandInfo[0] == "Insert")
    {
        int element = int.Parse(commandInfo[1]);
        int position = int.Parse(commandInfo[2]);

        numbers.Insert(position, element);
    }
    else if (commandInfo[0] == "Delete")
    {
        int element = int.Parse(commandInfo[1]);

       for(int i = 0; i < numbers.Count; i++) 
        {
            if (numbers.Contains(element))
            {
                numbers.Remove(element);
            }
        }
    }
    input= Console.ReadLine();
}
Console.WriteLine(string.Join(" ", numbers));