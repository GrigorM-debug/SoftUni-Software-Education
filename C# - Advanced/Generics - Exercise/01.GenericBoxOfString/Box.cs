using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> items = new();

        public void Add(T item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
