List<string> cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] commandInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

    if (commandInfo[0] == "Add")
    {
        if (cards.Contains(commandInfo[1]))
        {
            Console.WriteLine("Card is already in the deck");
        }
        else
        {
            cards.Add(commandInfo[1]);
            Console.WriteLine("Card successfully added");
        }
    }
    else if (commandInfo[0] == "Remove")
    {
        if (cards.Contains(commandInfo[1]))
        {
            cards.Remove(commandInfo[1]);
            Console.WriteLine("Card successfully removed");
        }
        else
        {
            Console.WriteLine("Card not found");
        }
    }
    else if (commandInfo[0] == "Remove At")
    {
        int index = int.Parse(commandInfo[1]);
        if (index < 0 || index > cards.Count)
        {
            Console.WriteLine("Index out of range");
        }
        else
        {
            cards.RemoveAt(index);
            Console.WriteLine("Card successfully removed");
        }
    }
    else if (commandInfo[0] == "Insert")
    {
        int index = int.Parse(commandInfo[1]);
        string cardName = commandInfo[2];

        if (index < 0 || index > cards.Count)
        {
            Console.WriteLine("Index out of range");
        }
        else
        {
            if (cards.Contains(cardName))
            {
                Console.WriteLine("Card is already added");
            }  
            else
            {
                cards.Insert(index, cardName);
                Console.WriteLine("Card successfully added");
            }
        }
    }
}
Console.WriteLine(string.Join(", ", cards));