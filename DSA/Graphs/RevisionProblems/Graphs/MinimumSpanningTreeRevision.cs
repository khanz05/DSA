using Graphs.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems.Graphs
{
    internal class MinimumSpanningTreeRevision
    {
        #region Minimum Spanning tree using Prim's Algo

        public void MinimumSpanningTreeUsingPrims(int source = 0)
        {
            GraphEdge g = new GraphEdge();
            int vertex = 5;
            g.PrepareAdjList(0, 1, 2);
            g.PrepareAdjList(0, 3, 6);
            g.PrepareAdjList(1, 0, 2);
            g.PrepareAdjList(1, 2, 3);
            g.PrepareAdjList(1, 3, 8);
            g.PrepareAdjList(1, 4, 5);
            g.PrepareAdjList(2, 1, 3);
            g.PrepareAdjList(2, 4, 7);
            g.PrepareAdjList(3, 0, 6);
            g.PrepareAdjList(3, 1, 8);
            g.PrepareAdjList(4, 1, 5);
            g.PrepareAdjList(4, 2, 7);

            Dictionary<int, Dictionary<int, int>> adjList = g.adjList;

            int[] miniWt = new int[vertex];
            int[] parent = new int[vertex];
            bool[] mst = new bool[vertex];

            for (int i = 0; i < vertex; i++)
            {
                miniWt[i] = int.MaxValue;
                parent[i] = -1;
            }

            miniWt[0] = 0;
            for (int i = 0; i < vertex; i++)
            {
                int src = int.MaxValue;
                int mini = int.MaxValue;

                for (int j = 0; j < vertex; j++)
                {
                    if (!mst[j] && miniWt[j] < mini)
                    {
                        src = j;
                        mini = miniWt[j];
                    }
                }

                Dictionary<int, int> directedNode = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(src, out directedNode);
                if (result)
                {
                    foreach (var neigh in directedNode)
                    {
                        int dest = neigh.Key;
                        int wt = neigh.Value;
                        if (!mst[dest] && wt < miniWt[dest])
                        {
                            parent[dest] = src;
                            miniWt[dest] = wt;
                        }
                    }
                }

                mst[src] = true;
            }

            //Minimum Spanning Weight
            int sum = 0;
            for (int i = 0; i < vertex; i++)
            {
                sum = sum + miniWt[i];
            }
            Console.WriteLine($"Weight of MST -> {sum}");

            Console.WriteLine("Minimum Spanning tree: ");
            for (int i = 1; i < parent.Length; i++)
            {
                int directedNode = parent[i];
                Console.Write($"{directedNode} -> {i}");
                Console.WriteLine("\n");
            }
        }

        #endregion

        #region Minimum Spanning Tree using Kruskal's Algo

        public void MinimumSpannigTreeUsingKruskal()
        {
            int e = 9;
            int vertex = 7;

            int[] rank = new int[vertex];
            int[] parent = new int[vertex];

            //Initialize all Parent and Rank
            for (int i = 0; i < vertex; i++)
            {
                rank[i] = 0;
                parent[i] = i;
            }

            EdgeSort[] edges = new EdgeSort[e];
            for (int i = 0; i < e; i++)
            {
                edges[i] = new EdgeSort();
            }

            edges[0].source = 1;
            edges[0].destination = 2;
            edges[0].weight = 2;
            
            edges[1].source = 1;
            edges[1].destination = 5;
            edges[1].weight = 4;
            
            edges[2].source = 1;
            edges[2].destination = 4;
            edges[2].weight = 1;
            
            edges[3].source = 4;
            edges[3].destination = 5;
            edges[3].weight = 9;
            
            edges[4].source = 4;
            edges[4].destination = 3;
            edges[4].weight = 5;
            
            edges[5].source = 2;
            edges[5].destination = 4;
            edges[5].weight = 3;
            
            edges[6].source = 2;
            edges[6].destination = 6;
            edges[6].weight = 7;
            
            edges[7].source = 2;
            edges[7].destination = 3;
            edges[7].weight = 3;
            
            edges[8].source = 3;
            edges[8].destination = 6;
            edges[8].weight = 8;

            Array.Sort(edges);

            int minWeight = 0;

            for (int i = 0; i < edges.Length; i++)
            {
                int x = edges[i].source;
                int y = edges[i].destination;
                int wt = edges[i].weight;

                int u = FindParent(ref parent, x);
                int v = FindParent(ref parent, y);

                if (u != v)
                {
                    Union(u, v, ref parent, ref rank);
                    minWeight += wt;
                }
            }

            Console.WriteLine($"Weight of MST -> {minWeight}");
        }

        private int FindParent(ref int[] parent, int node)
        {
            if (parent[node] == node)
            {
                return node;
            }

            return parent[node] = FindParent(ref parent, parent[node]);
        }

        private void Union(int u, int v, ref int[] parent, ref int[] rank)
        {
            u = FindParent(ref parent, u);
            v = FindParent(ref parent, v);

            if (rank[u] > rank[v])
            {
                parent[v] = u;
            }
            else if (rank[u] < rank[v])
            {
                parent[u] = v;
            }
            else 
            {
                parent[v] = u;
                rank[u]++;
            }
        }

        #endregion
    }

    #region Helper Class

    public class EdgeSort : IComparable<EdgeSort>
    {
        public int source, destination, weight;

        public int CompareTo(EdgeSort other)
        {
            return this.weight.CompareTo(other.weight);
        }
    }

    public class GraphEdge
    {
        public Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();

        public void PrepareAdjList(int source, int destination, int weight)
        {
            Dictionary<int, int> destWt = new Dictionary<int, int>();
            destWt.Add(destination, weight);
            if (adjList.ContainsKey(source))
            {
                adjList[source].Add(destination, weight);
            }
            else
            {
                adjList.Add(source, destWt);
            }
        }

    }

    #endregion
}
