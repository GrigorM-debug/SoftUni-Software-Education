using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoubleLinkedList
{
    public class Nodes
    {
        public int Value { get; set; }

        public Nodes NextNode { get; set; }

        public Nodes PreviousNode { get; set; }

        public Nodes(int value)
        {
            Value = value;
        }
    }
}
