using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.BinaryTreeTopic;
using Graphs.CommonFunctions;
using NetTopologySuite;
using NetTopologySuite.Utilities;

namespace DSA.Heaps
{
    internal class Heap
    {
        int[] arr = new int[100];
        int size;
        public Heap()
        {
            size = 0;
            arr[0] = -1;
        }

        /// <summary>
        /// Insertion
        /// </summary>
        /// <param name="value"></param>
        public void InsertInHeap(int value)
        {
            size = size + 1; // increase size
            int index = size; // get index of last 
            arr[index] = value; //insert val at last index

            while (index > 1)
            {
                int parent = index / 2;
                if (arr[parent] < arr[index])
                {
                    CommonFunction.Swap(ref arr, parent, index);
                    index = parent;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Deletion
        /// </summary>
        public void DeleteFromHeap()
        {
            if (size == 0)
            {
                Console.WriteLine("No elements to delete");
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
                int rightIndex = 2 * i + 1;

                if (leftIndex < size && arr[i] < arr[leftIndex])
                {
                    CommonFunction.Swap(ref arr, leftIndex, i);
                    i = leftIndex;
                }
                else if (rightIndex < size && arr[i] < arr[rightIndex])
                {
                    CommonFunction.Swap(ref arr, rightIndex, i);
                    i = rightIndex;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Heapify
        /// </summary>
        public void HeapifyMaxHeap(ref int[] arr, int n, int i)
        {
            //Max Heap
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
                CommonFunction.Swap(ref arr, i, largest);
                HeapifyMaxHeap(ref arr, n, largest);
            }
        }

        public void HeapifyMaxHeapZero(ref int[] arr, int n, int i)
        {
            //Max Heap
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[largest] < arr[left])
            {
                largest = left;
            }

            if (right < n && arr[largest] < arr[right])
            {
                largest = right;
            }

            if (largest != i)
            {
                CommonFunction.Swap(ref arr, i, largest);
                HeapifyMaxHeapZero(ref arr, n, largest);
            }
        }

        public void HeapifyMinHeapZero(ref int[] arr, int n, int i)
        {
            //Max Heap
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
                CommonFunction.Swap(ref arr, i, smallest);
                HeapifyMinHeapZero(ref arr, n, smallest);
            }
        }

        public void HeapSort(ref int[] arr, int n)
        {
            int size = n;

            while (size > 1)
            {
                //Step-1: Swap Elements
                CommonFunction.Swap(ref arr, 1, size);
                size--;

                //Step-2: Heapify
                HeapifyMaxHeap(ref arr, size, 1);
            }
        }

        #region Kth Smallest In array using heap

        //Does not work with Duplicate elements in array
        public int kthSmallest(ref int[] arr, int k)
        {
            //return SolveSorted(arr, k);

            var maxHeap = new SortedSet<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            foreach (var item in arr)
            {
                maxHeap.Add(-item);

                if (maxHeap.Count > k)
                    maxHeap.Remove(maxHeap.Max);
            }

            return -maxHeap.Max;
        }

        public int kthSmallestheap(ref int[] arr, int l, int r, int k)
        {
            int[] ar = new int[k];
            for (int i = 0; i < k; i++)
            {
                ar[i] = arr[i];
            }

            for (int i = r / 2 - 1; i >= 0; i--)
            {
                HeapifyMaxHeapZero(ref ar, ar.Length, i);
            }

            for (int i = k; i < r; i++)
            {
                if (ar[0] > arr[i])
                {
                    ar[0] = arr[i];
                    HeapifyMaxHeapZero(ref ar, ar.Length, 0);
                }
            }


            return ar[0];
        }

        #endregion

        #region Kth Largest in Array

        //Does not work with Duplicate elements in array
        public int FindKthLargest(int[] nums, int k)
        {
            var minHeap = new SortedSet<int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
            int size = nums.Length;

            for (int i = 0; i < size; i++)
            {
                minHeap.Add(nums[i]);
                if (minHeap.Count() > k)
                    minHeap.Remove(minHeap.Min);
            }

            return minHeap.Min;

        }

        public int FindKthLargestheap(int[] nums, int k)
        {
            int[] ar = new int[k];
            for (int i = 0; i < k; i++)
            {
                ar[i] = nums[i];
            }

            int size = ar.Length;
            for (int i = size/ 2 - 1; i >= 0; i--)
            {
                HeapifyMinHeapZero(ref ar, ar.Length, i);
            }

            for (int i = k; i < nums.Length; i++)
            {
                if (ar[0] < nums[i])
                {
                    ar[0] = nums[i];
                    HeapifyMinHeapZero(ref ar, ar.Length, 0);
                }
            }

            return ar[0];
            
        }

        #endregion

        #region Is Binary Tree Heap

        public bool isBinaryTreeHeap(Node root)
        {
            int totalNodes = CountNode(root);
            int index = 0;
            if (isCBT(root, index, totalNodes) && isMaxOrder(root))
                return true;

            return false;
        }

        private bool isCBT(Node root, int index, int total)
        {
            if (root == null)
            {
                return true;
            }

            if (index >= total)
            {
                return false;
            }

            bool left = isCBT(root.Left, 2 * index + 1, total);
            bool right = isCBT(root.Right, 2 * index + 2, total);

            return left && right;
        }

        private bool isMaxOrder(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                return true;
            }

            if (root.Right == null)
            {
                return root.data > root.Left.data;
            }

            bool left = isMaxOrder(root.Left);
            bool right = isMaxOrder(root.Right);

            return left && right;

        }

        private int CountNode(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int cnt = CountNode(root.Left) + CountNode(root.Right) + 1;

            return cnt;
        }

        #endregion

        #region Merge Two Binary Max Heaps

        public int[] mergeHeaps(int[] a, int[] b, int n, int m)
        {
            int[] ans = new int[n + m];
            MergeArray(a, b, ref ans);

            int size = ans.Length;

            for (int i = size / 2 - 1; i >= 0; i--)
            {
                HeapifyMaxHeapZero(ref ans, size, i);
            }

            return ans;
        }

        private void MergeArray(int[] a, int[] b, ref int[] ans)
        {
            int i = 0, j = 0, k = 0;
            while (i < a.Length)
            {
                ans[k] = a[i];
                i++;
                k++;
            }
            while (j < b.Length)
            {
                ans[k] = b[j];
                j++;
                k++;
            }
        }

        #endregion

        #region Minimum Cost of Ropes

        public int MinCostOfRopes(int[] arr, int n)
        {
            var minHeap = new SortedSet<int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));

            int sum = 0;
            foreach (var item in arr)
            {
                minHeap.Add(item);
            }

            while (minHeap.Count() > 1)
            {
                int first = minHeap.Min;
                minHeap.Remove(minHeap.Min);
                int second = minHeap.Min;
                minHeap.Remove(minHeap.Min);

                sum = sum + first + second;
                minHeap.Add(first + second);
            }

            return sum;
        }

        #endregion

        #region Convert BST to Min Heap

        public Node ConvertBSTtoMinHeap(Node root)
        {
            List<int> inorder = new List<int>();
            ConvertBSTToInorder(root, ref inorder);
            int index = 0;

            return FillPreOrder(root, ref inorder, ref index);
        }

        private Node FillPreOrder(Node root, ref List<int> inorder, ref int index)
        {
            //base case
            if (root == null || index > inorder.Count())
            {
                return null;
            }
            //NLR

            int element = inorder[index];
            root.data = element;

            index++;

            root.Left = FillPreOrder(root.Left, ref inorder, ref index);
            root.Right = FillPreOrder(root.Right, ref inorder, ref index);

            return root;
        }

        private void ConvertBSTToInorder(Node root, ref List<int> inorder)
        {
            if (root == null)
            {
                return;
            }

            ConvertBSTToInorder(root.Left, ref inorder);
            inorder.Add(root.data);
            ConvertBSTToInorder(root.Right, ref inorder);
        }

        #endregion

        #region Convert BST to Max Heap

        public Node ConvertBSTtoMaxHeap(Node root)
        {
            List<int> inorder = new List<int>();
            ConvertBSTToInorder(root, ref inorder);
            int index = inorder.Count() - 1;
            return FillPostOrder(root, ref inorder, ref index);
        }

        private Node FillPostOrder(Node root, ref List<int> inorder, ref int index)
        {
            if (root == null || (index < 0))
            {
                return null;
            }

            //LRN
            int element = inorder[index];
            index--;

            root.data = element;

            root.Right = FillPostOrder(root.Right, ref inorder, ref index);
            root.Left = FillPostOrder(root.Left, ref inorder, ref index);

            return root;
        }

        #endregion

        #region Get Kth Largest Sum Subarray

        public int getKthLargestSumSubArray(int[] arr, int k)
        {
            int size = arr.Length;
            var minheap = new SortedSet<int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));


            for (int i = 0; i < size; i++)
            {
                int sum = 0;

                for (int j = i; j < size; j++)
                {
                    sum += arr[j];

                    if (minheap.Count() < k)
                    {
                        minheap.Add(sum);
                    }
                    else
                    {
                        if (sum > minheap.Min)
                        {
                            minheap.Remove(minheap.Min);
                            minheap.Add(sum);
                        }
                    }
                }
            }

            return minheap.Min;
        }

        #endregion

        #region Merge k Sorted Arrays

        /// <summary>
        /// Incorrect for using with Duplicate arrary elements.
        /// Duplicate element are not added in SortedSet
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<int> MergeKSortedArrays(int[,] arr, int K)
        {
            List<int> ans = new List<int>();

            var minheap = new SortedSet<HeapNode>(Comparer<HeapNode>.Create((a, b) => (a.data.CompareTo(b.data))));

            for (int i = 0; i < K; i++)
            {
                HeapNode temp = new HeapNode(arr[i, 0], i, 0);
                minheap.Add(temp);
            }
            while (minheap.Count() > 0)
            {
                HeapNode temp = minheap.Min;
                ans.Add(temp.data);
                minheap.Remove(minheap.Min);

                int row = temp.row;
                int col = temp.col;

                if (col + 1 < arr.GetLength(1))
                {
                    HeapNode next = new HeapNode(arr[row, col + 1], row, col + 1);
                    minheap.Add(next);
                }
            }

            return ans;
        }


        #endregion


        #region Common Functions

        public void PrintHeap()
        {
            for (int i = 1; i <= size; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public void PrintHeapify(ref int[] arr, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public void PrintHeapifyZero(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        #endregion

    }

    internal class HeapNode
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
}
