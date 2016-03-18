﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode FirstNode { get; set; }

        public SinglyLinkedList list { get; set; }

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (this.First() == null)
            { // Why can't I use FirstNode.IsLast() for my conditional?
                FirstNode = newNode;
            }
            else
            {
                SinglyLinkedListNode lastestNode = FirstNode;

                while (!lastestNode.IsLast())
                {
                    lastestNode = lastestNode.Next;
                }
                // Need to store temp as a node somewhere as a private property/datamember.
                // See SSLN.cs line 14-33
                /* To prevent this next line from becoming moot, due to garbage collection,
                    I need to store newNode as the Next property of... what? 
                    Do I need to store latestNode as a property of the class?*/
                lastestNode.Next = newNode;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode lastestNode = FirstNode;

            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < index; i++)
            {
                lastestNode = lastestNode.Next;
            }
            return lastestNode.ToString();
        }

        public string First()
        {
            return FirstNode?.ToString();
        } // SSLN.ToString(), modified to return value property of SSLN.

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            throw new NotImplementedException();
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
