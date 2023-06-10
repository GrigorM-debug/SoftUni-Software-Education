using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoubleLinkedList
{
    public class DoublyLinkedList
    {
        private bool IsReversed = false;

        public Nodes Head { get; set; }
        public Nodes Tail { get; set; }

        public int Count { get; set; }

        public void Reverse()
        {
            var oldHead = Head;
            Head = Tail;
            Tail = oldHead;
            IsReversed = !IsReversed;
        }

        public void AddFirst(int element)
        {
            if(Count ==0)
            {
                Head = Tail = new Nodes(element);
            }
            else
            {
                Nodes newHead = new Nodes(element);
                newHead.NextNode = Head;
                Head.PreviousNode = newHead;
                Head = newHead;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if(Count ==0)
            {
                Head = Tail = new Nodes(element);   
            }
            else
            {
                Nodes newTail = new Nodes(element);
                newTail.PreviousNode = Tail;
                newTail.NextNode = newTail;
                Tail = newTail;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int firstElement = this.Head.Value;
            Head = Head.NextNode;

            if(Head!= null)
            {
                Head.PreviousNode = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int lastElement = this.Tail.Value;
            Tail = Tail.NextNode;

            if (Tail != null)
            {
                Tail.PreviousNode = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<Nodes> action)
        {
            Nodes currNode = Head;
      
            while(currNode != null)
            {
                action(currNode);

                if (IsReversed)
                {
                    currNode = currNode.PreviousNode;
                }
                else
                {
                    currNode = currNode.NextNode;
                }
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            Nodes currNode = this.Head;
            while(currNode != null)
            {
                array[counter] = currNode.Value;
                currNode = currNode.NextNode;
                counter++;
            }

            return array;
        }
    }
}
