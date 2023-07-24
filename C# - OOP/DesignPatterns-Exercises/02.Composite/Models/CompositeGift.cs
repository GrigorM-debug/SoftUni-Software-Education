using _02.Composite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> _gifts;

        public CompositeGift(string name, decimal price) : base(name, price)
        {
            _gifts= new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal total = 0;

            Console.WriteLine($"{Name} contains following products with prices: ");

            foreach(var gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }
    }
}
