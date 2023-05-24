int n = int.Parse(Console.ReadLine());

HashSet<string> usernames = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    usernames.Add(Console.ReadLine());
}
foreach(var username in usernames)
{ 
    Console.WriteLine(username); 
}