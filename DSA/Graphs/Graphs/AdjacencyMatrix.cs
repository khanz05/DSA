using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Topics
{
    internal class AdjacencyMatrix
    {
        public void DisplayAdjacencyMatrix(int[,] edges, int vertex, bool directed)
        {
            int[,] adjMatrix = new int[vertex, vertex];

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int u = edges[i, 0];
                int v = edges[i, 1];

                adjMatrix[u, v] = 1;
                if (!directed)
                {
                    adjMatrix[v, u] = 1;
                }
            }

            PrintAdjMatrix(adjMatrix);
        }

        private void PrintAdjMatrix(int[,] adjMatrix)
        {
            int row = adjMatrix.GetLength(0);
            int col = adjMatrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
