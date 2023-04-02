string key = Console.ReadLine();

string input = Console.ReadLine();

while(input != "Generate")
{
    string[] operationArgs = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

    string operation = operationArgs[0];

    if(operation == "Contains")
    {
        string substring = operationArgs[1];    

        if (key.Contains(substring))
        {
            Console.WriteLine($"{key} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }
    else if (operation == "Flip")
    {
        string UpperLower = operationArgs[1];
        int startIndex = int.Parse(operationArgs[2]);
        int endIndex = int.Parse(operationArgs[3]);
        int length = endIndex- startIndex;

        if (UpperLower == "Lower")
        {
            string subs = key.Substring(startIndex, length);
            string subsToLower = subs.ToLower();
            key = key.Replace(subs, subsToLower);
        }
        else if (UpperLower == "Upper")
        {
            string subs = key.Substring(startIndex, length);
            string subsToUpper = subs.ToUpper();
            key = key.Replace(subs, subsToUpper);
        }
        Console.WriteLine(key);
    }
    else if (operation == "Slice")
    {
        int startIndex = int.Parse(operationArgs[1]);
        int endIndex = int.Parse(operationArgs[2]);
        int lenght = endIndex- startIndex;
        key = key.Remove(startIndex, lenght);

        Console.WriteLine(key);
    }
    input = Console.ReadLine(); 
}
Console.WriteLine($"Your activation key is: {key}");