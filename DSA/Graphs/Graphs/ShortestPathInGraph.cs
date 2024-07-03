using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class ShortestPathInGraph
    {
        #region Shortest path for Undirected, non-weighted Graph

        public void ShortestPathForUndirectedGraph(int[,] edges, int source, int destination, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //distance, visited, parent
            int[] distance = new int[vertex];
            bool[] visited = new bool[vertex];
            Dictionary<int, int> parent = new Dictionary<int, int>();
            for (int i = 0; i < vertex; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            //Perform BFS
            Queue<int> qNode = new Queue<int>();
            qNode.Enqueue(source);
            parent[source] = -1;

            while (qNode.Count() > 0)
            {
                int frontNode = qNode.Dequeue();
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(frontNode, out directedNode);
                if (result)
                {
                    if (!visited[frontNode])
                    {
                        visited[frontNode] = true;
                        foreach (var neighbour in directedNode)
                        {
                            if (!visited[neighbour])
                            {
                                if (!qNode.Contains(neighbour))
                                {
                                    qNode.Enqueue(neighbour);
                                    parent[neighbour] = frontNode;
                                }
                            }
                        }
                    }
                }
            }

            List<int> ans = new List<int>();

            //Find Distance using parent
            int currentNode = destination;
            ans.Add(currentNode);
            while (currentNode != source)
            {
                currentNode = parent[currentNode];
                ans.Add(currentNode);
            }

            ans.Reverse();
            //Print
            Console.Write($"Shortest path from {source} to {destination}: ");
            foreach (var item in ans)
            {
                Console.Write(item + "-> ");
            }
        }

        #endregion

        #region Shortest Distance in Directed weighted Graph

        /// <summary>
        /// Acyclic Graph
        /// </summary>
        /// <param name="source"></param>
        public void ShortestDistanceForWeightedGraph(int source)
        {
            //Prepare Graph
            Graph g = new Graph();
            g.AddEdgesWithWeights(0, 1, 5);
            g.AddEdgesWithWeights(0, 2, 3);
            g.AddEdgesWithWeights(1, 2, 2);
            g.AddEdgesWithWeights(1, 3, 6);
            g.AddEdgesWithWeights(2, 3, 7);
            g.AddEdgesWithWeights(2, 4, 4);
            g.AddEdgesWithWeights(2, 5, 2);
            g.AddEdgesWithWeights(3, 4, -1);
            g.AddEdgesWithWeights(4, 5, -2);

            //Prepare Adj List
            Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();
            adjList = g.adjList;

            int vertex = 6;

            //Visited and Parent
            bool[] visited = new bool[vertex];
            int[] distance = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
                distance[i] = int.MaxValue;
            }

            //Distance of Source to Source
            distance[source] = 0;

            //Store TOPO sort ans
            Stack<int> ans = new Stack<int>();

            //Perform Topological Sort
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSTopoSort(i, adjList, ref visited, ref ans, -1);
                }
            }

            //Shortest Path Calculation
            ShortestPathWeighted(source, adjList, ref ans, ref distance);

            //Print Distance
            Console.WriteLine($"Shortest Path from Source {source} to each node: ");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"{source} -> {i}: {distance[i]}");

            }
        }

        private void DFSTopoSort(int node, Dictionary<int, Dictionary<int, int>> adjList, ref bool[] visited, ref Stack<int> ans, int p)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);

            while (sNode.Count() > 0)
            {
                int topNode = sNode.Pop();
                Dictionary<int, int> directedNode = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(topNode, out directedNode);
                if (result)
                {
                    if (!visited[topNode])
                    {
                        visited[topNode] = true;
                        foreach (var item in directedNode)
                        {
                            int v = item.Key;
                            int wt = item.Value;
                            DFSTopoSort(v, adjList, ref visited, ref ans, topNode);
                        }
                    }
                }

                if (!ans.Contains(topNode))
                {
                    ans.Push(topNode);
                }
            }
        }

        private void ShortestPathWeighted(int source, Dictionary<int, Dictionary<int, int>> adjList, ref Stack<int> ans, ref int[] distance)
        {
            while (ans.Count() > 0)
            {
                int topNode = ans.Pop();
                int distanceFromSource = distance[topNode];
                foreach (var item in adjList)
                {
                    if (item.Key == topNode)
                    {
                        if (distanceFromSource != int.MaxValue)
                        {
                            Dictionary<int, int> directedNode = new Dictionary<int, int>();
                            bool result = adjList.TryGetValue(topNode, out directedNode);
                            if (result)
                            {
                                foreach (var neighbour in directedNode)
                                {
                                    int v = neighbour.Key;
                                    int wt = neighbour.Value;
                                    int newDistance = distance[topNode] + wt;
                                    distance[v] = Math.Min(distance[v], newDistance);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Shortest Distance using Dijkstra's Algo

        public void ShortestPathUsingDijkstra(int source)
        {
            //Prepare Adj List
            Graph g = new Graph();
            int vertex = 5;
            g.AddEdgesWithWeights(0, 1, 7);
            g.AddEdgesWithWeights(0, 2, 1);
            g.AddEdgesWithWeights(0, 3, 2);
            g.AddEdgesWithWeights(1, 0, 7);
            g.AddEdgesWithWeights(1, 2, 3);
            g.AddEdgesWithWeights(1, 3, 5);
            g.AddEdgesWithWeights(1, 4, 1);
            g.AddEdgesWithWeights(2, 1, 3);
            g.AddEdgesWithWeights(2, 0, 1);
            g.AddEdgesWithWeights(3, 0, 2);
            g.AddEdgesWithWeights(3, 1, 5);
            g.AddEdgesWithWeights(3, 4, 7);
            g.AddEdgesWithWeights(4, 1, 1);
            g.AddEdgesWithWeights(4, 3, 7);

            //int vertex = 4;
            //g.AddEdgesWithWeights(0, 1, 5);
            //g.AddEdgesWithWeights(0, 2, 8);
            //g.AddEdgesWithWeights(1, 0, 5);
            //g.AddEdgesWithWeights(1, 2, 9);
            //g.AddEdgesWithWeights(1, 3, 2);
            //g.AddEdgesWithWeights(2, 0, 8);
            //g.AddEdgesWithWeights(2, 1, 9);
            //g.AddEdgesWithWeights(2, 3, 6);
            //g.AddEdgesWithWeights(3, 1, 2);
            //g.AddEdgesWithWeights(3, 2, 6);

            var adjList = g.adjList;

            //Visited and Distance
            bool[] visited = new bool[vertex];
            int[] distance = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
                distance[i] = int.MaxValue;
            }

            //Check Minimum distance w.r.t Weight
            distance[source] = 0;

            for (int i = 0; i < vertex; i++)
            {
                int u = new int();
                int mini = int.MaxValue;

                for (int v = 0; v < vertex; v++)
                {
                    if (visited[v] == false && distance[v] < mini)
                    {
                        u = v;
                        mini = distance[v];
                    }
                }

                visited[u] = true;
                Dictionary<int, int> directedNodes = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(u, out directedNodes);
                if (result)
                {
                    foreach (var item in directedNodes)
                    {
                        int v = item.Key;
                        int wt = item.Value;
                        int newDistance = distance[u] + wt;
                        distance[v] = Math.Min(distance[v], newDistance);
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

        #region Shortest Distance using Bellman Ford Algo

        public void ShortestPathUsingBellmanFord(int source, int destination)
        {
            Graph g = new Graph();
            int vertex = 4;
            g.AddEdgesWithWeights(1, 2, 2);
            g.AddEdgesWithWeights(1, 3, 2);
            g.AddEdgesWithWeights(2, 3, -1);

            var adjList = g.adjList;

            bool[] visited = new bool[vertex];
            int[] distance = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[source] = 0;

            //Check all shortest distance N-1 times
            for (int i = 1; i <= vertex - 1; i++)
            {
                int u = i;
                Dictionary<int, int> directedNode = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(u, out directedNode);
                if (result)
                {
                    foreach (var neighbour in directedNode)
                    {
                        int v = neighbour.Key;
                        int wt = neighbour.Value;
                        if (distance[u] != int.MaxValue && (distance[u] + wt) < distance[v])
                        {
                            distance[v] = (distance[u] + wt);
                        }
                    }
                }
            }

            //Check if negative cycle present
            bool flag = false;
            for (int i = 1; i <= vertex - 1; i++)
            {
                int u = i;
                Dictionary<int, int> directedNode = new Dictionary<int, int>();
                bool result = adjList.TryGetValue(u, out directedNode);
                if (result)
                {
                    foreach (var neighbour in directedNode)
                    {
                        int v = neighbour.Key;
                        int wt = neighbour.Value;
                        if (distance[u] != int.MaxValue && (distance[u] + wt) < distance[v])
                        {
                            flag = true;
                        }
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine("Negative Cycle present. Cannot determine shortest distance");
            }
            else
            {
                Console.WriteLine("Shortest Path from {0} -> {1}: {2}", source, destination, distance[destination]);
            }
        }

        #endregion
    }
}
