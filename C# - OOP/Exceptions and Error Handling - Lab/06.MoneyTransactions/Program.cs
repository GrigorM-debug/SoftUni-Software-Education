List<string> bankAccounts = Console.ReadLine().Split(",").ToList();


Dictionary<int, double> account = new Dictionary<int, double>();    

for (int i = 0; i < bankAccounts.Count; i++)
{
    string[] bankAccount = bankAccounts[i].Split("-");
    int accountNumber = int.Parse(bankAccount[0]);
    double accountBalance = double.Parse(bankAccount[1]);

    account.Add(accountNumber, accountBalance);
}


string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    int number = int.Parse(commandArgs[1]);
    string command = commandArgs[0];

    try
    {
        if (command == "Deposit")
        {

            double sum = double.Parse(commandArgs[2]);

            if (!account.ContainsKey(number))
            {
                throw new ArgumentException("Invalid account!");
            }
            else
            {
                account[number] += sum;
            }
        }
        else if (command == "Withdraw")
        {

            double sum = double.Parse(commandArgs[2]);

            if (!account.ContainsKey(number))
            {
                throw new ArgumentException("Invalid account!");
            }
            else if(sum > account[number])
            {
                throw new ArgumentException("Insufficient balance!");
            }
            else
            {
                account[number] -= sum;
            }
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {number} has new balance: {account[number]:f2}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}
