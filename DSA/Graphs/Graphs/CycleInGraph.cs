using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class CycleInGraph
    {
        #region Undirected BFS

        public void CycleInUndirectedGraphUsingBFS(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true); //Using True for better understanding and less iteration

            //Visited and Parent
            bool[] visited = new bool[vertex];
            Dictionary<int, int> parent = new Dictionary<int, int>();
            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    bool cycleFound = IsCycleUsingBFSUndirected(i, adjList, ref visited, ref parent);
                    if (cycleFound)
                    {
                        Console.WriteLine("Cycle Found in Undirected BFS");
                        break;
                    }
                }
            }
        }

        private bool IsCycleUsingBFSUndirected(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref Dictionary<int, int> parent)
        {
            Queue<int> qNode = new Queue<int>();
            qNode.Enqueue(node);
            parent[node] = -1;

            while (qNode.Count() > 0)
            {
                int frontNode = qNode.Dequeue();
                List<int> directedNodes = new List<int>();
                bool result = adjList.TryGetValue(frontNode, out directedNodes);
                if (result)
                {
                    if (!visited[frontNode])
                    {
                        visited[frontNode] = true;
                        foreach (var neighbour in directedNodes)
                        {
                            if (!visited[neighbour] && !qNode.Contains(neighbour))
                            {
                                qNode.Enqueue(neighbour);
                                parent[neighbour] = frontNode;
                            }
                            else if (visited[neighbour] && parent[frontNode] != neighbour)
                            {
                                return true;
                            }
                        }
                    }
                }

            }


            return false;
        }

        #endregion

        #region Undirected DFS

        public void CycleInUndirectedGraphUsingDFS(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true); //Using True for better understanding and less iteration

            //visited and parent
            bool[] visited = new bool[vertex];
            Dictionary<int, int> parent = new Dictionary<int, int>();
            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
            }

            //Perform DFS Cycle
            bool cycleFound = false;
            for (int i = 0; i < vertex; i++)
            {
                cycleFound = IsCycleUsingDFSUndirected(i, adjList, ref visited, ref parent, -1);
                if (cycleFound)
                {
                    Console.WriteLine("Cycle found in Undirected Graph using DFS");
                    break;
                }
            }
            if (!cycleFound)
            {
                Console.WriteLine("No Cycle found in Undirected Graph using DFS");
            }
        }

        private bool IsCycleUsingDFSUndirected(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref Dictionary<int, int> parent, int p)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);
            parent[node] = p;

            while (sNode.Count() > 0)
            {
                int topNode = sNode.Pop();
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(topNode, out directedNode);
                if (result)
                {
                    if (!visited[topNode])
                    {
                        visited[topNode] = true;
                        foreach (var neighbour in directedNode)
                        {
                            if (!visited[neighbour])
                            {
                                bool cycle = IsCycleUsingDFSUndirected(neighbour, adjList, ref visited, ref parent, topNode);
                                if (cycle)
                                {
                                    return true;
                                }
                            }
                            else if (neighbour != parent[topNode])
                            {
                                return true;
                            }
                        }
                    }
                }
            }


            return false;
        }

        #endregion

        #region Directed Graph Using DFS

        public void CycleUsingDirectedGraphInDFS(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //Visited, DFSVisited and parent
            bool[] visited = new bool[vertex];
            bool[] dfsVisited = new bool[vertex];
            Dictionary<int, int> parent = new Dictionary<int, int>();

            //Perform Cycle DFS
            bool cycleFound = false;
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    cycleFound = IsCycleUsingDFSDirected(i, adjList, ref visited, ref dfsVisited, ref parent, -1);
                    if (cycleFound)
                    {
                        Console.WriteLine("No Cycle found in Directed Graph using DFS");
                        break;
                    }
                }
            }

            if (!cycleFound)
            {
                Console.WriteLine("No Cycle found in Directed Graph using DFS");
            }
        }

        private bool IsCycleUsingDFSDirected(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref bool[] dfsVisited, ref Dictionary<int, int> parent, int p)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);
            parent[node] = p;

            while (sNode.Count() > 0)
            {
                int topNode = sNode.Pop();
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(topNode, out directedNode);
                if (result)
                {
                    if (!visited[topNode])
                    {
                        visited[topNode] = true;
                        dfsVisited[topNode] = true;
                        foreach (var neighbour in directedNode)
                        {
                            if (!visited[neighbour])
                            {
                                bool cycleFound = IsCycleUsingDFSDirected(neighbour, adjList, ref visited, ref dfsVisited, ref parent, topNode);
                                if (cycleFound)
                                {
                                    return true;
                                }
                            }
                            else if (dfsVisited[neighbour])
                            {
                                return true;
                            }
                        }
                    }
                }
                dfsVisited[topNode] = false;
            }

            return false;
        }

        #endregion
    }
}
