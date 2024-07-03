using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class TopologicalSort
    {
        #region Topological Sort in Acyclic Graph using DFS

        public void TopologicalSortUsingDFS(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //Visited
            bool[] visited = new bool[vertex];
            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
            }

            //Stack for ans, once DFS completed for Node store in stack.
            Stack<int> ans = new Stack<int>();

            //Perform Topo Sort
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    TopoSortDFS(i, adjList, ref visited, ref ans);
                }
            }

            //Print Topo Sort
            CommonFunction.PrintAdjList(adjList);

            Console.WriteLine("\n");
            Console.WriteLine("Topological Sort using DFS");
            while (ans.Count() > 0)
            {
                int topNode = ans.Pop();
                Console.Write(topNode + ", ");
            }
        }

        private void TopoSortDFS(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref Stack<int> ans)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);

            while (sNode.Count() > 0)
            {
                int topNode = sNode.Pop();
                List<int> directedNodes = new List<int>();
                bool result = adjList.TryGetValue(topNode, out directedNodes);
                if (result)
                {
                    if (!visited[topNode])
                    {
                        visited[topNode] = true;
                        foreach (var neighbour in directedNodes)
                        {
                            if (!visited[neighbour])
                            {
                                TopoSortDFS(neighbour, adjList, ref visited, ref ans);
                            }
                        }
                    }
                }

                if (visited[topNode])
                {
                    ans.Push(topNode);
                }

            }
        }


        #endregion

        #region Topological Sort Using Kahn's Algo

        public void TopologicalSortUsingKahnAlgo(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //Indegree of all nodes
            int[] indegreee = new int[vertex];
            foreach (var directedNode in adjList.Values)
            {
                foreach (var value in directedNode)
                {
                    indegreee[value]++;
                }
            }

            //Perform BFS
            Queue<int> qNode = new Queue<int>();
            for (int i = 0; i < vertex; i++)
            {
                if (indegreee[i] == 0)
                {
                    qNode.Enqueue(i);
                }
            }

            List<int> ans = new List<int>();

            while (qNode.Count() > 0)
            {
                int frontNode = qNode.Dequeue();

                ans.Add(frontNode);
                List<int> directedNode = new List<int>();
                bool result = adjList.TryGetValue(frontNode, out directedNode);
                if (result)
                {
                    foreach (var neighbour in directedNode)
                    {
                        indegreee[neighbour]--;
                        if (indegreee[neighbour] == 0)
                        {
                            qNode.Enqueue(neighbour);
                        }
                    }
                }
            }

            ans.RemoveAt(0);

            CommonFunction.PrintAdjList(adjList);

            //Print Topological Sort using Kahn's Algo
            Console.Write("Topological Sort using Kahn's Algo and BFS -> ");
            foreach (var item in ans)
            {
                Console.Write(item + " ");
            }
        }

        #endregion
    }
}
