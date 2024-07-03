using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Topics
{
    internal class AdjacencyList
    {
        #region Non Weighted Graphs

        public void PrepareNonWeightedAdjList(int[,] edges, int vertex, bool directed)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int u = edges[i, 0];
                int v = edges[i, 1];
                if (adjList.ContainsKey(u))
                {
                    adjList[u].Add(v);
                }
                else
                {
                    adjList.Add(u, new List<int>() { v });
                }

                if (!directed)
                {
                    if (adjList.ContainsKey(v))
                    {
                        adjList[v].Add(u);
                    }
                    else
                    {
                        adjList.Add(v, new List<int>() { u });
                    }

                }
            }

            PrintAdjListNonWeighted(adjList);
        }

        private void PrintAdjListNonWeighted(Dictionary<int, List<int>> adjList)
        {
            foreach (var item in adjList)
            {
                Console.Write($"Vertex: {item.Key}-> ");
                foreach (var Values in item.Value)
                {
                    Console.Write(Values + ", ");
                }
            }
        } 

        #endregion
    }
}
