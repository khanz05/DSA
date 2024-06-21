using DSA.Heaps;
using Graphs.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Graphs

            #region Adjacency Matrix

            //AdjacencyMatrix adj = new AdjacencyMatrix();
            //int[,] arr = { { 0, 1 }, { 1, 2 }, { 2, 0 } };
            //int vertex = 3;
            //adj.DisplayAdjacencyMatrix(arr, vertex, false);

            #endregion

            #region Adjacency List

            //Test case-1
            //int vertex = 3;
            //int[,] edges = { { 0, 1 }, { 1, 2 }, { 2, 0 } };
            //AdjacencyList adjList = new AdjacencyList();
            //adjList.PrepareNonWeightedAdjList(edges, vertex, false);

            //Test case-2
            //int vertex = 4;
            //int[,] edges = { { 0, 1 }, { 1, 2 }, { 1, 3 }, { 2, 3 }, { 3, 0 } };
            //AdjacencyList adjList = new AdjacencyList();
            //adjList.PrepareNonWeightedAdjList(edges, vertex, false);


            #endregion

            #region BFS Traversal

            //int vertex = 4;
            //int[,] edges = { { 0, 1 }, { 0, 3 }, { 1, 2 }, { 2, 3 } };
            //BFSTraversal bfs = new BFSTraversal();
            //bfs.BFS(edges, vertex);

            #endregion

            #region DFS Traversal

            //int vertex = 4;
            //int[,] edges = { { 0, 1 }, { 0, 2 }, { 1, 2 }, { 2, 0 }, { 2, 3 }, { 3, 3 } };
            //DFSTraversal dfs = new DFSTraversal();
            //dfs.DFS(edges, vertex);

            #endregion

            #region Cycle in Undirected Graph using BFS

            //int vertex = 10;
            ////int[,] edges = { { 0, 1 }, { 0, 2 }, { 1, 2 }, { 2, 0 }, { 2, 3 }, { 3, 3 } };
            //int[,] edges = { { 1, 2 }, { 2, 1 }, { 2, 3 }, { 3, 2 }, { 4, 5 }, { 5, 4 }, { 5, 6 }, { 5, 7 }, { 6, 5 }, { 6, 8 }, { 7, 5 }, { 7, 8 }, { 8, 6 }, { 8, 7 }, { 8, 9 }, { 9, 8 } };
            //CycleInGraph cgf = new CycleInGraph();
            //cgf.CycleInUndirectedGraphUsingBFS(edges, vertex);

            #endregion

            #region Cycle in Undirected Graph using DFS

            //int vertex = 10;
            ////int[,] edges = { { 0, 1 }, { 0, 2 }, { 1, 2 }, { 2, 0 }, { 2, 3 }, { 3, 3 } };
            ////int[,] edges = { { 1, 2 }, { 2, 1 }, { 2, 3 }, { 3, 2 }, { 4, 5 }, { 5, 4 }, { 5, 6 }, { 5, 7 }, { 6, 5 }, { 6, 8 }, { 7, 5 }, { 7, 8 }, { 8, 6 }, { 8, 7 }, { 8, 9 }, { 9, 8 } };
            //int[,] edges = { { 1, 2 }, { 2, 1 }, { 2, 3 }, { 3, 2 }, { 4, 5 }, { 5, 4 }, { 5, 6 },  { 6, 5 }, { 6, 8 }, { 7, 8 }, { 8, 6 }, { 8, 7 }, { 8, 9 }, { 9, 8 } }; //No cycle
            //CycleInGraph cgf = new CycleInGraph();
            //cgf.CycleInUndirectedGraphUsingDFS(edges, vertex);

            #endregion

            #region Cycle in Directed Graph using DFS

            //int vertex = 9;
            ////int[,] edges = { { 0, 1 }, { 0, 2 }, { 1, 2 }, { 2, 0 }, { 2, 3 }, { 3, 3 } };
            ////int[,] edges = { { 1, 2 }, { 2, 3 }, { 2, 4 }, { 3, 7 }, { 3, 8 }, { 4, 5 }, { 5, 6 }, { 6, 4 }, { 8, 7 } }; //Cycle Present
            //int[,] edges = { { 1, 2 }, { 2, 3 }, { 2, 4 }, { 3, 7 }, { 3, 8 }, { 4, 5 }, { 5, 6 }, { 8, 7 } }; //Cycle Not Present
            //CycleInGraph cgf = new CycleInGraph();
            //cgf.CycleUsingDirectedGraphInDFS(edges, vertex);

            #endregion

            #region Topological Sort using DFS

            //int vertex = 7;
            //int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 3, 4 }, { 4, 5 }, { 4, 6 }, { 5, 6 }, { 6, 6 } };
            //TopologicalSort tp = new TopologicalSort();
            //tp.TopologicalSortUsingDFS(edges, vertex);

            #endregion

            #region Topological Sort using Kahn's Algo

            //int vertex = 7;
            //int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 3, 4 }, { 4, 5 }, { 4, 6 }, { 5, 6 }, { 6, 0 } };
            //TopologicalSort tp = new TopologicalSort();
            //tp.TopologicalSortUsingKahnAlgo(edges, vertex);

            #endregion

            #region Shortest path for Undirected, non-weighted Graph

            //int vertex = 10;
            //int[,] edges = { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 5 }, { 3, 8 }, { 4, 6 }, { 5, 8 }, { 6, 7 }, { 7, 8 }, { 8, 0 } };
            //int source = 1;
            //int destination = 8;
            //ShortestPathInGraph spg = new ShortestPathInGraph();
            //spg.ShortestPathForUndirectedGraph(edges, source, destination, vertex);

            #endregion

            #region Shortest Path for Directed, Weighted Graph

            //int source = 1;
            //ShortestPathInGraph spg = new ShortestPathInGraph();
            //spg.ShortestDistanceForWeightedGraph(source);

            #endregion

            #region Shortest Path using Dijkstra's Algo

            //int source = 1;
            //ShortestPathInGraph spg = new ShortestPathInGraph();
            //spg.ShortestPathUsingDijkstra(source);

            #endregion

            #region Shortest Distance using Bellman Ford Algo

            //int source = 1;
            //int destination = 3;
            //ShortestPathInGraph spg = new ShortestPathInGraph();
            //spg.ShortestPathUsingBellmanFord(source, destination);

            #endregion

            #region Minimum Spanning tree using Prim's Algo

            //int source = 0;
            //MinimumSpanningTree mst = new MinimumSpanningTree();
            //mst.MinimumSpanningTreeUsingPrims(source);

            #endregion

            #region Minimum Spanning Tree using Kruskal's Algo

            //MinimumSpanningTree mst = new MinimumSpanningTree();
            //mst.MinimumSpannigTreeUsingKruskal();

            #endregion

            #region Bridges in Graph

            //int[,] edges = { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 3, 0 }, { 3, 4 }, { 4, 3 } };
            //int vertex = 5;
            //Bridges bd = new Bridges();
            //bd.BridgeInGraph(edges, vertex);

            #endregion

            #region Articulation Point

            //int[,] edges = { { 0, 1 }, { 0, 3 }, { 0, 4 }, { 1, 2 }, { 3, 4 } };
            //int vertex = 5;
            //ArticulationPoint ap = new ArticulationPoint();
            //ap.FindArticulationPoint(edges, vertex);

            #endregion

            #region Strongly Connected Components- Kosaraju's Algo

            //int[,] edges = { { 0, 1 }, { 1, 2 }, { 1, 3 }, { 2, 0 }, { 3, 4 } };
            //int vertex = 5;
            //StronglyConnectedComponent scc = new StronglyConnectedComponent();
            //scc.SCCUsingKosaraju(edges, vertex);

            #endregion

            #endregion

            #region Heaps: Insertion, Deletion

            //Heap h = new Heap();
            //h.InsertInHeap(50);
            //h.InsertInHeap(55);
            //h.InsertInHeap(53);
            //h.InsertInHeap(52);
            //h.InsertInHeap(54);
            //h.PrintHeap();

            //h.DeleteFromHeap();
            //h.PrintHeap();

            #endregion

            #region Heapify & Heap Sort

            Heap h = new Heap();

            int[] arr = new int[] { -1, 54, 53, 55, 52, 50 };
            int n = 5;

            Console.WriteLine("Before Heapify");
            h.PrintHeapify(ref arr, n);
            
            for (int i = n/2; i > 0; i--)
            {
                h.HeapifyMaxHeap(ref arr, n, i);
            }

            Console.WriteLine("After Heapify");
            h.PrintHeapify(ref arr, n);

            //Heap Sort
            h.HeapSort(ref arr, n);

            Console.WriteLine("After Heap Sort");
            h.PrintHeapify(ref arr, n);

            #endregion

            Console.ReadLine();
        }
    }
}
