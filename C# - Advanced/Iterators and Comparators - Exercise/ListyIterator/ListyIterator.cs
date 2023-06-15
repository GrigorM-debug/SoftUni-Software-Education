using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ListyIteratorType
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            Console.WriteLine(string.Join(" ", items));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < items.Count-1; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
