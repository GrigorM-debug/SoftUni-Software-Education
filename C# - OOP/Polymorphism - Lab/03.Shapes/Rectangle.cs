using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return (this.height * 2) + (this.width * 2);
        }
    }
}
