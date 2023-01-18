
string userName = Console.ReadLine();
string password = new string(userName.Reverse().ToArray());

int failedAttemps = 0;

while (true)
{
    string givedPassword = Console.ReadLine();
    if (givedPassword == password)
    {
        Console.WriteLine($"User {userName} logged in.");
        break;
    }
    else
    {
        failedAttemps++;    
        Console.WriteLine($"Incorrect password. Try again.");
    }
    if (failedAttemps == 3)
    {
        Console.WriteLine($"User {userName} blocked!");
        break;
    }
}
