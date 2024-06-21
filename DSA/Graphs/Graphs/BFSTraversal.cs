using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class BFSTraversal
    {
        public void BFS(int[,] edges, int vertex)
        {
            //Prepeare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, false);

            //Visted Node
            bool[] visited = new bool[vertex];
            for (int i = 0; i < vertex; i++)
            {
                visited[i] = false;
            }

            List<int> ans = new List<int>();

            //Run BFSOfNode
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    BFSNodes(i, adjList, ref visited, ref ans);
                }
            }

            //Print BFS
            Console.WriteLine("BFS Traversal of Graph");
            foreach (var item in ans)
            {
                Console.Write(item + " -> ");
            }
        }

        private void BFSNodes(int node, Dictionary<int, List<int>> adjList, ref bool[] visited, ref List<int> qAns)
        {
            Queue<int> qNode = new Queue<int>();
            qNode.Enqueue(node);

            while (qNode.Count() != 0)
            {
                int frontNode = qNode.Dequeue();
                if (!visited[frontNode])
                {
                    qAns.Add(frontNode);
                }
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
                                qNode.Enqueue(neighbour);
                            }
                        }
                    }
                }
            }
        }
    }
}
