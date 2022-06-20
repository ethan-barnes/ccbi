using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccbiTest
{
    internal class LinkedList<Type> : LinkedListInterface
    {
        private Node Root = null;

        // Gets the last node in the list, used when adding a node to the end of the list.
        private Node Last
        {
            get
            {
                Node current = Root;
                if (current == null)
                {
                    return null;
                }
                while (current.next != null)
                {
                    current = current.next;
                }
                return current;
            }
        }

        // Constructor to create a linked list using existing list of data.
        public LinkedList(List<Type> data)
        {
            foreach (var item in data)
            {
                if (item != null)
                    Add(item);
            }
        }

        // Constructor to create an empty linked list.
        public LinkedList() { }
        
        // Used to retrieve the data of any node in the list when given its position.
        public object DataAtIndex(int index)
        {
            return NodeAtIndex(index).data;
        }

        // Used to retrieve any node in the list when given its position.
        public Node NodeAtIndex(int index)
        {
            int count = 0;
            Node current = Root;
            while (count != index)
            {
                current = current.next;
                count++;
            }
            return current;
        }

        // Returns the number of Nodes in the list.
        public int Count()
        {
            int count = 1;
            Node current = Root;
            if (current == null)
            {
                return 0;
            }
            while (current.next != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }

        // Adds a Node to the end of the list. If the list is empty it will assign it to the Root node.
        public void Add(object data)
        {
            Node node = new Node(data);
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Last.next = node;
            }
        }

        // Adds a node to a specific position within the list.
        public void Add(object data, int index)
        {
            int count = 1; // Correcting offset so this works with GetDataAtIndex(). e.g. Add(data, 1) will be the same as GetDataAtIndex(1)
            Node node = new Node(data);
            Node current = Root;

            // Changing the value of root if the node is added to the start of the list.
            if (index == 0)
            {
                node.next = Root;
                Root = node;                
            }
            else
            {
                while (count != index && current.next != null) // Looping to the correct position.
                {
                    current = current.next;
                    count++;
                }
                node.next = current.next;
                current.next = node;
            }
        }

        // Removes references to Node at specified index. The node before index will now point to the node after index.
        public void Remove(int index)
        {
            int count = 0;
            Node current = Root;
            Node previous = null;
            if (index == 0)
            {
                Root = current.next;
            }
            else
            {
                while (count != index)
                {
                    previous = current;
                    current = current.next;
                    count++;
                }
                previous.next = current.next;
            }            
        }

        // Bubble sort to sort by population in ascending order.
        public void Sort()
        {
            int size = Count();
            object temp;
            if (size > 1) // If the list has 0 or 1 Node it is already sorted. 
            {
                // Nested for loop to compare every Node with eachother.
                for (int i = 0; i < size; i++)
                {
                    for (int j = i + 1; j < size; j++)
                    {
                        // Getting data as a Country object, not the best solution as rest of class is generic.
                        Country c1 = (Country)DataAtIndex(i);
                        Country c2 = (Country)DataAtIndex(j);
                        if (c1.GetPopulation() > c2.GetPopulation())
                        {
                            // Swaps the data within the nodes.
                            temp = DataAtIndex(i);
                            NodeAtIndex(i).data = DataAtIndex(j);
                            NodeAtIndex(j).data = temp;
                        }
                    }
                }
            } 
        }
    }
}
