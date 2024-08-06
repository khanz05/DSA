using NetTopologySuite.Triangulate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.StackAndQueue
{
    internal class StackImplementation
    {
        public StackImplementation()
        {

        }

        #region Custom Stack implementation

        public int top;
        public int size;
        public int[] arr;

        public StackImplementation(int size)
        {
            this.size = size;
            arr = new int[size];
            top = -1;
        }

        //Push
        public void Push(int element)
        {
            if (top < size)
            {
                top++;
                arr[top] = element;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }

        //Pop
        public void Pop()
        {
            if (top >= 0)
            {
                arr[top] = -1;
                top--;
            }
            else
                Console.WriteLine("Stack Underflow");
        }

        //Peek
        public void Peek()
        {
            if (top >= 0)
            {
                Console.WriteLine(arr[top]);
            }
            else
                Console.WriteLine("Stack is Empty");
        }

        //Empty
        public bool isEmpty()
        {
            if (top == 0)
                return true;
            else
                return false;
        }

        #endregion

        #region Reverse String Using Stack

        public void ReverseString(string str)
        {
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                s.Push(str[i]);
            }

            string ans = string.Empty;

            while (s.Any())
            {
                char ch = s.Pop();
                ans = ans + ch;
            }

            Console.WriteLine($"Reverse of {str} -> {ans}");
        }

        #endregion

        #region Delete Mid In Stack

        public void DeleteMidInStack(ref int[] arr)
        {
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
                s.Push(arr[i]);

            solve(ref s, 0, s.Count());

            int index = s.Count() - 1;
            arr = new int[s.Count()];
            while (s.Any())
            {
                int num = s.Pop();
                arr[index] = num;
                index--;
            }
        }

        private void solve(ref Stack<int> s, int count, int size)
        {
            if (count == size / 2)
            {
                s.Pop();
                return;
            }

            int num = s.Pop();
            solve(ref s, count + 1, size);

            s.Push(num);
        }

        #endregion

        #region Valid Parenthesis

        public bool IsValid(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '(' || ch == '[' || ch == '{')
                    st.Push(ch);
                else
                {
                    if (st.Any())
                    {
                        char top = st.Peek();
                        if (matches(ch, top))
                            st.Pop();
                        else
                            return false;

                    }
                    else
                        return false;
                }
            }

            if (st.Any())
                return true;
            else
                return false;
        }

        private bool matches(char ch, char top)
        {
            if (ch == ')' && top == '(')
                return true;
            if (ch == ']' && top == '[')
                return true;
            if (ch == '}' && top == '{')
                return true;

            return false;
        }

        #endregion

        #region Insert at Bottom

        public void InsertAtBottom(ref Stack<int> st, int val)
        {
            if (!st.Any())
            {
                st.Push(val);
                return;
            }

            int num = st.Pop();
            InsertAtBottom(ref st, val);

            st.Push(num);
        }

        #endregion

        #region Reverse a Stack using Recursion

        public void ReverseStackUsingRecursion(Stack<int> st)
        {
            solve(ref st);

            if (st.Any())
            {
                Console.WriteLine("Reverse Stack Using Recursion");
            }

            while (st.Any())
            {
                int top = st.Pop();
                Console.Write(top + " ");
            }
        }

        private void solve(ref Stack<int> st)
        {
            if (!st.Any())
                return;

            int num = st.Pop();

            solve(ref st);

            InsertAtBottom(ref st, num);
        }



        #endregion

        #region Sort a Stack

        public void SortAStack(Stack<int> st)
        {
            solveSortAStack(ref st);

            if (st.Any())
            {
                Console.WriteLine("Sort A Stack");
            }

            while (st.Any())
            {
                int top = st.Pop();
                Console.Write(top + " ");
            }
        }

        private void solveSortAStack(ref Stack<int> st)
        {
            if (!st.Any())
                return;

            int num = st.Pop();
            solveSortAStack(ref st);

            InsertInSort(ref st, num);
        }

        private void InsertInSort(ref Stack<int> st, int val)
        {
            //base case
            if (!st.Any() || (st.Any() && st.Peek() < val))
            {
                st.Push(val);
                return;
            }

            int num = st.Pop();
            InsertInSort(ref st, val);

            st.Push(num);
        }


        #endregion

        #region Redundant Brackets

        public bool checkRedundancy(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '(' || ch == '+' || ch == '-' || ch == '/' || ch == '*')
                {
                    st.Push(ch);
                }
                else
                {
                    if (ch == ')')
                    {
                        bool isRedundant = true;
                        while (st.Peek() != '(')
                        {
                            char top = st.Pop();
                            if (top == '+' || top == '-' || top == '/' || top == '*')
                            {
                                isRedundant = false;
                            }
                        }

                        if (isRedundant)
                        {
                            return true;
                        }

                        st.Pop();
                    }
                }
            }

            return false;
        }

        #endregion

        #region Next Larger Element

        public long[] nextLargerElement(long[] arr, int n)
        {
            Stack<long> st = new Stack<long>();
            st.Push(-1);
            long[] outPut = new long[n];
            for (int i = n - 1; i >= 0; i--)
            {
                long current = arr[i];
                if (st.Peek() == -1)
                {
                    outPut[i] = -1;
                    // st.Push(arr[i]);
                }
                else
                {
                    while (current >= st.Peek())
                    {
                        st.Pop();
                    }
                    outPut[i] = st.Peek();
                }
                st.Push(current);
            }

            return outPut;
        }

        #endregion

        #region Next Smallest Element

        public int[] immediateSmaller(int[] arr, int n)
        {
            int[] output = new int[n];
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            for (int i = n - 1; i >= 0; i--)
            {
                int current = arr[i];
                while (st.Peek() >= current)
                {
                    st.Pop();
                }

                output[i] = st.Peek();
                st.Push(current);
            }

            return output;
        }


        #endregion

        #region Final Element

        public int[] FinalPrices(int[] prices)
        {
            Stack<int> st = new Stack<int>();
            int n = prices.Length;
            int[] output = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                int current = prices[i];
                if (!st.Any())
                {
                    output[i] = current;
                }
                else
                {
                    while (st.Any() && current <= st.Peek())
                    {
                        st.Pop();
                    }

                    if (st.Any() && current > st.Peek())
                        output[i] = current - st.Peek();
                    else
                        output[i] = current;
                }
                st.Push(current);
            }

            return output;
        }

        #endregion

        #region Celebrity Problem

        public int celebrity(int[,] mat)
        {
            int n = mat.GetLength(0);
            Stack<int> st = new Stack<int>();

            //Step-1: Push all items to stack
            for (int i = 0; i < n; i++)
                st.Push(i);

            //Step-2: Pull two elements from stack until only 1- potential left.
            while (st.Count() > 1)
            {
                int a = st.Pop();
                int b = st.Pop();
                if (Knows(mat, a, b))
                    st.Push(b);
                else
                    st.Push(a);
            }

            int ans = st.Pop();
            //Step-3: Single element in stack is potential celeb, verify it.

            int zeroCount = 0;

            for (int i = 0; i < n; i++)
            {
                if (mat[ans, i] == 0)
                    zeroCount++;
            }

            if (zeroCount != n)
                return -1;

            int oneCount = 0;

            for (int i = 0; i < n; i++)
            {
                if (mat[i, ans] == 1)
                    oneCount++;
            }

            if (oneCount != n - 1)
                return -1;

            return ans;
        }

        private bool Knows(int[,] mat, int a, int b)
        {
            if (mat[a, b] == 1)
                return true;
            else
                return false;
        }

        #endregion

    }
}
