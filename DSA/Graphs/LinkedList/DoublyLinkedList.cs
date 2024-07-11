using Graphs.LinkedListOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.LinkedList
{
    internal class DoublyLinkedList
    {
        #region Insert in Doubly LL

        public void InsertAtHeadDoubly(ref DoubleNode head, int data)
        {
            DoubleNode temp = new DoubleNode(data);
            temp.next = head;
            head.prev = temp;
            head = temp;
        }

        public void InsertAtTailDoubly(ref DoubleNode tail, int data)
        {
            DoubleNode temp = new DoubleNode(data);
            tail.next = temp;
            temp.prev = tail;
            tail = temp;
        }

        public void InsertAtPositionDoubly(ref DoubleNode head, ref DoubleNode tail, int data, int position)
        {
            if (position == 1)
            {
                InsertAtHeadDoubly(ref head, data);
                return;
            }

            DoubleNode temp = head;
            int cnt = 1;
            while (cnt < position - 1)
            {
                cnt++;
                temp = temp.next;
            }

            //this is tail
            if (temp.next == null)
            {
                InsertAtTailDoubly(ref tail, data);
                return;
            }

            DoubleNode nodeToInsert = new DoubleNode(data);
            nodeToInsert.next = temp.next;
            temp.next.prev = nodeToInsert;
            temp.next = nodeToInsert;
            nodeToInsert.prev = temp;

        }

        #endregion

        #region Delete in Doubly LL

        public void DeleteDoublyAtPosition(ref DoubleNode head, int position)
        {
            if (position == 1)
            {
                DoubleNode temp = head;
                temp.next.prev = null;
                head = temp.next;
            }
            else
            {
                int cnt = 1;
                DoubleNode current = head;
                DoubleNode prev = null;

                while (cnt < position)
                {
                    cnt++;
                    prev = current;
                    current = current.next;
                }

                prev.next = current.next;
                if (current.next != null)
                {
                    current.next.prev = current.prev;
                }

                current.prev = null;
            }
        }



        #endregion

        #region Print Linked List
        
        public void PrintHeadDouble(ref DoubleNode head)
        {
            DoubleNode temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine("\n");
        }

        #endregion
    }

    public class DoubleNode
    {
        public int data;
        public DoubleNode next;
        public DoubleNode prev;
        public DoubleNode(int val)
        {
            this.data = val;
            next = null;
            prev = null;
        }
    }
}
