using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems.Graphs
{
    internal class BridgesRevision
    {
        public void BridgeInGraph(int[,] edges, int vertex)
        {
            Dictionary<int, List<int>> adjList = PrepareAdjList(edges, vertex);

            int[] discoveryTime = new int[vertex];
            int[] lowestTimeRequired = new int[vertex];
            bool[] visited = new bool[vertex];

            for (int i = 0; i < vertex; i++)
            {
                lowestTimeRequired[i] = -1;
                discoveryTime[i] = -1;
            }

            Dictionary<int, int> ans = new Dictionary<int, int>();
            int bridgeStartingIndex = -1;
            int timer = 0;

            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    //DFSBridgeTraversal(i, -1, adjList, ref discoveryTime, ref lowestTimeRequired, ref visited, ref timer, ref ans);
                    DFSBridgeTraversalTest(i, -1, adjList, ref discoveryTime, ref lowestTimeRequired, ref visited, ref timer, ref bridgeStartingIndex);
                }
            }

            if (bridgeStartingIndex == -1)
            {
                Console.Write("There are  no briges");
            }
            else
            {
                Console.WriteLine($"Bridges starting Vertex: {bridgeStartingIndex}");
            }

            if (ans.Count() > 0)
            {
                Console.WriteLine("Bridges in Graph");
                foreach (var item in ans)
                {
                    Console.WriteLine($"{item.Key}-> {item.Value}");
                }
            }
        }

        public void DFSBridgeTraversal(int node, int parent, Dictionary<int, List<int>> adjList, ref int[] discoveryTime, ref int[] lowestTimeRequired, ref bool[] visited, ref int timer, ref Dictionary<int, int> ans)
        {
            lowestTimeRequired[node] = discoveryTime[node] = timer;
            timer++;

            List<int> directedNode = new List<int>();
            bool result = adjList.TryGetValue(node, out directedNode);
            if (result)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    foreach (var neigh in directedNode)
                    {
                        if (neigh == parent)
                        {
                            continue;
                        }

                        if (!visited[neigh])
                        {
                            DFSBridgeTraversal(neigh, node, adjList, ref discoveryTime, ref lowestTimeRequired, ref visited, ref timer, ref ans);
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], lowestTimeRequired[neigh]);

                            //Check Bridge
                            if (lowestTimeRequired[neigh] > discoveryTime[node])
                            {
                                ans.Add(node, neigh);
                            }
                        }
                        else
                        {
                            //Back Edge
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], discoveryTime[neigh]);
                        }
                    }
                }
            }
        }

        public void DFSBridgeTraversalTest(int node, int parent, Dictionary<int, List<int>> adjList, ref int[] discoveryTime, ref int[] lowestTimeRequired, ref bool[] visited, ref int timer, ref int ans)
        {
            lowestTimeRequired[node] = discoveryTime[node] = timer;
            timer++;

            List<int> directedNode = new List<int>();
            bool result = adjList.TryGetValue(node, out directedNode);
            if (result)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    foreach (var neigh in directedNode)
                    {
                        if (neigh == parent)
                        {
                            continue;
                        }

                        if (!visited[neigh])
                        {
                            DFSBridgeTraversalTest(neigh, node, adjList, ref discoveryTime, ref lowestTimeRequired, ref visited, ref timer, ref ans);
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], lowestTimeRequired[neigh]);

                            //Check Bridge
                            if (lowestTimeRequired[neigh] > discoveryTime[node])
                            {
                                ans = node;
                            }
                        }
                        else
                        {
                            //Back Edge
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], discoveryTime[neigh]);
                        }
                    }
                }
            }
        }

        #region Helper Methods

        public Dictionary<int, List<int>> PrepareAdjList(int[,] edges, int vertex)
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
                    adjList.Add(u, new List<int>() { v });
                }

                if (adjList.ContainsKey(v))
                {
                    adjList[v].Add(u);
                }
                else
                {
                    adjList.Add(v, new List<int>() { u });
                }
            }


            return adjList;
        }

        #endregion
    }
}
