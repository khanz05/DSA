using NetTopologySuite.Index.HPRtree;
using NetTopologySuite.Triangulate.QuadEdge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems.Graphs
{
    internal class ArticulationPointRevision
    {
        public void FindArticulationPoint(int[,] edges, int vertex)
        {
            Dictionary<int, List<int>> adjList = PrepareAdjList(edges, vertex);

            int[] lowestTimeRequired = new int[vertex];
            int[] discoveryTime = new int[vertex];
            bool[] visited = new bool[vertex];
            int timer = 0;
            bool[] ans = new bool[vertex];

            for (int i = 0; i < vertex; i++)
            {
                lowestTimeRequired[i] = -1;
                discoveryTime[i] = -1;
            }

            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSArticulationPoint(i, -1, adjList, ref lowestTimeRequired, ref discoveryTime, ref visited, ref timer, ref ans);
                }
            }

            Console.WriteLine("Articulation Point in Graph");
            for (int i = 0; i < vertex; i++)
            {
                if (ans[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
        }

        private void DFSArticulationPoint(int node, int parent, Dictionary<int, List<int>> adjList, ref int[] lowestTimeRequired, ref int[] discoveryTime, ref bool[] visited,
            ref int timer, ref bool[] ans)
        {
            lowestTimeRequired[node] = discoveryTime[node] = timer;
            timer++;
            int children = 0;

            if (!visited[node])
            {
                visited[node] = true;
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(node, out directedNode);
                if (result)
                {
                    foreach (var neigh in directedNode)
                    {
                        if (neigh == parent)
                        {
                            continue;
                        }
                        if (!visited[neigh])
                        {
                            DFSArticulationPoint(neigh, node, adjList, ref lowestTimeRequired, ref discoveryTime, ref visited, ref timer, ref ans);
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], lowestTimeRequired[neigh]);

                            //check for AP
                            if (lowestTimeRequired[neigh] >= discoveryTime[node] && parent != -1)
                            {
                                ans[node] = true;
                            }

                            children++;
                        }
                        else
                        {
                            //Back Edge
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], discoveryTime[neigh]);
                        }

                    }
                }

                if (parent == -1 && children > 1)
                {
                    ans[node] = true;
                }
            }

        }

        #region Helper Method

        private Dictionary<int, List<int>> PrepareAdjList(int[,] edges, int vertex)
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
