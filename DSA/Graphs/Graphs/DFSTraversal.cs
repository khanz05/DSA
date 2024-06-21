using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class DFSTraversal
    {
        public void DFS(int[,] edges, int vertex)
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

            List<int> ans = new List<int>();

            //Perform DFS
            for (int i = 2; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSNode(i, adjList, ref visited, ref ans);
                }
            }

            //Print DFS
            Console.WriteLine("DFS of Graph");
            foreach (var item in ans)
            {
                Console.Write(item + "-> ");
            }
            Console.WriteLine("\n");

        }

        private void DFSNode(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref List<int> ans)
        {
            Stack<int> sNode = new Stack<int>();
            sNode.Push(node);

            while (sNode.Count() > 0)
            {
                int topNode = sNode.Pop();
                if (!visited[topNode])
                {
                    ans.Add(topNode);
                }
                List<int> directNode = new List<int>();
                bool result = adjList.TryGetValue(topNode, out directNode);
                if (result)
                {
                    if (!visited[topNode])
                    {
                        visited[topNode] = true;
                        foreach (var neighbour in directNode)
                        {
                            if (!visited[neighbour])
                            {
                                DFSNode(neighbour, adjList, ref visited, ref ans);
                            }
                        }
                    }
                }
            }
        }
    }
}
