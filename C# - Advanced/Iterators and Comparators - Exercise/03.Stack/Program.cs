using _03.Stack;

CustomStack<int> customStack = new CustomStack<int>();

string command;
while((command = Console.ReadLine()) != "END")
{
    List<string> tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

    string action = tokens[0];

    switch (action)
    {
        case "Push":
            int[] numbersToPush = tokens.Skip(1).Select(int.Parse).ToArray();

            foreach(var item in numbersToPush)
            {
                customStack.Push(item);
            }
            break;
        case "Pop":
            try
            {
                customStack.Pop();
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            break;
    }
}

foreach (var item in customStack)
{
    Console.WriteLine(item);
}

foreach (var item in customStack)
{
    Console.WriteLine(item);
}
