using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.LinkedList
{
    internal class CircularSinglyLinkedList
    {
        #region Insert Node

        public void InsertNode(ref CircularSingleNode tail, int element, int data)
        {
            //empty list
            if (tail == null)
            {
                CircularSingleNode newNode = new CircularSingleNode(data);
                tail = newNode;
                newNode.next = newNode;
            }
            else
            {
                CircularSingleNode current = tail;

                while (current.data != element)
                {
                    current = current.next;
                }

                CircularSingleNode temp = new CircularSingleNode(data);
                temp.next = current.next;
                current.next = temp;
            }
        }

        #endregion

        #region Is Linked List Circular

        public bool IsCircular(CircularSingleNode head)
        {
            if (head == null)
            {
                return true;
            }

            CircularSingleNode temp = head.next;
            while (temp != null && temp != head)
            {
                temp = temp.next;
            }

            if (temp == head)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Detect Loop/Starting point of Loop/Remove Loop

        private CircularSingleNode hasCycle(CircularSingleNode head)
        {
            CircularSingleNode fast = head;
            CircularSingleNode slow = head;

            while (slow != null && fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                }

                slow = slow.next;

                if (slow == fast)
                {
                    return slow;
                }
            }

            return null;
        }

        public CircularSingleNode IntersectionPoint(CircularSingleNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return null;

            CircularSingleNode intersection = hasCycle(head);
            if (intersection == null)
                return null;

            CircularSingleNode slow = head;

            while (slow != intersection)
            {
                slow = slow.next;
                intersection = intersection.next;
            }

            return slow;
        }

        public void removeLoop(CircularSingleNode head)
        {
            CircularSingleNode intersection = IntersectionPoint(head);

            CircularSingleNode temp = intersection;
            while (temp.next != intersection)
            {
                temp = temp.next;
            }

            temp.next = null;
        }

        #endregion

        #region Print 

        public void PrintCircluarSingle(ref CircularSingleNode tail)
        {
            CircularSingleNode temp = tail;
            do
            {
                Console.Write(tail.data + " ");
                tail = tail.next;
            }
            while (tail != temp);

            Console.WriteLine("\n");
        }

        #endregion
    }

    public class CircularSingleNode
    {
        public int data;
        public CircularSingleNode next;

        public CircularSingleNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
}
