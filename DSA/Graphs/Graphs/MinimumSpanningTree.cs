using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class MinimumSpanningTree
    {
        #region Minimum Spanning tree using Prim's Algo

        public void MinimumSpanningTreeUsingPrims(int source = 0)
        {
            //Prepare Adj List
            Graph g = new Graph();
            int vertex = 5;
            g.AddEdgesWithWeights(0, 1, 2);
            g.AddEdgesWithWeights(0, 3, 6);
            g.AddEdgesWithWeights(1, 0, 2);
            g.AddEdgesWithWeights(1, 2, 3);
            g.AddEdgesWithWeights(1, 3, 8);
            g.AddEdgesWithWeights(1, 4, 5);
            g.AddEdgesWithWeights(2, 1, 3);
            g.AddEdgesWithWeights(2, 4, 7);
            g.AddEdgesWithWeights(3, 0, 6);
            g.AddEdgesWithWeights(3, 1, 8);
            g.AddEdgesWithWeights(4, 1, 5);
            g.AddEdgesWithWeights(4, 2, 7);

            var adjList = g.adjList;

            int[] minWt = new int[vertex];
            bool[] mst = new bool[vertex];
            int[] parent = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                minWt[i] = int.MaxValue;
                mst[i] = false;
                parent[i] = -1;
            }

            minWt[source] = 0;
            for (int i = 0; i < vertex; i++)
            {
                int u = new int();
                int mini = int.MaxValue;

                for (int v = 0; v < vertex; v++)
                {
                    if (mst[v] == false && minWt[v] < mini)
                    {
                        u = v;
                        mini = minWt[v];
                    }
                }

                Dictionary<int, int> directedNodes = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(u, out directedNodes);
                if (result)
                {
                    foreach (var neighbour in directedNodes)
                    {
                        int v = neighbour.Key;
                        int wt = neighbour.Value;
                        if (mst[v] == false && wt < minWt[v])
                        {
                            parent[v] = u;
                            minWt[v] = wt;
                        }
                    }
                }

                mst[u] = true;
            }

            //Minimum Spanning Weight
            int sum = 0;
            for (int i = 0; i < vertex; i++)
            {
                sum = sum + minWt[i];
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
            int edges = 9;
            int vertex = 7;

            //Create rank and parent for Union
            int[] rank = new int[vertex];
            int[] parent = new int[vertex];

            //Make Set
            MakeSet(ref rank, ref parent, vertex);

            //Create Edges
            Edges[] edge = new Edges[edges];
            for (int i = 0; i < edge.Length; i++)
            {
                edge[i] = new Edges();
            }

            edge[0].source = 1;
            edge[0].destination = 2;
            edge[0].weight = 2;

            edge[1].source = 1;
            edge[1].destination = 5;
            edge[1].weight = 4;

            edge[2].source = 1;
            edge[2].destination = 4;
            edge[2].weight = 1;

            edge[3].source = 4;
            edge[3].destination = 5;
            edge[3].weight = 9;

            edge[4].source = 4;
            edge[4].destination = 3;
            edge[4].weight = 5;

            edge[5].source = 2;
            edge[5].destination = 4;
            edge[5].weight = 3;

            edge[6].source = 2;
            edge[6].destination = 6;
            edge[6].weight = 7;

            edge[7].source = 2;
            edge[7].destination = 3;
            edge[7].weight = 3;

            edge[8].source = 3;
            edge[8].destination = 6;
            edge[8].weight = 8;

            Array.Sort(edge);

            int minWeight = 0;

            for (int i = 0; i < edge.Length; i++)
            {
                int x = edge[i].source;
                int y = edge[i].destination;
                int u = FindParent(ref parent, x);
                int v = FindParent(ref parent, y);
                int wt = edge[i].weight;

                if (u != v)
                {
                    Union(u, v, ref rank, ref parent);
                    minWeight = minWeight + wt;
                }
            }

            Console.WriteLine($"Weight of MST -> {minWeight}");
        }

        private void MakeSet(ref int[] rank, ref int[] parent, int vertex)
        {
            for (int i = 0; i < vertex; i++)
            {
                rank[i] = 0;
                parent[i] = i;
            }
        }

        private void Union(int u, int v, ref int[] rank, ref int[] parent)
        {
            u = FindParent(ref parent, u);
            v = FindParent(ref parent, v);
            if (rank[u] > rank[v])
            {
                parent[v] = u;
            }
            else if (rank[v] > rank[u])
            {
                parent[u] = v;
            }
            else
            {
                parent[v] = u;
                rank[u]++;
            }
        }

        private int FindParent(ref int[] parent, int node)
        {
            if (parent[node] == node)
            {
                return node;
            }
            return parent[node] = FindParent(ref parent, parent[node]);
        }

        #endregion
    }
}
