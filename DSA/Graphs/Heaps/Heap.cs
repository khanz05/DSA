using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

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
            size = size + 1;
            int index = size;
            arr[index] = value;

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
    } 
}
