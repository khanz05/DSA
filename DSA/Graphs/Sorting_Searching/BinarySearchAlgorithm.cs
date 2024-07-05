using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Sorting_Searching
{
    internal class BinarySearchAlgorithm
    {
        public int BinarySearchRecursion(int[] arr, int low, int high, int key)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = low + (high - low) / 2;

            if (arr[mid] == key)
            {
                return mid;
            }
            else if (arr[mid] > key)
            {
                return BinarySearchRecursion(arr, low, mid - 1, key);
            }
            else if (arr[mid] < key)
            {
                return BinarySearchRecursion(arr, mid + 1, high, key);
            }

            return -1;
        }

        private int BinarySearch(int[] nums, int s, int e, int key)
        {
            int mid = s + (e - s) / 2;

            while (s <= e)
            {
                if (nums[mid] == key)
                {
                    return mid;
                }
                else if (nums[mid] < key)
                {
                    s = mid + 1;
                }
                else if (nums[mid] > key)
                {
                    e = mid - 1;
                }

                mid = s + (e - s) / 2;
            }

            return -1;
        }

        #region First and Last Occurence of Element

        public int[] SearchRange(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            int lowAns = FirstOccurence(nums, target, low, high);
            int highAns = LastOccurence(nums, target, low, high);

            return new int[] { lowAns, highAns };

        }

        private int FirstOccurence(int[] nums, int target, int low, int high)
        {
            int mid = low + (high - low) / 2;
            int ans = -1;

            while (low <= high)
            {
                if (nums[mid] == target)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                mid = low + (high - low) / 2;
            }
            return ans;
        }

        private int LastOccurence(int[] nums, int target, int low, int high)
        {
            int mid = low + (high - low) / 2;
            int ans = -1;

            while (low <= high)
            {
                if (nums[mid] == target)
                {
                    ans = mid;
                    low = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                mid = low + (high - low) / 2;
            }
            return ans;
        }
        #endregion

        #region Pivot Element of Index

        public int getPivotElement(int[] arr)
        {
            int s = 0;
            int e = arr.Length - 1;
            int mid = s + (e - s) / 2;

            while (s < e)
            {
                if (arr[mid] >= arr[0])
                {
                    s = mid + 1;
                }
                else
                {
                    e = mid;
                }

                mid = s + (e - s) / 2;
            }

            return s;
        }

        #endregion

        #region More Precision Square Root

        public double MorePrecisionSquareRoot(int n, int precision)
        {
            int sqRoot = SquareRootBinarySearch(n);
            double factor = 1;
            double ans = sqRoot;

            for (int i = 0; i < precision; i++)
            {
                factor = factor / 10;
                for (double j = ans; j * j < n; j = j + factor)
                {
                    ans = j;
                }
            }

            return ans;

        }

        private int SquareRootBinarySearch(int n)
        {
            long s = 0;
            long e = n;

            long mid = s + (e - s) / 2;
            long ans = 0;
            while (s <= e)
            {
                long square = mid * mid;
                if (square == n)
                {
                    return (int)mid;
                }

                if (square < n)
                {
                    ans = mid;
                    s = mid + 1;
                }
                else
                {
                    e = mid - 1;
                }
                mid = s + (e - s) / 2;
            }

            return (int)ans;

        }

        #endregion

        #region Book Allocation

        public int BookAllocation(int[] A, int N, int M)
        {
            int s = 0;
            int e = sumOfPages(A);
            int mid = s + (e - s) / 2;
            int ans = -1;

            if (N < M) //when Num of Book < Num of Student
            {
                return -1;
            }

            while (s <= e)
            {
                if (IsPossible(A, N, M, mid))
                {
                    ans = mid;
                    e = mid - 1;
                }
                else
                {
                    s = mid + 1;
                }

                mid = s + (e - s) / 2;
            }

            return ans;
        }

        private bool IsPossible(int[] a, int n, int m, int mid)
        {
            int studentCount = 1;
            int pageSum = 0;

            for (int i = 0; i < n; i++)
            {
                if (pageSum + a[i] <= mid)
                {
                    pageSum += a[i];
                }
                else
                {
                    studentCount++;
                    if (studentCount > m || a[i] > mid)
                    {
                        return false;
                    }
                    pageSum = a[i];
                }
            }

            return true;
        }

        private int sumOfPages(int[] a)
        {
            int sum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
            }

            return sum;
        }

        #endregion
    }
}
