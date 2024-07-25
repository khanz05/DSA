using NetTopologySuite.Index.HPRtree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.DPQuestions
{
    internal class DynamicProgramming
    {
        #region Min Cost of Climbing Stairs

        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }

            int ans = Math.Min(solveMemoization(ref cost, ref dp, n - 1), solveMemoization(ref cost, ref dp, n - 2));
            return ans;
        }

        //Recursion and Memoization
        private int solveMemoization(ref int[] cost, ref int[] dp, int n)
        {
            if (n == 0)
                return cost[0];

            if (n == 1)
                return cost[1];

            if (dp[n] != -1)
                return dp[n];

            dp[n] = cost[n] + Math.Min(solveMemoization(ref cost, ref dp, n - 1), solveMemoization(ref cost, ref dp, n - 2));
            return dp[n];
        }

        #endregion

        #region Coin Changes

        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0 && dp[i - coins[j]] != int.MaxValue)
                    {
                        int a = i - coins[j];
                        int k = dp[i - coins[j]];
                        dp[i] = Math.Min(dp[i], 1 + k);
                    }
                }
            }

            if (dp[amount] == int.MaxValue)
            {
                return -1;
            }

            return dp[amount];



        }


        #endregion

        #region Non-Adjacent Elements

        public int Rob(int[] nums)
        {
            //int n = nums.Length;
            //// return solve(nums, n -1);

            //int[] dp = new int[n];
            //for (int i = 0; i < dp.Length; i++)
            //    dp[i] = -1;

            return solveTab(nums);
        }

        //Tabulation
        private int solveTab(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = 0;

            dp[0] = nums[0];

            for (int i = 1; i < n; i++)
            {
                if (i - 2 >= 0 && i - 1 >= 0)
                {
                    int incl = dp[i - 2] + nums[i];
                    int excl = dp[i - 1];
                    dp[i] = Math.Max(incl, excl);
                }
            }

            return dp[n];
        }

        //Memoization
        private int solveMem(int[] nums, int n, ref int[] dp)
        {
            //Base case
            if (n < 0)
                return 0;

            if (n == 0)
                return nums[0];

            if (dp[n] != -1)
                return dp[n];

            int incl = solveMem(nums, n - 2, ref dp) + nums[n];
            int excl = solveMem(nums, n - 1, ref dp);

            dp[n] = Math.Max(incl, excl);
            return dp[n];
        }

        #endregion

        #region Derangement of elements

        public long CountDerangements(int n)
        {
            /*long[] dp = new long[n+1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = -1;
            }

            return solveMem(n, ref dp);*/

            return solveTab(n);
        }

        //Tabulation
        private long solveTab(int n)
        {
            long[] dp = new long[n + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 0;
            }

            dp[1] = 0;
            dp[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                long first = dp[i - 1];
                long second = dp[i - 2];
                long sum = first + second;
                dp[i] = (i - 1) * sum;
            }

            return dp[n];
        }


        //Recursive + Memoization
        private long solveMem(int n, ref long[] dp)
        {
            if (n == 1)
                return 0;

            if (n == 2)
                return 1;

            if (dp[n] != -1)
                return dp[n];

            dp[n] = (n - 1) * (solveMem(n - 1, ref dp) + solveMem(n - 2, ref dp));

            return dp[n];
        }

        #endregion

        #region Knapsack

        public int knapSack(int W, int[] wt, int[] val, int n)
        {
            //Recursion + Memoization
            //int[,] dp = new int[n, W + 1];
            //int row = dp.GetLength(0);
            //int col = dp.GetLength(1);
            //for(int i = 0; i < row; i++)
            //{
            //    for(int j = 0; j < col; j++)
            //    {
            //        dp[i, j] = -1;
            //    }
            //}

            //return solveMem(wt, val, n -1, W, ref dp);

            return solveTab(wt, val, n, W);



        }

        private int solveTab(int[] wt, int[] val, int n, int capacity)
        {
            //Initialize DP
            int[,] dp = new int[n, capacity + 1];
            int row = dp.GetLength(0);
            int col = dp.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    dp[i, j] = 0;
                }
            }

            //Analyze Base Case
            for (int w = wt[0]; w <= capacity; w++)
            {
                if (wt[0] <= capacity)
                    dp[0, w] = val[0];
                else
                    dp[0, w] = 0;
            }

            for (int index = 1; index < n; index++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    int include = 0;
                    if (wt[index] <= w)
                        include = val[index] + dp[index - 1, w - wt[index]]; //val[index] = including current val

                    int exclude = dp[index - 1, w];

                    dp[index, capacity] = Math.Max(include, exclude);
                }
            }

            return dp[n - 1, capacity];
        }

        //Recursion + Memoization
        private int solveMem(int[] wt, int[] val, int index, int capacity, ref int[,] dp)
        {
            //Base case
            if (index == 0)
            {
                if (wt[0] <= capacity)
                    return val[0];
                else
                    return 0;
            }

            if (dp[index, capacity] != -1)
                return dp[index, capacity];

            int include = 0;
            if (wt[index] <= capacity)
                include = val[index] + solveMem(wt, val, index - 1, capacity - wt[index], ref dp); //val[index] = including current val

            int exclude = solveMem(wt, val, index - 1, capacity, ref dp);

            dp[index, capacity] = Math.Max(include, exclude);

            return dp[index, capacity];

        }

        #endregion

        #region Number of ways

        public int NumberOfWaysCatalan(int n)
        {
            int result = 0;
            //base case
            if (n == 3)
            {
                return 1;
            }

            for (int i = 0; i < n; i++)
            {
                result += NumberOfWaysCatalan(i) * NumberOfWaysCatalan(n - i - 1);
            }

            return result;
        }

        #endregion

        #region Longest Increasing Subsequence

        public int LengthOfLIS(int[] nums)
        {
            //O(n log(n))
            int n = nums.Length;
            return solveOptimal(n, nums);
        }


        private int solveOptimal(int n, int[] a)
        {
            if (n == 0)
                return 0;

            List<int> ans = new List<int>();
            ans.Add(a[0]);

            for (int i = 1; i < n; i++)
            {
                int index = ans.Count();
                if (a[i] > ans[index - 1])
                    ans.Add(a[i]);
                else
                {
                    index = LowerBound(ans, a[i]);
                    ans[index] = a[i];
                }
            }

            return ans.Count();
        }

        private int LowerBound(List<int> arr, int tar)
        {
            int s = 0;
            int e = arr.Count() - 1;
            while (s < e)
            {
                int mid = s + (e - s) / 2;
                if (tar <= arr[mid])
                    e = mid;
                else
                    s = mid + 1;
            }

            return s;
        }

        #region Sort 2D Array

        public int MaxEnvelopes()
        {
            int[][] envelopes = new int[][] { new int[] { 5, 4 }, new int[] { 6, 4 }, new int[] { 6, 7 }, new int[] { 2, 3 } };

            int[][] arr = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
            int sum = 0;
            List<int> ls = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int bx = arr[i][1];
                if (ls.Count == 0)
                {
                    ls.Add(bx);
                }
                else if (ls[ls.Count - 1] < bx)
                {
                    ls.Add(bx);
                }
                else
                {
                    int start = 0;
                    int end = ls.Count - 1;
                    int ind = -1;
                    while (start <= end)
                    {
                        int mid = (start + end) / 2;
                        if (ls[mid] >= bx)
                        {
                            ind = mid;
                            end = mid - 1;
                        }
                        else
                        {
                            start = mid + 1;
                        }
                    }
                    ls[ind] = bx;
                }
            }
            return ls.Count;
        }

        #endregion

        #region Maximum Height By Stacking Cuboids

        public void MaxHeight()
        {
            int[][] cuboids = new int[][] { new int[] { 50, 45, 20 }, new int[] { 95, 37, 53 }, new int[] { 45, 23, 12 }};

            //Step-1: Sort all dimensions
            int n = cuboids.Length;
            for (int i = 0; i < n; i++)
            {
                Array.Sort(cuboids[i]);
            }

            //Step-2
            cuboids = cuboids.OrderBy(c => c[0]).ThenBy(c => c[1]).ThenBy(c => c[2]).ToArray();
        }

        #endregion

        #region Dice Roll

        public int NumRollsToTarget(int n, int k, int target)
        {
            //return solve(n, k, target);

            //int[,] dp = new int[n + 1, target + 1];
            //InitializeArrayMem(ref dp);
            //return solveMem(n, k, target, ref dp);

            return solveTab(n, k, target);
        }

        private int solveSC(int d, int f, int t)
        {
            int mod = 1000000007;
            int[] prev = new int[t + 1];
            //Array.Fill(prev, 0);
            int[] current = new int[t + 1];
            //Array.Fill(current, 0);
            prev[0] = 1;

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = 0;
                current[i] = 0;
            }

            for (int dice = 1; dice <= d; dice++)
            {
                for (int target = 1; target <= t; target++)
                {
                    int ans = 0;
                    for (int i = 1; i <= f; i++)
                    {
                        if (target - i >= 0)
                        {
                            ans = ((ans + prev[target - i]) % mod);
                        }
                    }
                    current[target] = ans;
                }

                prev = current;
            }

            return prev[t];
        }

        private int solveTab(int d, int f, int t)
        {
            int mod = 1000000007;
            int[,] dp = new int[d + 1, t + 1];
            InitializeArrayTab(ref dp);
            dp[0, 0] = 1;

            for (int dice = 1; dice <= d; dice++)
            {
                for (int target = 1; target <= t; target++)
                {
                    int ans = 0;
                    for (int i = 1; i <= f; i++)
                    {
                        if (target - i >= 0)
                        {
                            ans = ans + dp[dice - 1, target - i];
                            ans = ans % mod;
                        }
                    }
                    dp[dice, target] = ans;
                }
            }

            return dp[d, f];
        }

        private int solveMem(int dice, int faces, int target, ref int[,] dp)
        {
            int mod = 1000000007;

            //base case
            if (target < 0)
                return 0;
            if (dice == 0 && target != 0)
                return 0;
            if (target == 0 && dice != 0)
                return 0;
            if (dice == 0 && target == 0)
                return 1;

            if (dp[dice, target] != -1)
                return dp[dice, target];

            int ans = 0;
            for (int i = 1; i <= faces; i++)
            {
                ans = ans + solveMem(dice - 1, faces, target - i, ref dp);
                ans = ans % mod;
            }
            return dp[dice, target] = ans;
        }

        private int solve(int dice, int faces, int target)
        {
            //base case
            if (target < 0)
                return 0;
            if (dice == 0 && target != 0)
                return 0;
            if (target == 0 && dice != 0)
                return 0;
            if (dice == 0 && target == 0)
                return 1;

            int ans = 0;
            for (int i = 1; i <= faces; i++)
            {
                ans = ans + solve(dice - 1, faces, target - i);
            }

            return ans;
        }

        

        private void InitializeArrayTab(ref int[,] dp)
        {
            int row = dp.GetLength(0);
            int col = dp.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    dp[i, j] = 0;
                }
            }
        }

        #endregion

        #region Min Swap

        public int MinSwap(int[] nums1, int[] nums2)
        {
            /*bool swapped = false;
            List<int> listNums1 = nums1.ToList();
            listNums1.Insert(0, -1);
            List<int> listNums2 = nums2.ToList();
            listNums2.Insert(0, -1);
            nums1 = listNums1.ToArray();
            nums2 = listNums2.ToArray();

            return solve(nums1, nums2, 1, swapped);*/

            //Recursion + Memoization
            bool swapped = false;
            List<int> listNums1 = nums1.ToList();
            listNums1.Insert(0, -1);
            List<int> listNums2 = nums2.ToList();
            listNums2.Insert(0, -1);
            nums1 = listNums1.ToArray();
            nums2 = listNums2.ToArray();
            int n = nums1.Length;

            int[,] dp = new int[n, 2];
            InitializeArrayMem(ref dp);

            return solveMem(nums1, nums2, 1, swapped, ref dp);
        }

        private int solveMem(int[] nums1, int[] nums2, int index, bool swapped, ref int[,] dp)
        {
            //base case
            if (index == nums1.Length)
                return 0;

            int i = swapped ? 1 : 0;
            if (dp[index, i] != -1)
                return dp[index, i];

            int ans = int.MaxValue;

            int prev1 = nums1[index - 1];
            int prev2 = nums2[index - 1];

            //main point
            if (swapped)
                swap(ref prev1, ref prev2);

            //no swap
            if (nums1[index] > prev1 && nums2[index] > prev2)
                ans = solveMem(nums1, nums2, index + 1, false, ref dp);

            //swap
            if (nums1[index] > prev2 && nums2[index] > prev1)
                ans = Math.Min(ans, 1 + solveMem(nums1, nums2, index + 1, true, ref dp));

            //i = swapped ? 1 : 0;
            return dp[index, i] = ans;
        }
        

        #endregion

        #region Helper Methods

        private void swap(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        private void InitializeArrayMem(ref int[,] dp)
        {
            int row = dp.GetLength(0);
            int col = dp.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    dp[i, j] = -1;
                }
            }
        }

        #endregion

        #endregion

        #region Longest Arithmetic Progression

        public int LongestArithSeqLength(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
                return n;

            Dictionary<int, int>[] dp = new Dictionary<int, int>[n];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new Dictionary<int, int>();
            }

            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int diff = nums[i] - nums[j];
                    int cnt = 1;

                    //check if ans already present in dp
                    if (dp[j].ContainsKey(diff))
                        cnt = dp[j][diff];

                    dp[i][diff] = 1 + cnt;
                    ans = Math.Max(ans, dp[i][diff]);
                }
            }

            return ans;
        }

        #endregion

        #region Longest Arithmetic Subsequence of Given Difference

        public int LongestSubsequence(int[] arr, int difference)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int n = arr.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                int temp = arr[i] - difference;
                int tempAns = 0;
                //Check if temp is present in dp 
                if (dp.ContainsKey(temp))
                    tempAns = dp[temp];

                //Current answer update
                dp[arr[i]] = 1 + tempAns;
                ans = Math.Max(ans, dp[arr[i]]);
            }

            return ans;
        }

        #endregion
    }
}
