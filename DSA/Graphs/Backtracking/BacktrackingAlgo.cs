using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Backtracking
{
    internal class BacktrackingAlgo
    {
        #region Rat In Maze Problem

        public List<string> FindRatPath(int[,] mat)
        {
            List<string> ans = new List<string>();
            if (mat[0, 0] == 0)
                return ans;

            string path = string.Empty;
            int n = mat.GetLength(0);
            int[,] visited = new int[n, n];
            InitializeArray(ref visited);

            solve(0, 0, mat, ref visited, n, path, ref ans);

            return ans;
        }

        private void solve(int x, int y, int[,] mat, ref int[,] visited, int n, string path, ref List<string> ans)
        {
            //base case
            if (x == n - 1 && y == n - 1)
            {
                ans.Add(path);
                return;
            }

            //Movement-- D, L, R, U

            //Down
            if (isPathAllowed(x + 1, y, mat, ref visited, n))
            {
                visited[x, y] = 1;
                solve(x + 1, y, mat, ref visited, n, path + "D", ref ans);
            }

            //Left
            if (isPathAllowed(x, y - 1, mat, ref visited, n))
            {
                visited[x, y] = 1;
                solve(x, y - 1, mat, ref visited, n, path + "L", ref ans);
            }

            //Rigth
            if (isPathAllowed(x, y + 1, mat, ref visited, n))
            {
                visited[x, y] = 1;
                solve(x, y + 1, mat, ref visited, n, path + "R", ref ans);
            }

            //Up
            if (isPathAllowed(x - 1, y, mat, ref visited, n))
            {
                visited[x, y] = 1;
                solve(x - 1, y, mat, ref visited, n, path + "U", ref ans);
            }

            visited[x, y] = 0;

        }

        private bool isPathAllowed(int newX, int newY, int[,] mat, ref int[,] visited, int n)
        {
            if ((newX >= 0 && newX < n) && (newY >= 0 && newY < n)
                && visited[newX, newY] != 1 && mat[newX, newY] == 1)
            {
                return true;
            }

            return false;
        }



        #endregion

        #region Helper Methods

        private void InitializeArray(ref int[,] dp)
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
    }
}
