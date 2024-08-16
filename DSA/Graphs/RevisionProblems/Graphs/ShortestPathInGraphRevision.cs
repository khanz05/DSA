using Graphs.CommonFunctions;
using NetTopologySuite.Noding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems.Graphs
{
    internal class ShortestPathInGraphRevision
    {
        #region Shortest Path in Undirected Graphs

        public void ShortestPathForUndirectedGraph(int[,] edges, int source, int destination, int vertex)
        {
            Dictionary<int, List<int>> adjList = PrepareAdjList(edges, vertex);
            int[] parent = new int[vertex];
            bool[] visited = new bool[vertex];
            Queue<int> qNode = new Queue<int>();
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = int.MaxValue;
            }

            parent[source] = -1;
            qNode.Enqueue(source);

            while (qNode.Any())
            {
                int frontNode = qNode.Dequeue();
                if (!visited[frontNode])
                {
                    visited[frontNode] = true;
                    List<int> directedNode = new List<int>();
                    bool result = adjList.TryGetValue(frontNode, out directedNode);
                    if (result)
                    {
                        foreach (var neigh in directedNode)
                        {
                            if (!visited[neigh] && parent[neigh] == int.MaxValue)
                            {
                                parent[neigh] = frontNode;
                                qNode.Enqueue(neigh);
                            }
                        }
                    }
                }
            }

            List<int> ans = new List<int>();

            int curentIndex = destination;
            ans.Add(curentIndex);
            while (curentIndex != source)
            {
                curentIndex = parent[curentIndex];
                ans.Add(curentIndex);
            }

            ans.Reverse();

            Console.WriteLine("Shortest path in Undirected Graph");
            foreach (var item in ans)
            {
                Console.Write(item + " -> ");
            }
        }

        #endregion

        #region Shortest Path Directed Weighted Graphs

        public void ShortestDistanceForWeightedGraph(int source)
        {
            GraphWeighted grph = new GraphWeighted();
            grph.PrepareWeightedEdge(0, 1, 5);
            grph.PrepareWeightedEdge(0, 2, 3);
            grph.PrepareWeightedEdge(1, 2, 2);
            grph.PrepareWeightedEdge(1, 3, 6);
            grph.PrepareWeightedEdge(2, 3, 7);
            grph.PrepareWeightedEdge(2, 4, 4);
            grph.PrepareWeightedEdge(2, 5, 2);
            grph.PrepareWeightedEdge(3, 4, -1);
            grph.PrepareWeightedEdge(4, 5, -2);

            Dictionary<int, Dictionary<int, int>> adjList = grph.adjList;
            int v = 6;

            Stack<int> ansStack = new Stack<int>();

            //Topo Sort
            bool[] visited = new bool[v];
            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                {
                    TopoDFS(i, adjList, ref visited, ref ansStack);
                }
            }

            int[] distance = new int[v];
            for (int i = 0; i < v; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[source] = 0;

            //Minimum Distance w.r.t weight
            while (ansStack.Any())
            {
                int topNode = ansStack.Pop();
                int distanceFromSource = distance[topNode];
                if (distanceFromSource != int.MaxValue)
                {
                    Dictionary<int, int> directedNode = new Dictionary<int, int>();
                    bool result = adjList.TryGetValue(topNode, out directedNode);
                    if (result)
                    {
                        foreach (var neigh in directedNode)
                        {
                            int dest = neigh.Key;
                            int weight = neigh.Value;

                            int newWeight = distanceFromSource + weight;
                            distance[dest] = Math.Min(newWeight, distance[dest]);
                        }
                    }

                }
            }

            Console.WriteLine($"Shortest Path from Source {source} to each node: ");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"{source} -> {i}: {distance[i]}");

            }
        }

        private void TopoDFS(int node, Dictionary<int, Dictionary<int, int>> adjList, ref bool[] visited, ref Stack<int> ansStack)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);

            while (sNode.Any())
            {
                int topNode = sNode.Pop();
                if (!visited[topNode])
                {
                    visited[topNode] = true;
                    Dictionary<int, int> directedNode = new Dictionary<int, int>();
                    bool result = adjList.TryGetValue(topNode, out directedNode);
                    if (result)
                    {
                        foreach (var item in directedNode)
                        {
                            var neigh = item.Key;
                            if (!visited[neigh])
                            {
                                TopoDFS(neigh, adjList, ref visited, ref ansStack);
                            }

                        }
                    }
                }

                ansStack.Push(topNode);
            }
        }

        #endregion

        #region Shortest Distance using Dijkstra's Algo

        public void ShortestPathUsingDijkstra(int source)
        {
            //Prepare Adj List
            GraphWeighted g = new GraphWeighted();
            int vertex = 5;
            g.PrepareWeightedEdge(0, 1, 7);
            g.PrepareWeightedEdge(0, 2, 1);
            g.PrepareWeightedEdge(0, 3, 2);
            g.PrepareWeightedEdge(1, 0, 7);
            g.PrepareWeightedEdge(1, 2, 3);
            g.PrepareWeightedEdge(1, 3, 5);
            g.PrepareWeightedEdge(1, 4, 1);
            g.PrepareWeightedEdge(2, 1, 3);
            g.PrepareWeightedEdge(2, 0, 1);
            g.PrepareWeightedEdge(3, 0, 2);
            g.PrepareWeightedEdge(3, 1, 5);
            g.PrepareWeightedEdge(3, 4, 7);
            g.PrepareWeightedEdge(4, 1, 1);
            g.PrepareWeightedEdge(4, 3, 7);

            //int vertex = 4;
            //g.PrepareWeightedEdge(0, 1, 5);
            //g.PrepareWeightedEdge(0, 2, 8);
            //g.PrepareWeightedEdge(1, 0, 5);
            //g.PrepareWeightedEdge(1, 2, 9);
            //g.PrepareWeightedEdge(1, 3, 2);
            //g.PrepareWeightedEdge(2, 0, 8);
            //g.PrepareWeightedEdge(2, 1, 9);
            //g.PrepareWeightedEdge(2, 3, 6);
            //g.PrepareWeightedEdge(3, 1, 2);
            //g.PrepareWeightedEdge(3, 2, 6);

            Dictionary<int, Dictionary<int, int>> adjList = g.adjList;

            bool[] visited = new bool[vertex];
            int[] distance = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[source] = 0;

            for (int i = 0; i < vertex; i++)
            {
                int src = int.MaxValue;
                int weight = int.MaxValue;

                for (int v = 0; v < vertex; v++)
                {
                    if (!visited[v] && distance[v] < weight)
                    {
                        src = v;
                        weight = distance[v];
                    }
                }

                Dictionary<int, int> directedNode = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(src, out directedNode);
                if (result)
                {
                    visited[src] = true;
                    foreach (var item in directedNode)
                    {
                        int dest = item.Key;
                        int wt = item.Value;

                        int newDistance = weight + wt;
                        distance[dest] = Math.Min(newDistance, distance[dest]);
                    }
                }
            }

            //Distance Array
            Console.WriteLine($"Shortest Distance using Dijkstra's from Source {source}: ");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"{source} -> {i}: {distance[i]}");
            }

        }

        #endregion

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
                    adjList.Add(u, new List<int>() { v });
                }
            }

            return adjList;
        }

        #endregion
    }

    #region Helper Class

    public class GraphWeighted
    {
        public Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();
        public void PrepareWeightedEdge(int source, int destination, int weight)
        {
            Dictionary<int, int> destWeig = new Dictionary<int, int>();
            destWeig.Add(destination, weight);
            if (adjList.ContainsKey(source))
            {
                adjList[source].Add(destination, weight);
            }
            else
            {
                adjList.Add(source, destWeig);
            }
        }
    }

    #endregion
}
