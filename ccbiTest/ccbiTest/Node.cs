using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccbiTest
{
    internal class Node
    {
        public Node next = null;
        public object data;

        public Node(object data)
        {
            this.data = data;
        }

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
