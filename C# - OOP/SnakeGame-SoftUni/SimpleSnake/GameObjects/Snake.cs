using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private Wall wall;
        private Food[] food;
        private int foodIndex;


        public Snake(Wall wall)
        {
            snakeElements = new Queue<Point>();
            this.wall = wall;
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        private void CreateSnake()
        {
            for(int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(wall);
            this.food[2] = new FoodAsterisk(wall);
        }
    }
}
