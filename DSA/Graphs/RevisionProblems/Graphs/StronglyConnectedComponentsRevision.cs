using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems.Graphs
{
    internal class StronglyConnectedComponentsRevision
    {
        public void SCCUsingKosaraju(int[,] edges, int vertex)
        {
            Dictionary<int, List<int>> adjList = PrepareAdjList(edges, vertex);

            bool[] visited = new bool[vertex];
            Stack<int> topoStack = new Stack<int>();

            //Topo Sort
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSTopoSort(i, adjList, ref visited, ref topoStack);
                }
            }

            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
            }

            //Reverse AdjList
            Dictionary<int, List<int>> transposeList = new Dictionary<int, List<int>>();
            foreach (var item in adjList)
            {
                visited[item.Key] = false;
                foreach (var val in item.Value)
                {
                    if (transposeList.ContainsKey(val))
                    {
                        transposeList[val].Add(item.Key);
                    }
                    else
                    {
                        transposeList.Add(val, new List<int>() { item.Key });
                    }
                }
            }


            int countSCC = 0;
            //Perform DFS on Reverse AdjList and TopoSort
            while (topoStack.Any())
            {
                int topNode = topoStack.Pop();
                if (!visited[topNode])
                {
                    countSCC++;
                    ReverseDFS(topNode, transposeList, ref visited);
                }
            }

            Console.WriteLine("Strongly Connected Components Count using Kosaraju's Algo: {0}", countSCC);
        }

        private void DFSTopoSort(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref Stack<int> topoStack)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);

            while (sNode.Any())
            {
                int topNode = sNode.Pop();
                if (!visited[topNode])
                {
                    visited[topNode] = true;
                    List<int> directedNode = new List<int>();
                    bool result = adjList.TryGetValue(topNode, out directedNode);
                    if (result)
                    {
                        foreach (var neigh in directedNode)
                        {
                            if (!visited[neigh])
                            {
                                DFSTopoSort(neigh, adjList, ref visited, ref topoStack);
                            }
                        }
                    }
                }

                topoStack.Push(topNode);
            }
        }

        private void ReverseDFS(int topNode, Dictionary<int, List<int>> adjList, ref bool[] visited)
        {
            if (!visited[topNode])
            {
                visited[topNode] = true;
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(topNode, out directedNode);
                if (result)
                {
                    foreach (var neigh in directedNode)
                    {
                        if (!visited[neigh])
                        {
                            ReverseDFS(neigh, adjList, ref visited);
                        }
                    }
                }
            }
        }

        #region Helper Methods

        private Dictionary<int, List<int>> PrepareAdjList(int[,] edges, int vertex)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < vertex; i++)
            {
                int u = edges[i, 0];
                int v = edges[i, 1];
                if (adjList.ContainsKey(u))
                {
                    adjList[u].Add(v);
                }
                else
                {
                    adjList.Add(u, new List<int> { v });
                }
            }

            return adjList;
        }

        #endregion
    }
}
