using System;

namespace _06.Building
{
    internal class Building
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int roomsCnt = int.Parse(Console.ReadLine());

            for (int i = floor; i >= 1; i--)
            {
                for (int j = 0; j < roomsCnt; j++)
                {
                    if (i == floor)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    else if (i % 2 ==0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                }
                Console.WriteLine(); //When rooms on floor are equal to roomsCnt we tell the program to go on new line for other rooms. 

            }
           
        }
    }
}
