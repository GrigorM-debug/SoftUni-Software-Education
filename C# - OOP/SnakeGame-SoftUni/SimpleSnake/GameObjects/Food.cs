using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char symbol;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points) : base(wall.LeftX, wall.TopY)
        {
            wall = wall;
            FoodPoints = points;
            foodSymbol = foodSymbol;
            random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPossition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY-2); 

            bool isPointOfSnake = snakeElements.Any(x=> x.LeftX == this.LeftX && x.TopY == this.TopY);

            while(isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor= ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == TopY && snake.LeftX== LeftX;
        }
    }
}
