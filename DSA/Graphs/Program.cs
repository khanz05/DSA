using DSA.Heaps;
using Graphs.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Graphs.TrieDS;
using Graphs.BinaryTreeTopic;

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

            //Heap h = new Heap();

            //int[] arr = new int[] { -1, 54, 53, 55, 52, 50 };
            //int n = 5;

            //Console.WriteLine("Before Heapify");
            //h.PrintHeapify(ref arr, n);

            //for (int i = n/2; i > 0; i--)
            //{
            //    h.HeapifyMaxHeap(ref arr, n, i);
            //}

            //Console.WriteLine("After Heapify");
            //h.PrintHeapify(ref arr, n);

            ////Heap Sort
            //h.HeapSort(ref arr, n);

            //Console.WriteLine("After Heap Sort");
            //h.PrintHeapify(ref arr, n);

            #endregion

            #region Trie

            //Trie t = new Trie();
            //t.InsertWord("ARM");
            //t.InsertWord("DO");
            //t.InsertWord("TIME");
            //t.InsertWord("TIMER");

            //t.RemoveWord("TIME");
            //Console.WriteLine(t.SearchWord("TIME"));

            //string[] arr = { "CODING", "CODEZER", "CODINGNINJA", "CODER" };
            //int n = arr.Length;
            //Trie t = new Trie();
            //t.LongestCommonPrefix(arr, n);

            #region Longest Common Prefix

            //string[] arr = { "CODING", "CODEZER", "CODINGNINJA", "CODER" };
            //int n = arr.Length;

            //LongestCommonPrefix lcp = new LongestCommonPrefix();
            //lcp.LCP(arr, n);


            #endregion

            #region Phone Book Directory

            //Not complete
            //string[] arr = { "COD", "CODING", "CODDING", "CODE", "COLY" };
            //int n = arr.Length;
            //string prefix = "COD";
            //PhoneBookDirectory pbd = new PhoneBookDirectory();
            //pbd.PhoneBookDirectorySuggestion(arr, n, prefix);

            #endregion


            #endregion

            #region Tree

            #region Build Tree Using Recursion and Traversal

            //Node root = null;
            //BinaryTreeCreationTopic bt = new BinaryTreeCreationTopic();
            //root = bt.BuildTree(root);

            //Console.WriteLine("\n");
            //Console.WriteLine("\n");

            //Console.WriteLine("Level Order Traversal");
            //bt.LevelOrderTraversal(root);

            //Console.WriteLine("\n");

            //Console.WriteLine("Reverse Level Order Traversal");
            //bt.ReverseLevelOrderTraversal(root);

            //Console.WriteLine("\n");

            //Console.WriteLine("In-Order Traversal");
            //bt.InOrderTraversal(root);

            //Console.WriteLine("\n");

            //Console.WriteLine("Pre-Order Traversal");
            //bt.PreOrderTraversal(root);

            //Console.WriteLine("\n");

            //Console.WriteLine("Post-Order Traversal");
            //bt.PostOrderTraversal(root); 

            #endregion

            //1 3 7 -1 -1 11 -1 -1 5 17 -1 -1 -1

            #region Build Tree using Level Order

            Node root = null;
            BinaryTreeCreationTopic bt = new BinaryTreeCreationTopic();
            root = bt.BuildTreeUsingLevelOrder(root);

            #endregion

            #region Level Order Traversal
            //Console.WriteLine("\n");
            //Console.WriteLine("\n");
            //Console.WriteLine("Level Order Traversal");
            //bt.LevelOrderTraversal(root); 
            #endregion

            #region InOrder Traversal WithOut Recursion
            //Console.WriteLine("\n");
            //Console.WriteLine("In-Order Traversal W/O Recurrsion");
            //bt.InOrderTraversalWithOutRecursion(root); 
            #endregion

            #region PreOrder Traversal WithOut Recursion
            //Console.WriteLine("\n");
            //Console.WriteLine("Pre-Order Traversal W/O Recurrsion");
            //bt.PreOrderTraversalWithOutRecursion(root); 
            #endregion

            #region PostOrder Traversal WithOut Recursion
            //Console.WriteLine("\n");
            //Console.WriteLine("Post-Order Traversal W/O Recurrsion");
            //bt.PostOrderTraversalWithOutRecursion(root); 
            #endregion

            #region Height Of Tree
            //Console.WriteLine("\n");
            //int height = bt.HeightOfTree(root);
            //Console.Write("Height of Tree -> {0}", height); 
            #endregion

            #region Diameter Of Tree
            //Console.WriteLine("\n"); 
            //int diameter = bt.DiameterOfTree(root);
            //Console.Write("Diameter of Tree -> {0}", diameter); 
            #endregion

            #region Is Sum Tree
            //Console.WriteLine("\n");
            //bool IsSumTree = bt.IsSumTree(root);
            //Console.Write("Diameter of Tree -> {0}", IsSumTree); 
            #endregion

            #region Zig Zag Traversal of tree
            //Console.WriteLine("\n");
            //var ans = bt.ZigZagTraversal(root);

            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //} 
            #endregion

            #region Boundary Traversal of Tree

            //Console.WriteLine("\n");
            //var ans = bt.BoundaryTraversalOfTree(root);

            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Vertical Traversal

            //Console.WriteLine("\n");
            //var ans = bt.verticalOrder(root);

            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Diagonal Traversal

            //Console.WriteLine("\n");
            //var ans = bt.DiagonalOrder(root);

            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Sum Of Long Root To Leaf Path

            //Console.WriteLine("\n");
            //var ans = bt.sumOfLongRootToLeafPath(root);

            //Console.Write("SumOfLongRootToLeafPath "+ ans + " ");

            #endregion

            #region K Sum 

            //Console.WriteLine("\n");
            //int k = 3;
            //var ans = bt.sumK(root, k);

            //Console.Write("sumK " + ans + " ");

            #endregion

            #region Kth Ancestor in a Tree

            //Console.WriteLine("\n");
            //int k = 2;
            //int node = 4;
            //var ans = bt.kthAncestor(root, k, node);

            //Console.Write("kth Ancestor " + ans + " ");

            #endregion

            #region Burning Tree

            //Console.WriteLine("\n");
            //int node = 8;
            //var ans = bt.BurnTree(root, node);

            //Console.Write("Burn Time of Tree-> {0}", ans);

            #endregion

            #region Delete Node from BST

            //Console.WriteLine("\n");
            //int node = 70;
            //Node ans = bt.deleteNode(root, node);

            //bt.LevelOrderTraversal(ans);

            #endregion

            #region Kth Smallest in BST

            //Console.WriteLine("\n");
            //int k = 3;
            //int ans = bt.KthSmallestElement(root, k);

            //Console.Write("kth smallest element in BST-> {0}", ans);

            #endregion

            #region Predecessor & Successor

            //Console.WriteLine("\n");
            //int k = 3;
            //Node pre = null;
            //Node suc = null;
            //bt.findPreSuc(root, ref pre, ref suc, k);

            //Console.Write($"Predecessor of {k}-> {pre.data}. Successor of {k}-> {suc.data}");

            #endregion

            #region Is Balance Tree

            Console.WriteLine("\n");
            bool ans = bt.isBalancedTree(root);

            Console.Write($"Is Balanced Tree {ans}");

            #endregion

            #endregion

            Console.ReadLine();
        }
    }
}
