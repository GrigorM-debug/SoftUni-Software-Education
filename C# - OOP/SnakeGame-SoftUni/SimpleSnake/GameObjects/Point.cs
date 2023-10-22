using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point (int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }
    
        public int LeftX { get; set; }

        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            Console.Write(symbol);
        }

        public void Draw(int lextX, int topY, char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }
    }
}
