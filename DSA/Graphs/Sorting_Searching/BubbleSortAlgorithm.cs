using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Sorting_Searching
{
    internal class BubbleSortAlgorithm
    {
        public void BubbleSort(ref int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                bool isSwapped = false;
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(ref arr, j, j + 1);
                        isSwapped = true;
                    }
                }

                if (!isSwapped)
                {
                    break;
                }
            }
        }

        private void swap(ref int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
