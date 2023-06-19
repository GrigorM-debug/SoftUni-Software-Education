using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomStack
{
    public class CustomStack
    {
        private const int initialCapasity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            count = 0;
            items = new int[initialCapasity];
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(int element)
        {
            if (items.Length == Count)
            {
                var nextItem = new int[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    nextItem[i] = items[i];
                }
                items = nextItem;
            }
            items[count] = element;
            count++;
        }

        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var lastItem = count - 1;
            int last = items[lastItem];
            count--;
            return last;
        }

        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for(int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }
    }
}
