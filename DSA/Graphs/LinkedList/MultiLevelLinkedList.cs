using Graphs.LinkedListOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.LinkedList
{
    internal class MultiLevelLinkedList
    {
        #region MyRegion

        public Node FlattenNode(Node head)
        {
            //base case
            if (head == null || head.next == null)
            {
                return head;
            }

            //Node down = head;
            //head = down.next;
            //down.next = null;

            Node right = FlattenNode(head.next);

            Node ans = merge(head, right);
           
            return ans;
        }

        Node merge(Node root, Node newHead)
        {
            Node dummy = new Node(-1), ptr1 = root, ptr2 = newHead;
            Node dummyPtr = dummy;

            while (ptr1 != null && ptr2 != null)
            {
                if (ptr1.data <= ptr2.data)
                {
                    dummyPtr.bottom = ptr1;
                    ptr1.next = null;
                    ptr1 = ptr1.bottom;
                }
                else
                {
                    dummyPtr.bottom = ptr2;
                    ptr2.next = null;
                    ptr2 = ptr2.bottom;
                }
                dummyPtr = dummyPtr.bottom;
            }

            if (ptr1 != null) dummyPtr.bottom = ptr1;
            if (ptr2 != null) dummyPtr.bottom = ptr2;

            return dummy.bottom;
        }

        private Node MergeLL(Node down, Node right)
        {
            if (down== null)
            {
                return right;
            }

            if (right == null)
            {
                return down;
            }

            Node resultHead = null;
            Node resultTail = null;
            while (down != null && right != null)
            {
                if (down.data <= right.data)
                {
                    InsertAtTail(ref resultHead, ref resultTail, down.data);
                    down = down.bottom;
                }
                else
                {
                    InsertAtTail(ref resultHead, ref resultTail, right.data);
                    right = right.bottom;
                }
            }

            while (down != null)
            {
                if (down.bottom != null)
                {
                    if (down.data < down.bottom.data)
                    {
                        InsertAtTail(ref resultHead, ref resultTail, down.data);
                        down = down.bottom;
                    }
                    else
                    {
                        InsertAtTail(ref resultHead, ref resultTail, down.bottom.data);
                        down = down.bottom;
                    }
                }
                else
                {
                    InsertAtTail(ref resultHead, ref resultTail, down.data);
                    down = down.bottom;
                }
            }

            while (right != null)
            {
                if (right.bottom != null)
                {
                    if (right.data < right.bottom.data)
                    {
                        InsertAtTail(ref resultHead, ref resultTail, right.data);
                        right = right.bottom;
                    }
                    else
                    {
                        InsertAtTail(ref resultHead, ref resultTail, right.bottom.data);
                        right = right.bottom;
                    }
                }
                else
                {
                    InsertAtTail(ref resultHead, ref resultTail, right.data);
                    right = right.bottom;
                }
            }

            return resultHead;
            

            //if (a.data <= b.data)
            //{
            //    return solve(a, b);
            //}
            //else 
            //{
            //    return solve(b, a);
            //}
        }

        private void InsertAtTail(ref Node head, ref Node tail, int data)
        {
            Node temp = new Node(data);
            if (head == null)
            {
                head = temp;
                tail = temp;
                return;
            }
            else
            {
                tail.bottom = temp;
                tail = temp;
            }
        }

        private Node solve(Node first, Node second)
        {
            if (first.next == null)
            {
                first.next = second;
                return first;
            }

            Node current1 = first;
            Node next1 = first.next;

            Node current2 = second;
            Node next2 = second.next;
            while (next1 != null && current2 != null)
            {
                if ((current1.data <= current2.data) && (next1.data >= current2.data))
                {
                    current1.next = current2;
                    next2 = current2.next;
                    current2.next = next1;

                    //Update pointer
                    current1 = current2;
                    current2 = next2;
                }
                else
                {
                    current1 = next1;
                    next1 = next1.next;

                    if (next1 == null)
                    {
                        current1.next = current2;
                        return first;
                    }
                }
            }

            return first;
        }



        #endregion

        #region GFG

        //public Node FlattenNode(Node head)
        //{
        //    if (head == null || head.next == null)
        //    {
        //        return head;
        //    }

        //    head.next = FlattenNode(head.next);

        //    head = MergeLL(head, head.next);

        //    return head;
        //}

        //private Node MergeLL(Node a, Node b)
        //{
        //    if (a == null)
        //    {
        //        return b;
        //    }

        //    if (b == null)
        //    {
        //        return a;
        //    }

        //    Node result = null;
        //    if (a.data < b.data)
        //    {
        //        result = a;
        //        result.bottom = MergeLL(a.bottom, b);
        //    }
        //    else
        //    {
        //        result = b;
        //        result.bottom = MergeLL(a, b.bottom);
        //    }

        //    result.next = null;
        //    return result;
        //} 

        #endregion


        public Node Push(Node head_ref, int data)
        {
            /*
             * 1 & 2: Allocate the Node & Put in the data
             */
            Node new_node = new Node(data);

            /* 3. Make next of new Node as head */
            new_node.bottom = head_ref;

            /* 4. Move the head to point to new Node */
            head_ref = new_node;

            /* 5. return to link it back */
            return head_ref;
        }

        public void printList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.bottom;
            }
            Console.WriteLine();
        }

        public void PrintHead(ref Node head)
        {
            Node temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine("\n");
        }


        public Node head; // head of list

        /* Linked list Node */
        public class Node
        {
            public int data;
            public Node next, bottom;

            public

            Node(int data)
            {
                this.data = data;
                next = null;
                bottom = null;
            }
        }
    }
}
