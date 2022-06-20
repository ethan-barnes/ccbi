using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccbiTest
{
    internal interface LinkedListInterface
    {        
        // A means of retrieving the data contained in a node at a given index.
        object DataAtIndex(int index);

        // A count of the nodes currently in the list.
        int Count();

        // Add a new object to the list.
        void Add(object data);

        // Add a new object to the list at a given index.
        void Add(object data, int index);

        // Remove a node at a given index.
        void Remove(int index);

        // Sorts the linked list.
        void Sort();
    }
}
