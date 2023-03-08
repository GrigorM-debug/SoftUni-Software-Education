Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

string input = Console.ReadLine();

while(input!="End")
{
    string[] cmdArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string company = cmdArgs[0];
    string employeedId = cmdArgs[1];

    if (!companyUsers.ContainsKey(company))
    {
        companyUsers[company] = new List<string>();
    }

    if (!companyUsers[company].Contains(employeedId))
    {
        companyUsers[company].Add(employeedId);
    }

    input = Console.ReadLine();
}

foreach(var company in companyUsers)
{
    Console.WriteLine($"{company.Key}");

    foreach(var user in company.Value)
    {
        Console.WriteLine($"-- {user}");
    }
}