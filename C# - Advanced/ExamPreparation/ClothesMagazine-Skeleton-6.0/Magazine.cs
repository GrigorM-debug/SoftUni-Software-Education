using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count < this.Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            var clotheeToRemove = this.Clothes.FirstOrDefault(x => x.Color == color);

            bool isRemoved = this.Clothes.Remove(clotheeToRemove);

            return isRemoved;
        }

        public Cloth GetSmallestCloth()
        {
            return this.Clothes.OrderBy(x => x.Size).FirstOrDefault();
        }

        public Cloth GetCloth(string color) 
        {
            return this.Clothes.FirstOrDefault(x=> x.Color == color);
        }

        public int GetClothCount()
        {
            return  this.Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains:");
            

            foreach(var cloth in this.Clothes.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
