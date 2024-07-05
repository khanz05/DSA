using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Sorting_Searching
{
    internal class SelectionSortAlgorithm
    {
        public void SelectionSort(ref int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    CommonFunction.Swap(ref arr, i, minIndex);
                }
            }
        }

        public void SelectionSortByShift(ref int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[minIndex] > arr[j])
                    {
                        minIndex = j;
                    }
                }

                int k = arr[minIndex];
                while (minIndex > i)
                {
                    arr[minIndex] = arr[minIndex - 1];
                    minIndex--;
                }
                arr[i] = k;
                
            }
        }
    }
}
