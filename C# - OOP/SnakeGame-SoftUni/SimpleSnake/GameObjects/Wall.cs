using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for(int lextX = 0; lextX < this.LeftX; lextX++)
            {
                this.Draw(lextX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int lextX)
        {
            for (int topY = 0; topY< this.TopY; topY++)
            {
                this.Draw(lextX, topY, wallSymbol);
            }
        }
    }
}
