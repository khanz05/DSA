using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Sorting_Searching
{
    internal class QuickSortAlgorithm
    {
        public void QuickSortAlgo(ref int[] arr)
        {
            int s = 0;
            int e = arr.Length - 1;

            SolveQuick(ref arr, s, e);
        }

        private void SolveQuick(ref int[] arr, int s, int e)
        {
            if (s >= e)
            {
                return;
            }

            int pi = Partition(ref arr, s, e);

            SolveQuick(ref arr, s, pi - 1);
            SolveQuick(ref arr, pi + 1, e);
        }

        private int Partition(ref int[] arr, int s, int e)
        {
            //choose pivot
            int pivot = arr[s];

            //count of element less the pivot
            int count = 0;
            for (int i = s + 1; i <= e; i++)
            {
                if (arr[i] <= pivot)
                {
                    count++;
                }
            }

            //Place pivot in correct position
            int pivotIndex = count + s;
            CommonFunction.Swap(ref arr, pivotIndex, s);

            //place all values < than pivot to left and > than pivot to right
            int j = s, k = e;
            while (j < pivotIndex && k > pivotIndex)
            {
                while (arr[j] <= pivot)
                {
                    j++;
                }

                while (arr[k] > pivot)
                {
                    k--;
                }

                if (j < pivotIndex && k > pivotIndex)
                {
                    CommonFunction.Swap(ref arr, j, k);
                    j++;
                    k--;
                }
            }

            return pivotIndex;
        }
    }
}
