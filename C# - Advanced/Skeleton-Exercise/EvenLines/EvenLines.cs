namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader readeer = new StreamReader(inputFilePath);

            int row = 0;
            string line = string.Empty;
            char[] separator = { '-', ',', '.', '!', '?' };

            StringBuilder sb = new();

            while (!readeer.EndOfStream) 
            { 
                line = readeer.ReadLine();  
                if (row++ % 2 == 0)
                {
                    foreach (char c in separator)
                    {
                        line = line.Replace(c, '@');
                    }

                    string[] reversed = line.Split(" ",  StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .ToArray();
                    
                    sb = sb.AppendLine(string.Join(" ", reversed));
                }
            }
            return sb.ToString();
        }
    }
}
