string input = Console.ReadLine();

List<Box> boxes = new List<Box>();  

while (input != "end")
{
    string[] itemData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int serialNumber = int.Parse(itemData[0]);
    string itemName = itemData[1];  
    int itemQuantity = int.Parse(itemData[2]);
    decimal itemPrice = decimal.Parse(itemData[3]);

    Item item = new Item()
    {
        Name = itemName,
        Price = itemPrice,
    };
    Box box = new Box()
    {
        SerialNumber = serialNumber,
        Item = item, 
        ItemQuantity = itemQuantity,
        PriceForBox = itemPrice * itemQuantity,  
    };
    boxes.Add(box);

    input = Console.ReadLine(); 
}

foreach(var box in boxes.OrderByDescending(x => x.PriceForBox))
    {
    Console.WriteLine(box.SerialNumber);
    Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
    Console.WriteLine($"-- ${box.PriceForBox:f2}");
}


class Item
{
    public string Name { get; set; }

    public decimal Price { get; set; }  
}

class Box
{
    public int SerialNumber { get; set; }

    public Item Item { get; set; }  

    public int ItemQuantity { get; set; }

    public decimal PriceForBox { get; set; }
}
