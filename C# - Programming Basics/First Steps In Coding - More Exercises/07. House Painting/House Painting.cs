using System;
using System.Globalization;

namespace _07._House_Painting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Вход
            double houseHeigh = double.Parse(Console.ReadLine());
            double houseLenght = double.Parse(Console.ReadLine());
            double triangleWallOnRoofHeigh = double.Parse(Console.ReadLine());
            
            //Изчисления стени
            double sideWallArea = houseHeigh * houseLenght;
            double windowArea = 1.5 * 1.5;
            double sideWallsTotal = 2 * sideWallArea - 2 * windowArea;
            double backWall = houseHeigh * houseHeigh;
            double entrance = 1.2 * 2;
            double frontAndBackWallTotal = 2 * backWall - entrance;
            double totalArea = sideWallsTotal + frontAndBackWallTotal;
            double greenPaint = totalArea / 3.4;

            //Изчисления покрив
            double twoRoofRectangle = 2 * (houseHeigh * houseLenght);
            double twoTriangle = 2 * (houseHeigh * triangleWallOnRoofHeigh / 2);
            double triangleTotal = twoRoofRectangle + twoTriangle;
            double redPaint = triangleTotal / 4.3;

            //Изход
            Console.WriteLine("{0:F2}", greenPaint);
            Console.WriteLine("{0:F2}", redPaint);
        }
    }
}
