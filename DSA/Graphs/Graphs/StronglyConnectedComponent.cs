using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class StronglyConnectedComponent
    {
        public void SCCUsingKosaraju(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //visited, Ans 
            bool[] visited = new bool[vertex];
            Stack<int> ans = new Stack<int>();

            //Perform TOPO Sort
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSTopoSortKosaraju(i, adjList, ref visited, ref ans);
                }
            }

            //Transpose AdjList
            Dictionary<int, List<int>> transpose = new Dictionary<int, List<int>>();
            foreach (var item in adjList)
            {
                visited[item.Key] = false;
                foreach (var values in item.Value)
                {
                    if (transpose.ContainsKey(values))
                    {
                        transpose[values].Add(item.Key);
                    }
                    else
                    {
                        transpose.Add(values, new List<int>() { item.Key });
                    }
                }
            }

            //Count of Strongly Connected Components
            int count = 0;
            while (ans.Count() > 0)
            {
                int topNode = ans.Pop();
                if (!visited[topNode])
                {
                    count++;
                    ReverseDFSKosaraju(topNode, transpose, ref visited);
                }
            }

            Console.WriteLine("Strongly Connected Components Count using Kosaraju's Algo: {0}", count);
        }

        private void DFSTopoSortKosaraju(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref Stack<int> ans)
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
                                DFSTopoSortKosaraju(neighbour, adjList, ref visited, ref ans);
                            }
                        }
                    }
                }

                if (!ans.Contains(topNode))
                {
                    ans.Push(topNode);
                }
            }
        }

        private void ReverseDFSKosaraju(int node, Dictionary<int, List<int>> adjList, ref bool[] visited)
        {
            List<int> directedNode = new List<int>();
            bool result = adjList.TryGetValue(node, out directedNode);
            if (result)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    foreach (var neighbour in directedNode)
                    {
                        if (!visited[neighbour])
                        {
                            ReverseDFSKosaraju(neighbour, adjList, ref visited);
                        }
                    }
                }
            }
        }
    }
}
