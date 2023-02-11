using System;

namespace _07.RepeatString
{
    internal class RepeatString
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string result = RepeatStr(str, count);
            Console.WriteLine(result);
        }

        static string RepeatStr(string str, int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += str;
            }

            return result;
        }
        
    }
}
