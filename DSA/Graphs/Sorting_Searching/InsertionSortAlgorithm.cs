using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Sorting_Searching
{
    internal class InsertionSortAlgorithm
    {
        public void InsertionSort(ref int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (arr[j] >temp)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = temp;
            }
        }
    }
}
