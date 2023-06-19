using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;
        private int count;

        public CustomQueue()
        {
            count = 0;
            items = new int[InitialCapacity];
        }

        public int Count => count;

        public void Enqueue(int item)
        {
            if(items.Length == count)
            {
                IncreaseSize();
            }

            items[count] = item;
            count++;
        }

        private void IncreaseSize()
        {
            int[] copy = new int[items.Length * 2];
            items.CopyTo(copy, 0);
            items = copy;
        }

        public int Dequeue()
        {
            IsEmpty();
            count--;
            var firstItem = items[FirstElementIndex];
            SwitchElements();
            return firstItem;
        }

        private void SwitchElements()
        {
            items[FirstElementIndex] = default;

            for(int i =0; i < items.Length; i++)
            {
                items[i-1] = items[i];  
            }

            items[items.Length - 1] = default;
        }

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

        public int Peek()
        {
            if (count == 0)
            {
                IsEmpty();
            }

            return items[FirstElementIndex];
        }

        public void Clear()
        {
            items = new int[InitialCapacity];

            count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i =0; i < count; i++)
            {
                action(items[i]);
            }
        }
    }
}
