List<int> integers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

int countOfExceptions = 0;

while (countOfExceptions < 3)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string commandType = command[0];

    try
    {
        if (commandType == "Replace")
        {
            int index = int.Parse(command[1]);
            int element = int.Parse(command[2]);

            integers[index] = element;
        }
        else if (commandType == "Print")
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            if (startIndex < 0 || startIndex >= integers.Count || endIndex < 0 || endIndex >= integers.Count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i < endIndex)
                {
                    Console.Write($"{integers[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{integers[i]}");
                }
            }
        }
        else if (commandType == "Show")
        {
            int index = int.Parse(command[1]);
            Console.WriteLine(integers[index]);
        }

        //Console.WriteLine(string.Join(", ", integers));
    }
    catch (IndexOutOfRangeException)
    {
        countOfExceptions++;
        Console.WriteLine("The index does not exist!");
    }
    catch (FormatException)
    {
        countOfExceptions++;
        Console.WriteLine("The variable is not in the correct format!");
    }
}
Console.WriteLine(string.Join(", ", integers));