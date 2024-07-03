using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.CommonFunctions;

namespace Graphs.Topics
{
    internal class Bridges
    {
        public void BridgeInGraph(int[,] edges, int vertex)
        {
            //Prepare Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            CommonFunction.PrepareAdjList(edges, ref adjList, false);

            //DiscoveryTime, LowestTimeRequired, Visited
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

            //Save ans 
            Dictionary<int, int> ans = new Dictionary<int, int>();

            for (int i = 0; i < vertex; i++)
            {
                if (!visited[i])
                {
                    DFSBridge(i, -1, adjList, ref visited, ref discoveryTime, ref lowestTimeRequired, ref timer, ref ans);
                }
            }

            Console.WriteLine("Bridges in Graph");
            foreach (var item in ans)
            {
                Console.WriteLine($"{item.Key}-> {item.Value}");
            }

        }

        private void DFSBridge(int node, int parent, Dictionary<int, List<int>> adjList, ref bool[] visited, ref int[] discoveryTime, ref int[] lowestTimeRequired, ref int timer, ref Dictionary<int, int> ans)
        {
            lowestTimeRequired[node] = discoveryTime[node] = timer;
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
                            DFSBridge(neighbour, node, adjList, ref visited, ref discoveryTime, ref lowestTimeRequired, ref timer, ref ans);
                            lowestTimeRequired[node] = Math.Min(lowestTimeRequired[node], lowestTimeRequired[neighbour]);
                            //Check for Bridge
                            if (lowestTimeRequired[neighbour] > discoveryTime[node])
                            {
                                ans.Add(node, neighbour);
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
