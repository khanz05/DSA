using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.StackAndQueue
{
    internal class QueueImplementation
    {
        public QueueImplementation()
        {

        }

        #region Custom Queue Implementation using Array

        //Your code here
        private int[] arr;
        private int front;
        private int rear;
        private int size;

        public QueueImplementation(int size)
        {
            this.size = size;
            arr = new int[size];
            front = 0;
            rear = 0;
        }

        public void Push(int x)
        {
            if (rear == size)
                Console.WriteLine("Queue is Full");
            else
            {
                arr[rear] = x;
                rear++;
            }
        }

        public int Pop()
        {
            if (front == rear)
                return -1;
            else
            {
                int ans = arr[front];
                arr[front] = -1;
                front++;
                if (front == rear)
                {
                    front = 0;
                    rear = 0;
                }

                return ans;
            }
        }

        #endregion

        #region Queue Reversal

        public Queue<int> ReverseQueue(Queue<int> q)
        {
            Stack<int> st = new Stack<int>();
            while (q.Any())
            {
                int front = q.Dequeue();
                st.Push(front);
            }

            while (st.Any())
            {
                int top = st.Pop();
                q.Enqueue(top);
            }

            return q;
        }

        #endregion

        #region First negative in every window of size k

        public List<long> FirstNegativeInteger(long[] A, long N, long K)
        {
            long k = K;
            Queue<long> negIndex = new Queue<long>();
            List<long> ans = new List<long>();

            for (int i = 0; i < N; i++)
            {
                if (negIndex.Count() > 0 && negIndex.Peek() == i - K)
                {
                    negIndex.Dequeue();
                }

                if (A[i] < 0)
                {
                    negIndex.Enqueue(i);
                }

                if (i >= k - 1)
                {
                    if (negIndex.Count() > 0)
                    {
                        ans.Add(A[negIndex.Peek()]);
                    }
                    else
                        ans.Add(0);
                }
            }


            return ans;
        }

        public List<long> FirstNegativeIntegerSlidingWindow(long[] A, long N, long K)
        {
            List<long> ans = new List<long>();
            List<long> dq = new List<long>();

            //Process first window of K- size
            for (int i = 0; i < K; i++)
            {
                if (A[i] < 0)
                    dq.Add(i);
            }

            //store answer of first k size window
            if (dq.Count > 0)
                ans.Add(A[dq[0]]);
            else
                ans.Add(0);

            //Process for remaining windows
            for (long i = K; i < N; i++)
            {
                //Removal
                if (dq.Count > 0 && i - dq[0] >= K)
                {
                    dq.RemoveAt(0);
                }

                //addition
                if (A[i] < 0)
                {
                    dq.Add(i);
                }

                //ans store
                if (dq.Count > 0)
                    ans.Add(A[dq[0]]);
                else
                    ans.Add(0);
            }
            return ans;
        }



        #endregion

        #region Reverse First K elements of Queue

        public Queue<int> modifyQueue(Queue<int> q, int k)
        {
            Stack<int> st = new Stack<int>();

            //Fetch From Queue and Push to stack
            for (int i = 0; i < k; i++)
            {
                int front = q.Dequeue();
                st.Push(front);
            }

            //Fetch from stack and push to queue
            while (st.Any())
            {
                int top = st.Pop();
                q.Enqueue(top);
            }

            //Fetch n-k element from Queue and push back
            int n = q.Count() - k;

            while (n > 0)
            {
                int front = q.Dequeue();
                q.Enqueue(front);
                n--;
            }

            return q;
        }


        #endregion

        #region First non-repeating character in a stream

        public string FirstNonRepeating(string A)
        {
            StringBuilder ans = new StringBuilder();
            Queue<char> q = new Queue<char>();
            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 0; i < A.Length; i++)
            {
                char ch = A[i];
                if (!count.ContainsKey(ch))
                    count.Add(ch, 1);
                else
                {
                    count[ch]++;
                }

                q.Enqueue(ch);

                while (q.Any())
                {
                    if (count[q.Peek()] > 1)
                    {
                        q.Dequeue();
                    }
                    else
                    {
                        ans.Append(q.Peek());
                        break;
                    }
                }

                if (!q.Any())
                {
                    ans.Append('#');
                }
            }

            string val = string.Empty;
            val = ans.ToString();

            return val;
        }

        #endregion

        #region Interleave the First Half of the Queue with Second Half

        public Queue<int> RearrangeInterLeaveQueue(Queue<int> q)
        {
            int n = q.Count() / 2;
            Queue<int> newQue = new Queue<int>();

            while (n > 0)
            {
                newQue.Enqueue(q.Dequeue());
                n--;
            }

            while (newQue.Any())
            {
                int newItem = newQue.Dequeue();
                q.Enqueue(newItem);
                q.Enqueue(q.Dequeue());
            }
            return q;
        }

        #endregion

        #region Sum of minimum and maximum elements of all subarrays of size k

        public int SumOfKsubArray(int[] arr, int n, int k)
        {
            List<int> maxi = new List<int>();
            List<int> mini = new List<int>();

            for (int i = 0; i < k; i++)
            {
                while (maxi.Count != 0 && arr[maxi[maxi.Count - 1]] <= arr[i])
                {
                    maxi.RemoveAt(maxi.Count - 1);
                }


                while (mini.Count != 0 && arr[mini[mini.Count - 1]] >= arr[i])
                {
                    mini.RemoveAt(mini.Count - 1);
                }

                maxi.Add(i);
                mini.Add(i);
            }

            int sum = 0;
            sum += arr[maxi[0]] + arr[mini[0]];


            for (int i = k; i < n; i++)
            {
                //next window
                //Removal
                while (maxi.Count != 0 && i - maxi[0] >= k)
                {
                    maxi.RemoveAt(0);
                }

                while (mini.Count != 0 && i - mini[0] >= k)
                {
                    mini.RemoveAt(0);
                }

                //addition
                while (maxi.Count != 0 && arr[maxi[maxi.Count - 1]] <= arr[i])
                {
                    maxi.RemoveAt(maxi.Count - 1);
                }


                while (mini.Count != 0 && arr[mini[mini.Count - 1]] >= arr[i])
                {
                    mini.RemoveAt(mini.Count - 1);
                }

                maxi.Add(i);
                mini.Add(i);

                sum += arr[maxi[0]] + arr[mini[0]];
            }

            ////make sure to consider
            //sum += arr[maxi[0]] + arr[mini[0]];

            return sum;
        }

        #endregion

        #region K Sized Subarray Maximum

        public List<int> MaxofSubarrays(int[] arr, int n, int k)
        {
            List<int> ans = new List<int>();
            List<int> dq = new List<int>();

            //Process for 1st K elements
            for (int i = 0; i < k; i++)
            {
                while (dq.Count > 0 && arr[dq[dq.Count - 1]] <= arr[i])
                    dq.RemoveAt(dq.Count - 1);

                dq.Add(i);
            }

            //Process elements in for 1st Window
            if (dq.Count > 0)
                ans.Add(arr[dq[0]]);

            //Process remaining elements
            for (int i = k; i < n; i++)
            {
                //Next Window
                //removal if not in current window
                while (dq.Count > 0 && i - dq[0] >= k)
                    dq.RemoveAt(0);

                //Addition of elements from current window
                while (dq.Count > 0 && arr[dq[dq.Count - 1]] <= arr[i])
                    dq.RemoveAt(dq.Count - 1);


                dq.Add(i);
                if (dq.Count > 0)
                    ans.Add(arr[dq[0]]);
            }

            return ans;
        }

        #endregion
    }
}
