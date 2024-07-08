using NetTopologySuite.Operation.Valid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.BitwiseOperation
{
    internal class BitwiseOperationAlgorithm
    {
        #region Decimal To Binary

        public void DecimalToBinary()
        {
            Console.WriteLine("Enter Number for Binary Converstion");
            int n = Convert.ToInt32(Console.ReadLine());
            int val = n; // val to preserve the entered num.
            int ans = 0;
            int i = 0;
            while (n != 0)
            {
                int bit = n & 1;

                ans = ((int)(bit * Math.Pow(10, i))) + ans;

                n = n >> 1;
                i++;
            }

            Console.WriteLine($"Binary of {val} --> {ans}");

        }

        #endregion

        #region Binary To Decimal

        public void BinaryToDecimal()
        {
            while (true)
            {
                Console.WriteLine("Enter Number for Decimal Converstion");
                int n = Convert.ToInt32(Console.ReadLine());
                int val = n; // val to preserve the entered num.
                int ans = 0;
                int i = 0;
                while (n != 0)
                {
                    int digit = n % 10;
                    if (digit == 1)
                    {
                        ans = (int)(Math.Pow(2, i)) + ans;
                    }
                    n = n / 10;
                    i++;
                }

                Console.WriteLine($"Binary of {val} --> {ans}");
                Console.WriteLine("\n");
            }
        } 

        #endregion

        #region Prime Number using Sieve

        public int IsPrime(int n)
        {
            int cnt = 0;
            Dictionary<int, bool> isPrime = new Dictionary<int, bool>();

            for (int i = 1; i <= n; i++)
            {
                isPrime[i] = true;
            }

            isPrime[0] = isPrime[1] = false;
            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                {
                    cnt++;

                    for (int j = 2 * i; j < n; j = j + i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return cnt;
        }

        #endregion

        #region Segmented Sieve

        /// <summary>
        /// Code not complete
        /// </summary>
        /// <param name="n"></param>
        public void SegmentedSieve(int n)
        {
            int limit = (int)(Math.Floor(Math.Sqrt(n)) + 1);
            ArrayList prime = new ArrayList();
            SimpleSieve(limit, ref prime);

            int low = limit;
            int high = 2 * limit;

            while (low < n)
            {
                if (high >= n)
                {
                    high = n;
                }

                bool[] mark = new bool[limit + 1];
                for (int i = 0; i < mark.Length; i++)
                {
                    mark[i] = true;
                }

                for (int i = 0; i < prime.Count; i++)
                {
                    int loLim = ((int)Math.Floor((double)(low /
                            (int)prime[i])) * (int)prime[i]);
                    if (loLim < low)
                        loLim += (int)prime[i];
                }

                for (int i = low; i < high; i++)
                    if (mark[i - low] == true)
                        Console.Write(i + " ");

                // Update low and high for next segment
                low = low + limit;
                high = high + limit;
            }
        }

        public void SimpleSieve(int n, ref ArrayList prime)
        {
            Dictionary<int, bool> isPrime = new Dictionary<int, bool>();

            for (int i = 1; i <= n; i++)
            {
                isPrime[i] = true;
            }

            isPrime[0] = isPrime[1] = false;
            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = 2 * i; j < n; j = j + i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                {
                    prime.Add(i);
                }
            }
        } 

        #endregion
    }
}
