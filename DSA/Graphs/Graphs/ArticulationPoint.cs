using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class ArticulationPoint
    {
        public void FindArticulationPoint(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, true);

            //discoveryTime, lowestTimeRequired, visited, parent
            int[] discoveryTime = new int[vertex];
            int[] lowestTimeRequired = new int[vertex];
            bool[] visited = new bool[vertex];
            int timer = 0;

            for (int i = 0; i < vertex; i++)
            {
                discoveryTime[i] = -1;
                lowestTimeRequired[i] = -1;
                visited[i] = false;
            }

            //Store Ans
            List<int> ans = new List<int>();

            //Perform DFS
            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSArticulation(i, -1, adjList, ref visited, ref discoveryTime, ref lowestTimeRequired, ref timer, ref ans);
                }
            }

            Console.WriteLine("Articulation Point in Graph");
            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }

        }

        private void DFSArticulation(int node, int parent, Dictionary<int, List<int>> adjList, ref bool[] visited, ref int[] discoveryTime, ref int[] lowestTimeRequired, ref int timer,
            ref List<int> ans)
        {
            discoveryTime[node] = lowestTimeRequired[node] = timer;
            timer++;
            
            List<int> directedNode = new List<int>();
            bool result = adjList.TryGetValue(node, out directedNode);
            if (result)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    foreach (var neighbour in directedNode)
                    {
                        if (neighbour == parent)
                        {
                            continue;
                        }
                        if (!visited[neighbour])
                        {
                            DFSArticulation(neighbour, node, adjList, ref visited, ref discoveryTime, ref lowestTimeRequired, ref timer, ref ans);
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], lowestTimeRequired[neighbour]);
                            //Check Articulation Point
                            if (lowestTimeRequired[neighbour] >= discoveryTime[node] && parent != -1)
                            {
                                ans.Add(node);
                            }
                            else if (!ans.Contains(node) && parent == -1 && directedNode.Count() > 0)
                            {
                                ans.Add(node);
                            }
                        }
                        else
                        {
                            //Back Edge
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], discoveryTime[neighbour]);
                        }
                    }
                }
            }
        }
    }
}
