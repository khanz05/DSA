using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.CommonFunctions
{
    internal sealed class CommonFunction
    {
        public static void PrepareAdjList(int[,] edges, ref Dictionary<int, List<int>> adjList, bool directed)
        {
            for (int i = 0; i < edges.GetLength(0); i++)
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

                if (!directed)
                {
                    if (adjList.ContainsKey(v))
                    {
                        adjList[v].Add(u);
                    }
                    else
                    {
                        adjList.Add(v, new List<int>() { u });
                    }

                }
            }
        }

        public static void PrintAdjList(Dictionary<int, List<int>> adjList)
        {
            foreach (var node in adjList)
            {
                Console.Write("Vertex: "+ node.Key + "-> ");
                foreach (var neighbour in node.Value)
                {
                    Console.Write(neighbour + ", ");
                }
            }
            Console.WriteLine("\n");
        }

        public static void Swap(ref int[] arr, int i, int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }
    }

    public class Graph
    {
        public Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();
        public void AddEdgesWithWeights(int source, int destination, int weight)
        {
            Dictionary<int, int> uv = new Dictionary<int, int>();
            uv.Add(destination, weight);
            if (adjList.ContainsKey(source))
            {
                adjList[source].Add(destination, weight);
            }
            else
            {
                adjList.Add(source, uv);
            }
        }
    }

    public class Edges : IComparable<Edges>
    {
        public int source, destination, weight;
        public int CompareTo(Edges other)
        {
            return this.weight - other.weight;
        }
    }
}
