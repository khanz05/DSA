using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Sorting_Searching
{
    internal class MergeSortAlgorithm
    {
        public void MergeSort(ref int[] arr)
        {
            int s = 0;
            int e = arr.Length - 1;

            SolveMerge(ref arr, s, e);
        }

        private void SolveMerge(ref int[] arr, int s, int e)
        {
            if (s >= e)
            {
                return;
            }

            int mid = s + (e - s) / 2;

            //Solve Left
            SolveMerge(ref arr, s, mid);

            //Solve Right
            SolveMerge(ref arr, mid + 1, e);

            //Merge both
            Merge(ref arr, s, e);

        }

        private void Merge(ref int[] arr, int s, int e)
        {
            int mid = s + (e - s) / 2;

            int len1 = mid - s + 1;
            int len2 = e - mid;

            int[] first = new int[len1];
            int[] second = new int[len2];

            //copy
            int mainArrayIndex = s;
            for (int i = 0; i < len1; i++)
            {
                first[i] = arr[mainArrayIndex];
                mainArrayIndex++;
            }

            mainArrayIndex = mid + 1;
            for (int i = 0; i < len2; i++)
            {
                second[i] = arr[mainArrayIndex];
                mainArrayIndex++;
            }

            //sort
            mainArrayIndex = s;
            int index1 = 0;
            int index2 = 0;

            while (index1 < len1 && index2 < len2)
            {
                if (first[index1] < second[index2])
                {
                    arr[mainArrayIndex] = first[index1];
                    index1++;
                    mainArrayIndex++;
                }
                else
                {
                    arr[mainArrayIndex] = second[index2];
                    index2++;
                    mainArrayIndex++;
                }
            }

            //Copy Remaining elements
            while (index1 < len1)
            {
                arr[mainArrayIndex] = first[index1];
                index1++;
                mainArrayIndex++;
            }

            while (index2 < len2)
            {
                arr[mainArrayIndex] = second[index2];
                index2++;
                mainArrayIndex++;
            }
        }
    }
}
