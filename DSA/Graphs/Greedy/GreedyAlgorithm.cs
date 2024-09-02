using Graphs.BinaryTreeTopic;
using NetTopologySuite.Triangulate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Greedy
{
    internal class GreedyAlgorithm
    {
        #region N Meetings in One Room
        public int N_maxMeetings(int n, int[] start, int[] end)
        {
            Pair[] pair = new Pair[n];
            for (int i = 0; i < pair.Length; i++)
            {
                pair[i] = new Pair();
            }

            for (int i = 0; i < n; i++)
            {
                pair[i].first = start[i];
                pair[i].second = end[i];
            }

            Array.Sort(pair);

            int count = 1;
            int ansEnd = pair[0].second;

            for (int i = 1; i < n; i++)
            {
                if (pair[i].first > ansEnd)
                {
                    count++;
                    ansEnd = pair[i].second;
                }
            }

            return count;
        }

        #endregion

        #region Maximum Meetings in One Room

        public List<int> maxMeetings(int N, int[] S, int[] F)
        {
            List<int> ans = new List<int>();

            Pair[] pair = new Pair[N];
            for (int i = 0; i < N; i++)
            {
                pair[i] = new Pair();
            }

            for (int i = 0; i < N; i++)
            {
                pair[i].first = S[i];
                pair[i].second = F[i];
            }

            Array.Sort(pair);

            ans.Add(1);
            int ansEnd = pair[0].second;

            for (int i = 1; i < N; i++)
            {
                if (pair[i].first > ansEnd)
                {
                    ans.Add(i + 1);
                    ansEnd = pair[i].second;
                }
            }

            return ans;
        }

        #endregion

        #region Shop in Candy Store

        public int[] candyStore(int[] candies, int N, int K)
        {
            Array.Sort(candies);
            int mini = 0;
            int buy = 0;
            int free = N - 1;

            while (buy <= free)
            {
                mini = mini + candies[buy];
                buy++;
                free = free - K;
            }

            int maxi = 0;
            buy = N - 1;
            free = 0;

            while (free <= buy)
            {
                maxi = maxi + candies[buy];
                buy--;
                free = free + K;
            }

            return new int[] { mini, maxi };
        }

        #endregion

        #region Check if it is possible to survive on Island

        public int minimumDays(int s, int n, int m)
        {
            int foodPerDay = m * 7;
            int totalFoodBuyingDays = n * 6;

            if ((foodPerDay > totalFoodBuyingDays && s > 6) || m > n)
                return -1;
            else
            {
                int totalFood = s * m;
                if (totalFood % n == 0)
                {
                    return totalFood / n;
                }
                else
                {
                    return totalFood / n + 1;
                }
            }
        }

        #endregion

        #region Chocolate Distribution Problem

        public long findMinDiff(List<long> a, long n, long m)
        {
            a.Sort();
            int i = 0;
            int j = (int)m - 1;

            long mini = long.MaxValue;
            while (j < a.Count())
            {
                long diff = a[j] - a[i];
                mini = Math.Min(mini, diff);
                i++;
                j++;
            }

            return mini;
        }

        #endregion

        #region Huffamn Encoding

        public List<string> huffmanCodes(string S, int[] f, int N)
        {
            List<string> ans = new List<string>();
            var minHeap = new MinHeap<TreeNode>();

            for (int i = 0; i < N; i++)
            {
                TreeNode tempNode = new TreeNode(f[i]);
                minHeap.Add(tempNode);
            }

            while(minHeap.Count > 1)
            {
                TreeNode left = minHeap.ExtractMin();
                TreeNode right = minHeap.ExtractMin();

                TreeNode newNode = new TreeNode(left.data + right.data);
                newNode.left = left;
                newNode.right = right;
                minHeap.Add(newNode);
            }

            TreeNode root = minHeap.ExtractMin();
            string temp = string.Empty;
            Traverse(root, temp, ref ans);

            return ans;
        }

        private void Traverse(TreeNode root, string temp, ref List<string> ans)
        {
            //base case
            if (root.left == null && root.right == null)
            {
                ans.Add(temp);
                return;
            }

            TreeNode tempNode = root;
            Traverse(tempNode.left, temp + "0", ref ans);
            Traverse(tempNode.right, temp + "1", ref ans);
        }

        #endregion

        #region Fractional Knapsack

        public double fractionalKnapsack(int W, Item[] arr, int n)
        {
            double totalvalue = 0.000000;
            PairFraction[] pair = new PairFraction[n];
            for (int i = 0; i < n; i++)
            {
                pair[i] = new PairFraction();
            }

            for (int i = 0; i < n; i++)
            {
                double perUnitVal = (1.00000 *  arr[i].value) / arr[i].weight;
                pair[i].first = perUnitVal;
                pair[i].second = arr[i];
            }

            Array.Sort(pair);

            for (int i = 0; i < n; i++)
            {
                if (pair[i].second.weight > W)
                {
                    //Take only Fraction of weight
                    totalvalue += W * pair[i].first;
                    W = 0;
                }
                else
                {
                    //Take full weight
                    totalvalue += pair[i].second.value;
                    W = W - pair[i].second.weight;
                }
            }

            return totalvalue;
        }

        public void AddItem(ref Item[] arr, int[] val, int[] weight)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Item(val[i], weight[i]);
            }
        }

        #endregion

        #region Job Sequencing

        public List<int> JobScheduling(Job[] arr, int n)
        {
            List<int> ans = new List<int>();

            SortJob sj = new SortJob();
            Array.Sort(arr, sj);

            int maxiDeadLine = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                maxiDeadLine = Math.Max(maxiDeadLine, arr[i].deadline);
            }

            int[] schedule = new int[maxiDeadLine + 1];
            for (int i = 0; i < schedule.Length; i++)
            {
                schedule[i] = -1;
            }

            int count = 0;
            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                int currProfit = arr[i].profit;
                int currJobId = arr[i].ID;
                int currDeadline = arr[i].deadline;

                for (int k = currDeadline; k > 0 ; k--)
                {
                    if (schedule[k] == -1)
                    {
                        maxProfit += currProfit;
                        schedule[k] = currJobId;
                        count++;
                        break;
                    }
                }
            }

            ans.Add(count);
            ans.Add(maxProfit);

            return ans;
        }

        public void FillJob(ref Job[] arr, int[] id, int[] deadline, int[] profit)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Job();
                arr[i].ID = id[i];
                arr[i].deadline = deadline[i];
                arr[i].profit = profit[i];
            }
        }

        #endregion

    }

    #region Helper Class

    public class Pair : IComparable<Pair>
    {
        public int first;
        public int second;

        public int CompareTo(Pair other)
        {
            return this.second - other.second;
        }
    }

    public class TreeNode : IComparable<TreeNode>
    {
        public TreeNode left;
        public TreeNode right;
        public int data;

        public TreeNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public int CompareTo(TreeNode other)
        {
            return this.data.CompareTo(other.data);
        }
    }

    public class MinHeap<T> where T : IComparable<T>
    {
        List<T> heap = null;

        public MinHeap()
        {
            heap = new List<T>();
        }

        public int Count { get { return heap.Count; } }

        public void Add(T item)
        {
            heap.Add(item);
            int currentIndex = heap.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = currentIndex - 1 / 2;
                if (heap[currentIndex].CompareTo(heap[parentIndex]) >= 0)
                {
                    break;
                }

                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
        }

        public T ExtractMin()
        {
            int lastIndex = heap.Count - 1;
            T min = heap[0];
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            HeapifyHuffman(0);
            return min;
        }

        public void HeapifyHuffman(int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < heap.Count && (heap[smallest].CompareTo(heap[left]) > 0))
            {
                smallest = left;
            }

            if (right < heap.Count && (heap[smallest].CompareTo(heap[right]) > 0))
            {
                smallest = right;
            }

            if (smallest != i)
            {
                Swap(i, smallest);
                HeapifyHuffman(smallest);
            }
        }

        public void Swap(int current, int parent)
        {
            T temp = heap[current];
            heap[current] = heap[parent];
            heap[parent] = temp;
        }
    }

    public class Item
    {
        public int value;
        public int weight;

        public Item(int v, int w)
        {
            value = v;
            weight = w;
        }
    }

    public class PairFraction : IComparable<PairFraction>
    {
        public double first;
        public Item second;

        public int CompareTo(PairFraction other)
        {
            return other.first.CompareTo(first); //Descending order
        }
    }

    public class Job
    {
        public int ID;
        public int deadline;
        public int profit;
    }

    public class SortJob : IComparer<Job>
    {
        public int Compare(Job a, Job b)
        {
            if (a.profit == 0 || b.profit == 0)
                return 0;

            return b.profit.CompareTo(a.profit);
        }
    }

    #endregion

}
