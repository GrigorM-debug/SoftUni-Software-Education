using System;

namespace _04.PasswordGuess
{
    internal class PasswordGuess
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();
            string password = "s3cr3t!P@ssw0rd";

            if (inputPassword == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
