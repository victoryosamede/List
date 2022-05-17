using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class DataStructuresPractice<T> where T : class
    {
        public ListNode<T>? Head { get; set; }
        public ListNode<T>? Tail { get; set; }
        public int Length { get; internal set; }

        public void AddFirst(T item)
        {
            if (Head == null)
            {
                Head = Tail = new ListNode<T> (item);
            }
            else 
            { 
                var temp = Head;
                var newNode = new ListNode<T> (item,temp);
                Head.PreviousNode = newNode;
                Head = newNode;
            }
            Length++;
        }

        public int FindIndex(T item)
        {
            var currentNode = new ListNode<T> (item);
            int index = 0;
            while (index < Length)
            {
                currentNode = Head;
                if (currentNode?.Value == item)
                {
                    return index;
                }
                currentNode = currentNode?.NextNode;
                index++;
            }

            return -1;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                var node = Head;
                Head = node.NextNode;
                Head.PreviousNode = null;
                Length--;
            }

            if (index == Length - 1)
            {
                var node = Tail;
                Tail = node.PreviousNode;
                Tail.NextNode = null;
                Length--;
            }

            var currentNode = Head;
            int counter = 0;
            while (counter < index)
            {
                currentNode = currentNode?.NextNode;
                counter++;
            }

            currentNode.NextNode.PreviousNode = currentNode.PreviousNode;
            currentNode.PreviousNode.NextNode = currentNode.NextNode;
            Length--;
            currentNode.NextNode = null;
            currentNode.PreviousNode = null;
        }

        public void Clear (T item)
        {
            var currentNode = Head;
            for (int i = 0; i < Length; i++)
            {
                currentNode = currentNode?.NextNode;
            }
            currentNode = null;
            Head.PreviousNode = null;
            Length--;
        }
        public void AddLast(T item)
        {
            if ( Head == null && Tail == null)
            {
                Head = Tail = new ListNode<T> (item);
            }
            else
            {
                var newNode = new ListNode<T> (item);
                Tail.NextNode = newNode;
                Tail = newNode;
            }
        }

         public int IndexOf(T item)
        {
            var currentNode = Head;
            for (int i = 0; i < Length; i++)
            {
                if (currentNode.Equals(item))
                    
                    return i;
                    
                currentNode=currentNode.NextNode;
            }
            return -1;
        }
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }
    }
}
