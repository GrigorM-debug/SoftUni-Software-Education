using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int initialCapasity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            count = 0;
            items = new T[initialCapasity];
        }

        public int Count { get; private set; }

        public void Push (T element)
        {
            if(items.Length == Count)
            {
                T[] nextItems = new T[items.Length * 2];

                for (int i = 0; i < Count; i++)
                {
                    nextItems[i] = items[i];
                }
                items = nextItems;
            }
            items[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var lastItem = Count - 1;
            T last = items[lastItem];
            Count--;

            return last;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++) 
            {
                action(items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
