Dictionary<string, List<double>> orders = new Dictionary<string, List<double>>();

string input = Console.ReadLine();

while (input != "buy")
{
    string[] cmdInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string productName = cmdInfo[0];
    double productPrice = double.Parse(cmdInfo[1]);
    double productQuantity = double.Parse(cmdInfo[2]);

    if (!orders.ContainsKey(productName))
    {
        orders.Add(productName, new List<double>() { productPrice, productQuantity});
    }
    else
    {
        orders[productName][0] = productPrice;
        orders[productName][1] += productQuantity;
    }

    input= Console.ReadLine();
}

foreach (var order in orders)
{
    double totalPrice = order.Value[0] * order.Value[1];

    Console.WriteLine($"{order.Key} -> {totalPrice:f2}");
}