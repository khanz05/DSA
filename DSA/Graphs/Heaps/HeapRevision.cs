using ConcurrentPriorityQueue;
using Graphs.BinaryTreeTopic;
using Graphs.CommonFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Heaps
{
    internal class HeapRevision
    {
        int[] arr = new int[100];
        int size;
        public HeapRevision()
        {
            arr[0] = -1;
            size = 0;
        }

        #region Insert & Delete

        public void Insert(int val)
        {
            size = size + 1;
            int index = size;
            arr[index] = val;

            while (index > 1)
            {
                int parent = index / 2;

                if (arr[parent] < arr[index])
                {
                    Swap(ref arr, parent, index);
                    index = parent;
                }
                else
                    return;
            }
        }

        public void Delete()
        {
            if (size == 0)
            {
                Console.WriteLine("Nothing to delete");
            }

            //Step-1: Replace RootNode to delete
            arr[1] = arr[size];

            //Step-2: Remove last element
            size--;

            //Step-3: take RootNode to correct Position
            int i = 1;
            while (i < size)
            {
                int leftIndex = 2 * i;
                int rightIndex = 2 * +1;

                if (leftIndex < size && arr[i] < arr[leftIndex])
                {
                    Swap(ref arr, i, leftIndex);
                    i = leftIndex;
                }
                else if (rightIndex < size && arr[i] < arr[rightIndex])
                {
                    Swap(ref arr, i, rightIndex);
                    i = rightIndex;
                }
                else
                    return;
            }
        }

        #endregion

        #region Build Max Heap

        public void HeapifyMax(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left <= n && arr[largest] < arr[left])
            {
                largest = left;
            }

            if (right <= n && arr[largest] < arr[right])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref arr, largest, i);
                HeapifyMax(arr, n, largest);
            }
        }

        #endregion

        #region Build Min Heap- Zero

        public void HeapifyMinZero(int[] arr, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[smallest] > arr[left])
            {
                smallest = left;
            }

            if (right < n && arr[smallest] > arr[right])
            {
                smallest = right;
            }

            if (smallest != i)
            {
                Swap(ref arr, smallest, i);
                HeapifyMinZero(arr, n, smallest);
            }
        }

        public void HeapifyMin(int[] arr, int n, int i)
        {
            int smallest = i;
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left < n && arr[smallest] > arr[left])
            {
                smallest = left;
            }

            if (right < n && arr[smallest] > arr[right])
            {
                smallest = right;
            }

            if (smallest != i)
            {
                Swap(ref arr, smallest, i);
                HeapifyMin(arr, n, smallest);
            }
        }

        #endregion

        #region Heap Sort

        public void HeapSort(int[] arr, int n)
        {
            int size = n;
            while (size > 1)
            {
                Swap(ref arr, size, 1);
                size--;

                HeapifyMax(arr, size, 1);
            }
        }

        #endregion

        #region kth Smallest

        public int kthSmallest(int[] arr, int l, int r, int k)
        {
            int[] maxHeap = new int[k];
            for (int i = 0; i < k; i++)
                maxHeap[i] = arr[i];

            for (int i = r / 2; i >= 0; i--)
                CreateMaxHeap(ref maxHeap, k, i);

            for (int i = k; i <= r; i++)
            {
                if (maxHeap[0] > arr[i])
                {
                    maxHeap[0] = arr[i];
                    CreateMaxHeap(ref maxHeap, k, 0);
                }
            }

            return maxHeap[0];
        }

        private void CreateMaxHeap(ref int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[largest] < arr[left])
                largest = left;

            if (right < n && arr[largest] < arr[right])
                largest = right;

            if (largest != i)
            {
                Swap(ref arr, largest, i);
                CreateMaxHeap(ref arr, n, largest);
            }
        }

        #endregion

        #region kth Largest

        public int FindKthLargest(int[] nums, int k)
        {
            int size = nums.Length;

            int[] minHeap = new int[k];
            for (int i = 0; i < k; i++)
                minHeap[i] = nums[i];

            for (int i = size / 2; i >= 0; i--)
                CreateMinHeap(ref minHeap, k, i);

            for (int i = k; i < size; i++)
            {
                if (minHeap[0] < nums[i])
                {
                    minHeap[0] = nums[i];
                    CreateMinHeap(ref minHeap, k, 0);
                }
            }

            return minHeap[0];
        }

        private void CreateMinHeap(ref int[] arr, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[smallest] > arr[left])
                smallest = left;

            if (right < n && arr[smallest] > right)
                smallest = right;

            if (smallest != i)
            {
                Swap(ref arr, i, smallest);
                CreateMinHeap(ref arr, n, smallest);
            }
        }

        #endregion

        #region Check if a given Binary Tree is a Heap

        public bool isHeap(Node root)
        {
            int totalCount = CountNodes(root);
            if (IsCBT(root, 0, totalCount) && IsMaxOrder(root))
                return true;

            return false;
        }

        private bool IsCBT(Node root, int index, int cnt)
        {
            if (root == null)
            {
                return true;
            }

            Node currentRoot = root;
            if (index >= cnt)
            {
                return false;
            }
            else
            {
                bool left = IsCBT(currentRoot.Left, 2 * index + 1, cnt);
                bool right = IsCBT(currentRoot.Right, 2 * index + 2, cnt);
                return (left && right);
            }
        }

        private bool IsMaxOrder(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                return true;
            }

            Node currentRoot = root;

            if (currentRoot.Right == null)
            {
                return (currentRoot.data > currentRoot.Left.data);
            }
            else
            {
                bool left = IsMaxOrder(currentRoot.Left);
                bool right = IsMaxOrder(currentRoot.Right);

                return (left && right && (currentRoot.data > currentRoot.Left.data && currentRoot.data > currentRoot.Right.data));
            }
        }


        private int CountNodes(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int ans = 1 + CountNodes(root.Left) + CountNodes(root.Right);
            return ans;
        }

        #endregion

        #region Merge two binary Max heaps

        public int[] MergeHeaps(int[] a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;
            int size = n + m;
            int[] mainArray = new int[n + m];

            MergeArray(ref mainArray, a, b);

            for (int i = size / 2; i >= 0; i--)
            {
                HeapifyMergeHeaps(ref mainArray, size, i);
            }

            return mainArray;
        }

        private void MergeArray(ref int[] mainArray, int[] a, int[] b)
        {
            int mainIndex = 0, left = 0, right = 0;

            while (left < a.Length)
            {
                mainArray[mainIndex] = a[left];
                mainIndex++;
                left++;
            }

            while (right < b.Length)
            {
                mainArray[mainIndex] = b[right];
                mainIndex++;
                right++;
            }
        }

        private void HeapifyMergeHeaps(ref int[] mainArray, int size, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < size && mainArray[largest] < mainArray[left])
            {
                largest = left;
            }

            if (right < size && mainArray[largest] < mainArray[right])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref mainArray, i, largest);
                HeapifyMergeHeaps(ref mainArray, size, largest);
            }
        }



        #endregion

        #region Minimum Cost of Ropes

        public int MinimumCostOfRopes(int[] arr)
        {
            int size = arr.Length;
            int[] minHeap = new int[size];

            for (int i = 0; i < size; i++)
            {
                minHeap[i] = arr[i];
            }

            //Step-1: Create Min Heap
            for (int i = size / 2; i >= 0; i--)
            {
                HeapifyMinMinimumCostOfRopes(ref minHeap, minHeap.Length, i);
            }

            int totalSum = 0;
            while (size > 1)
            {
                //1st Min Element
                int first = minHeap[0];
                minHeap[0] = minHeap[size - 1];
                minHeap[size - 1] = -1;
                size--;
                HeapifyMinMinimumCostOfRopes(ref minHeap, size, 0);

                //2nd Min Element
                int second = minHeap[0];
                minHeap[0] = minHeap[size - 1];
                minHeap[size - 1] = -1;
                size--;
                HeapifyMinMinimumCostOfRopes(ref minHeap, size, 0);

                //Add and push sum to MinHeap
                int sum = first + second;
                totalSum += sum;
                size++;
                int index = size;
                index = index - 1;
                minHeap[index] = sum;

                while (index > 0)
                {
                    int parent = index / 2;

                    if (minHeap[parent] > minHeap[index])
                    {
                        Swap(ref minHeap, parent, index);
                        index = parent;
                    }
                    else
                        break;
                }
            }

            return totalSum;
        }

        private void HeapifyMinMinimumCostOfRopes(ref int[] minHeap, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && minHeap[smallest] > minHeap[left])
                smallest = left;

            if (right < n && minHeap[smallest] > minHeap[right])
                smallest = right;

            if (smallest != i)
            {
                Swap(ref minHeap, i, smallest);
                HeapifyMinMinimumCostOfRopes(ref minHeap, n, smallest);
            }
        }

        #endregion

        #region Convert BST to Min Heap

        public Node ConvertBSTToMinHeapUtil(Node root)
        {
            if (root == null)
            {
                return null;
            }

            List<int> inorder = new List<int>();
            FillInOrder(root, ref inorder);

            int index = 0;
            Node temp = ConvertToMinHeap(inorder, root, ref index);
            return temp;
        }

        private void FillInOrder(Node root, ref List<int> inorder)
        {
            if (root == null)
            {
                return;
            }

            Node currentRoot = root;

            //L
            FillInOrder(currentRoot.Left, ref inorder);

            //N
            inorder.Add(currentRoot.data);

            //R
            FillInOrder(currentRoot.Right, ref inorder);
        }

        private Node ConvertToMinHeap(List<int> inorder, Node root, ref int index)
        {
            if (root == null || index > inorder.Count)
                return null;

            //Pre-Order
            //NLR

            Node currentNode = root;

            currentNode.data = inorder[index];
            index++;

            ConvertToMinHeap(inorder, currentNode.Left, ref index);
            ConvertToMinHeap(inorder, currentNode.Right, ref index);

            return root;
        }

        #endregion

        #region Convert BST to Max Heap

        public Node ConvertBSTToMaxHeapUtil(Node root)
        {
            if (root == null)
            {
                return null;
            }

            List<int> inorder = new List<int>();
            FillInOrderMaxHeap(root, ref inorder);

            int index = inorder.Count() - 1;
            Node temp = ConvertToMaxHeap(inorder, root, ref index);
            return temp;
        }

        private void FillInOrderMaxHeap(Node root, ref List<int> inorder)
        {
            if (root == null)
            {
                return;
            }

            Node currentRoot = root;

            //L
            FillInOrderMaxHeap(currentRoot.Left, ref inorder);

            //N
            inorder.Add(currentRoot.data);

            //R
            FillInOrderMaxHeap(currentRoot.Right, ref inorder);
        }

        private Node ConvertToMaxHeap(List<int> inorder, Node root, ref int index)
        {
            if (root == null || index < 0)
                return null;

            //Post-Order
            //LRN

            Node currentNode = root;

            currentNode.data = inorder[index];
            index--;

            ConvertToMaxHeap(inorder, currentNode.Right, ref index);
            ConvertToMaxHeap(inorder, currentNode.Left, ref index);

            return root;
        }

        #endregion

        #region K-th Largest Sum Contiguous Subarray

        public int kthLargestSumSubarrray(int[]arr, int K)
        {
            int n = arr.Length;
            List<int> pq = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum += arr[j];
                    if (pq.Count < K)
                    {
                        pq.Add(sum);
                    }
                    else
                    {
                        pq.Sort();
                        if (pq[0] < sum)
                        {
                            pq.RemoveAt(0);
                            pq.Add(sum);
                        }
                    }
                }
            }

            return pq[0];
        }

        #endregion

        #region Maximum Subarray

        /// <summary>
        /// Kadane's Algorithm
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return n;
            }

            int maxi = nums[0];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = sum + nums[i];
                maxi = Math.Max(maxi, sum);
                if (sum < 0)
                {
                    sum = 0;
                }
            }

            return maxi;
        }

        public int MaxSubArrayO_N_Square_Test(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return n;
            }

            int maxi = nums[0];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum = sum + nums[j];
                    maxi = Math.Max(maxi, sum);
                }
            }

            return maxi;
        }

        #endregion

        #region Merge K Sorted Arrays

        public List<int> MergeKSortedArrays(int[,] arr, int K)
        {
            List<HeapNode> minHeap = new List<HeapNode>();
            List<int> ans = new List<int>();

            //Step-1: Put K elements from all arrays
            for (int i = 0; i < K; i++)
            {
                HeapNode temp = new HeapNode(arr[i, 0], i, 0);
                minHeap.Add(temp);
            }

            int size = minHeap.Count;
            for (int i = K/2 -1; i >= 0; i--)
            {
                HeapifyMergeKSortedArrays(ref minHeap, size, i);
            }

            while (minHeap.Count > 0)
            {
                HeapNode temp = minHeap[0];
                ans.Add(temp.data);
                minHeap.RemoveAt(0);

                int row = temp.row;
                int col = temp.col;

                if (col + 1 < arr.GetLength(1))
                {
                    HeapNode next = new HeapNode(arr[row, col + 1], row, col + 1);
                    minHeap.Add(next);
                }

                int index = minHeap.Count;
                for (int i = index / 2; i >= 0; i--)
                {
                    HeapifyMergeKSortedArrays(ref minHeap, index, i);
                }
            }

            return ans;
        }

        private void HeapifyMergeKSortedArrays(ref List<HeapNode> minHeap, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && minHeap[smallest].data > minHeap[left].data)
            {
                smallest = left;
            }

            if (right < n && minHeap[smallest].data > minHeap[right].data)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                SwapList(ref minHeap, i, smallest);
                HeapifyMergeKSortedArrays(ref minHeap, n, smallest);
            }
        }

        #endregion

        #region Smallest Range

        public int[] SmallestRange(int[][]nums)
        {
            int mini = int.MaxValue;
            int maxi = int.MinValue;

            int K = nums.Count(); ;

            List<HeapNode> minHeap = new List<HeapNode>();

            for (int i = 0; i < K; i++)
            {
                int element = nums[i][0];
                mini = Math.Min(mini, element);
                maxi = Math.Max(maxi, element);
                HeapNode temp = new HeapNode(element, i, 0);
                minHeap.Add(temp);
            }

            int size = minHeap.Count;
            for (int i = K / 2 - 1; i >= 0; i--)
            {
                HeapifySmallestRange(ref minHeap, size, i);
            }

            int start = mini, end = maxi;
            while (minHeap.Count > 0)
            {
                HeapNode temp = minHeap[0];
                minHeap.RemoveAt(0);

                mini = temp.data;
                int row = temp.row;
                int col = temp.col;

                if (maxi - mini < end - start)
                {
                    start = mini;
                    end = maxi;
                }

                if (col + 1 < nums[row].Count())
                {
                    int element = nums[row][col + 1];
                    maxi = Math.Max(maxi, element);
                    HeapNode next = new HeapNode(element, row, col + 1);
                    minHeap.Add(next);
                }
                else
                {
                    break;
                }

                int index = minHeap.Count;
                for (int i = index / 2; i >= 0; i--)
                {
                    HeapifySmallestRange(ref minHeap, index, i);
                }
            }

            return new int[] { start, end };
        }

        private void HeapifySmallestRange(ref List<HeapNode> minHeap, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && minHeap[smallest].data > minHeap[left].data)
            {
                smallest = left;
            }

            if (right < n && minHeap[smallest].data > minHeap[right].data)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                SwapList(ref minHeap, i, smallest);
                HeapifySmallestRange(ref minHeap, n, smallest);
            }
        }

        #endregion

        #region Helper Class

        public class HeapNode
        {
            public int data;
            public int row;
            public int col;

            public HeapNode(int data, int row, int col)
            {
                this.data = data;
                this.row = row;
                this.col = col;
            }
        }

        #endregion

        #region Helper Methods

        public static void SwapList(ref List<HeapNode> arr, int i, int j)
        {
            HeapNode temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Swap(ref int[] arr, int i, int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }

        public void Print()
        {
            for (int i = 1; i <= size; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        #endregion
    }
}
