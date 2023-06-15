using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIteratorType
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> list) 
        {
            items = list;  
        }

        public bool Move()
        {
            if (index < items.Count-1)
            {
                index++;

                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (index < items.Count-1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            Console.WriteLine(items[index]);
        }
    }
}
