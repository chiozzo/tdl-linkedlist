using System;
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
            foreach (string value in values)
            {
                this.AddLast(value);
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get
            {
                return this.ElementAt(i);
            }
            set
            {
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                if (i == 0)
                {
                    newNode.Next = FirstNode.Next;
                    FirstNode = newNode;
                }
                SinglyLinkedListNode currentNode = FirstNode;
                int index = 1;
                while (index < i)
                {
                    currentNode = currentNode.Next;
                    index++;
                }
                currentNode.Next = newNode;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (FirstNode == null)
            {
                throw new ArgumentException();
            }
            else
            {
                SinglyLinkedListNode lastestNode = FirstNode;

                while (lastestNode.Value != existingValue)
                {
                    lastestNode = lastestNode.Next;
                    if (lastestNode == null)
                    {
                        throw new ArgumentException();
                    }
                }
                if (lastestNode.Value == existingValue)
                {
                    newNode.Next = lastestNode.Next;
                    lastestNode.Next = newNode;
                }
            }

            // Loop list and check value of each against existingValue.
            // If value of newNode is not present then throw new ArgumentException
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode newFirstNode = new SinglyLinkedListNode(value);
            if (FirstNode == null)
            {
                FirstNode = newFirstNode;
            }
            else
            {
                newFirstNode.Next = FirstNode;
                FirstNode = newFirstNode;
            }
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (this.First() == null)
            { // Why can't I use FirstNode.IsLast() for my conditional?
              // Null reference exception because you can't call a method on null.
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
        { // O(n) solution. What could be an O(1) solution? Capturing the length of the list as it's created?
            int counter = 0;

            if (this.First() == null)
            {
                return counter;
            }
            else
            {
                SinglyLinkedListNode lastestNode = FirstNode;
                counter++;
                while (!lastestNode.IsLast())
                {
                    lastestNode = lastestNode.Next;
                    counter++;
                }
                return counter;
            }
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode lastestNode = FirstNode;

            /* Work for negative index correcting for offset.
            if (index < 0)
            {
                index = index + Count();
            }
            */

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
            if (FirstNode == null)
            {
                return -1;
            }
            SinglyLinkedListNode lastestNode = FirstNode;
            int index = 0;

            while (lastestNode.Value != value)
            {
                lastestNode = lastestNode.Next;
                if (lastestNode == null)
                {
                    return -1;
                }
                index++;
            }
            return index;
        }

        public bool IsSorted()
        {
            if (FirstNode == null)
            {
                return true;
            }

            SinglyLinkedListNode indexNode = FirstNode;
            while (indexNode.Next != null)
            {
                if (String.Compare(indexNode.Value, indexNode.Next.Value) > 0)
                {
                    return false;
                }
                indexNode = indexNode.Next;
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (this.First() == null)
            {
                return null;
            }

            SinglyLinkedListNode lastestNode = FirstNode;

            while (!lastestNode.IsLast())
            {
                lastestNode = lastestNode.Next;
            }
            return lastestNode?.ToString();
        }

        public void Remove(string value)
        {
            if (FirstNode.Value == value)
            {
                FirstNode = FirstNode.Next;
                return;
            }
            SinglyLinkedListNode lastestNode = FirstNode;
            int index = 0;

            while (lastestNode.Next != null)
            {
                if (lastestNode.Next.Value == value)
                {
                    lastestNode.Next = lastestNode.Next.Next;
                    return;
                }
                lastestNode = lastestNode.Next;
                index++;
            }
            return;
        }

        public void Sort()
        {
            SinglyLinkedListNode indexNode = FirstNode;
            while (indexNode.Next != null)
            {
                if (String.Compare(indexNode.Value, indexNode.Next.Value) > 0)
                {
                    SinglyLinkedListNode tempNode = indexNode;
                    tempNode.Next = indexNode.Next.Next;
                    indexNode = indexNode.Next;
                    indexNode.Next = tempNode;
                }
                indexNode = indexNode.Next;
            }
        }

        public override string ToString()
        {
            if (this.First() == null)
            {
                return "{ }";
            }
            else
            {
                StringBuilder multiNodeString = new StringBuilder();
                multiNodeString.Append("{ \"" + this.First() + "\"");
                if (FirstNode.Next == null)
                {
                    multiNodeString.Append(" }");
                    return multiNodeString.ToString();
                }

                SinglyLinkedListNode lastestNode = FirstNode;
                while (!lastestNode.IsLast())
                {
                    lastestNode = lastestNode.Next;
                    multiNodeString.Append(", \"" + lastestNode.ToString() + "\"");
                }
                multiNodeString.Append(" }");
                return multiNodeString.ToString();
            }
        }

        public string[] ToArray()
        {
            int length = this.Count();
            string[] listValueArray = new string[length];
            if (FirstNode == null)
            {
                return new string[] { };
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    listValueArray[i] = this.ElementAt(i);
                }
                return listValueArray;
            }
        }
    }
}