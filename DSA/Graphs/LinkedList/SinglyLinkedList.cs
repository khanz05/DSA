using Graphs.BinaryTreeTopic;
using Graphs.LinkedList;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.LinkedListOperations
{
    internal class SinglyLinkedList
    {
        #region Insert in Singly LL

        public void InsertAtHead(ref SingleNode head, int data)
        {
            if (head == null)
            {
                SingleNode newNode = new SingleNode(data);
                head = newNode;
            }
            else
            {
                SingleNode temp = new SingleNode(data);
                temp.next = head;
                head = temp;
            }
        }

        public void InsertAtTail(ref SingleNode tail, int data)
        {
            SingleNode temp = new SingleNode(data);
            tail.next = temp;
            tail = tail.next;
        }

        public void InsertAtPosition(ref SingleNode head, ref SingleNode tail, int data, int position)
        {
            SingleNode temp = head;

            if (position == 1)
            {
                InsertAtHead(ref head, data);
                return;
            }

            int cnt = 1;
            while (cnt < position - 1)
            {
                temp = temp.next;
                cnt++;
            }

            if (temp.next == null)
            {
                InsertAtTail(ref tail, data);
            }

            //Insert at position other than head/tail
            SingleNode nodeToInsert = new SingleNode(data);
            nodeToInsert.next = temp.next;
            temp.next = nodeToInsert;
        }

        #endregion

        #region Delete at position in Singly LL

        public void DeleteAtPosition(ref SingleNode head, int position)
        {
            if (position == 1)
            {
                head = head.next;
            }
            else
            {
                int cnt = 1;
                SingleNode current = head;
                SingleNode prev = null;

                while (cnt < position)
                {
                    cnt++;
                    prev = current;
                    current = current.next;
                }

                prev.next = current.next;
            }
        }

        #endregion

        #region Is Circular

        public bool IsCircular(SingleNode head)
        {
            if (head == null)
            {
                return true;
            }

            SingleNode temp = head.next;
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

        #region Remove duplicate from Unsorted LL

        public void RemoveDuplicateMap(ref SingleNode head)
        {
            if (head == null)
            {
                return;
            }

            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            SingleNode current = head;
            SingleNode prev = null;

            while (current != null)
            {
                if (visited.ContainsKey(current.data) && visited[current.data] == true)
                {
                    prev.next = current.next;
                }
                else
                {
                    visited[current.data] = true;
                    prev = current;
                }

                current = current.next;
            }

        }

        #endregion

        #region Sort LL

        public void SortUsingMerge(ref SingleNode headRef)
        {
            SingleNode head = headRef;
            SingleNode a;
            SingleNode b;

            //base case
            if (head == null || head.next == null)
            {
                return;
            }

            SplitLL(head, out a, out b);

            //Recursive call
            SortUsingMerge(ref a);

            SortUsingMerge(ref b);

            headRef = SortMergeLL(a, b);
        }

        private void SplitLL(SingleNode head, out SingleNode frontRef, out SingleNode backRef)
        {
            SingleNode fast = head.next;
            SingleNode slow = head;

            while (fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                    slow = slow.next;
                }
            }

            frontRef = head;
            backRef = slow.next;
            slow.next = null;
        }

        private SingleNode SortMergeLL(SingleNode a, SingleNode b)
        {
            SingleNode result = null;

            if (a == null)
            {
                return b;
            }
            else if (b == null)
            {
                return a;
            }

            if (a.data < b.data)
            {
                result = a;
                result.next = SortMergeLL(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortMergeLL(a, b.next);
            }

            return result;
        }

        #endregion

        #region Sort 0's, 1's, 2's

        public void SortUsingCountApproachOne(ref SingleNode head)
        {
            if (head == null)
            {
                return;
            }

            SingleNode temp = head;
            int zeroCount = 0;
            int oneCount = 0;
            int twoCount = 0;

            while (temp != null)
            {
                if (temp.data == 0)
                {
                    zeroCount++;
                }
                else if (temp.data == 1)
                {
                    oneCount++;
                }
                else if (temp.data == 2)
                {
                    twoCount++;
                }
                temp = temp.next;
            }

            temp = head;

            while (temp != null)
            {
                if (zeroCount != 0)
                {
                    temp.data = 0;
                    zeroCount--;
                }
                else if (oneCount != 0)
                {
                    temp.data = 1;
                    oneCount--;
                }
                else if (twoCount != 0)
                {
                    temp.data = 2;
                    twoCount--;
                }

                temp = temp.next;
            }
        }

        public void SortUsingApproachTwo(ref SingleNode head)
        {
            SingleNode zeroHead = new SingleNode(-1);
            SingleNode zeroTail = zeroHead;
            SingleNode oneHead = new SingleNode(-1);
            SingleNode oneTail = oneHead;
            SingleNode twoHead = new SingleNode(-1);
            SingleNode twoTail = twoHead;

            SingleNode current = head;

            while (current != null)
            {
                int val = current.data;
                if (val == 0)
                {
                    //SortInsertAtTailApproachTwo(ref zeroTail, val);
                    SortInsertAtTailApproachTwo(ref zeroTail, current);
                }
                else if (val == 1)
                {
                    //SortInsertAtTailApproachTwo(ref oneTail, val);
                    SortInsertAtTailApproachTwo(ref oneTail, current);
                }
                else if (val == 2)
                {
                    //SortInsertAtTailApproachTwo(ref twoTail, val);
                    SortInsertAtTailApproachTwo(ref twoTail, current);
                }

                current = current.next;
            }

            if (oneHead.next != null)
            {
                zeroTail.next = oneHead.next;
            }
            else
            {
                zeroTail.next = twoHead.next;
            }

            oneTail.next = twoHead.next;
            twoTail.next = null;

            head = zeroHead.next;
        }

        private void SortInsertAtTailApproachTwo(ref SingleNode tail, int data)
        {
            SingleNode temp = new SingleNode(data);
            tail.next = temp;
            tail = tail.next;
        }

        private void SortInsertAtTailApproachTwo(ref SingleNode tail, SingleNode current)
        {
            tail.next = current;
            tail = current;
        }

        #endregion

        #region Merge 2-Sorted LL

        public SingleNode MergeTwoSortedLinkedListUsingRecursion(SingleNode a, SingleNode b)
        {
            SingleNode headRef = null;
            headRef = SortMergeLL(a, b);

            return headRef;
        }

        public SingleNode MergeTwoSortedLinkedListUsingIteration(SingleNode a, SingleNode b)
        {
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.data <= b.data)
            {
                return solve(a, b);
            }
            else
            {
                return solve(b, a);
            }
        }

        private SingleNode solve(SingleNode first, SingleNode second)
        {
            if (first.next == null)
            {
                first.next = second;
                return first;
            }

            SingleNode current1 = first;
            SingleNode next1 = current1.next;

            SingleNode current2 = second;
            SingleNode next2 = current2.next;

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

        #region Palindrome

        /// <summary>
        /// S.C -> O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ref SingleNode head)
        {
            ArrayList arr = new ArrayList();
            SingleNode temp = head;

            while (temp != null)
            {
                arr.Add(temp.data);
                temp = temp.next;
            }

            return CheckPalindrome(arr);
        }

        private bool CheckPalindrome(ArrayList arr)
        {
            int n = arr.Count;
            int s = 0;
            int e = n - 1;

            while (s <= e)
            {
                if (!arr[s].Equals(arr[e]))
                {
                    return false;
                }
                s++;
                e--;
            }

            return true;
        }

        #endregion

        #region Add Two Linked List

        public SingleNode AddTwoNumbers(SingleNode l1, SingleNode l2)
        {

            //Step-1: Reverse both list
            l1 = ReverseList(l1);
            l2 = ReverseList(l2);

            //Step-2: Add both list
            SingleNode ans = AddNode(l1, l2);

            //Step-3: Reverse ans
            ans = ReverseList(ans);

            return ans;
        }

        private SingleNode AddNode(SingleNode first, SingleNode second)
        {
            SingleNode addHead = null;
            SingleNode addTail = null;
            int carry = 0;

            while (first != null || second != null || carry != 0)
            {
                int val1 = 0;
                if (first != null)
                    val1 += first.data;

                int val2 = 0;
                if (second != null)
                    val2 += second.data;

                int sum = val1 + val2 + carry;
                int digit = sum % 10;

                //Create node
                InsertAtTail(ref addHead, ref addTail, digit);

                carry = sum / 10;
                if (first != null)
                    first = first.next;

                if (second != null)
                    second = second.next;
            }

            return addHead;
        }

        private void InsertAtTail(ref SingleNode head, ref SingleNode tail, int data)
        {
            SingleNode temp = new SingleNode(data);
            if (head == null)
            {
                head = temp;
                tail = temp;
            }
            else
            {
                tail.next = temp;
                tail = temp;
            }
        }

        private SingleNode ReverseList(SingleNode head)
        {
            SingleNode current = head;
            SingleNode prev = null;
            SingleNode next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public SingleNode AddTwoNumbersOther(SingleNode l1, SingleNode l2)
        {
            int carry = 0;
            SingleNode firstNode = null;
            SingleNode currentNode = null;
            while (l1 != null || l2 != null || carry != 0)
            {
                var l1Data = l1 != null ? l1.data : 0;
                var l2Data = l2 != null ? l2.data : 0;

                var sum = l1Data + l2Data + carry;

                int remainder;
                var quotient = Math.DivRem(sum, 10, out remainder);
                carry = quotient;
                var newNode = new SingleNode(remainder);
                if (firstNode == null)
                {
                    firstNode = newNode;
                    currentNode = newNode;
                }
                else
                {
                    currentNode.next = newNode;
                    currentNode = currentNode.next;
                }

                l1 = l1?.next;
                l2 = l2?.next;
            }
            return firstNode;

        }

        #endregion

        #region Print Linked List

        public void PrintHead(ref SingleNode head)
        {
            SingleNode temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine("\n");
        }

        #endregion
    }

    public class SingleNode
    {
        public int data;
        public SingleNode next;
        public SingleNode(int val)
        {
            this.data = val;
            next = null;
        }
    }


}
