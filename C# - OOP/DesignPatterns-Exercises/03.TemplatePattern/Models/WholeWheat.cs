using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TemplatePattern.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingreadients for Whole Wheat Bread.");
        }
    }
}
