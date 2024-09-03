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
using Graphs.Sorting_Searching;
using System.Net.Http.Headers;
using Graphs.BitwiseOperation;
using Graphs.LinkedListOperations;
using Graphs.LinkedList;
using Graphs.RevisionProblems;
using System.Data;
using NetTopologySuite.Noding;
using Graphs.DPQuestions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Graphs.StackAndQueue;
using System.Collections;
using System.ComponentModel;
using Graphs.Heaps;
using Graphs.RevisionProblems.Graphs;
using Graphs.Greedy;
using NetTopologySuite.Index.HPRtree;
using Graphs.Backtracking;

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

            //int[,] edges = { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 3, 4 }, { 4, 3 } };
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

            #region Insert/ Delete/ Heapify/ heap Sort

            //int[] arr = new int[] { -1, 54, 53, 55, 52, 50 };
            //int n = 5;

            //int[] arr = new int[] { 7, 10, 4, 3, 20, 15 };
            //int n = 6;
            //int l = 0;
            //int r = 5;


            //Console.WriteLine("Before Heapify");
            //h.PrintHeapifyZero(ref arr);

            //Console.WriteLine("After Heapify");
            //int ans = h.kthSmallestheap(ref arr, l, r, k);
            //Console.WriteLine(ans);
            //h.PrintHeapifyZero(ref arr);

            //for (int i = r / 2; i >= 0; i--)
            //{
            //    h.HeapifyMaxHeapZero(ref arr, k+1, i);
            //}

            //h.PrintHeapifyZero(ref arr);



            //for (int i = n / 2; i > 0; i--)
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

            #region Kth Smallest

            //int[] arr = new int[] { 7, 10, 4, 3, 20, 15 };
            //int k = 4;
            //int l = 0, r = 5;
            //int ans = h.kthSmallestheap(ref arr, l, r, k);

            //Console.WriteLine($"Kth Smallest Element-> {ans}");


            #endregion

            #region Kth Largest

            //TC-1
            //int[] arr = { 3,2,1,5,6,4 };
            //int k= 2;

            //TC-1
            //int[] arr = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            //int k = 2;
            //int ans = h.FindKthLargestheap(arr, k);

            //Console.WriteLine($"Kth Largest Element-> {ans}");


            #endregion

            #region Merge Two Binary Max Heaps

            //int n = 4, m = 3;
            //int[] a = { 10, 5, 6, 2 };
            //int[] b = { 12, 7, 9 };
            //int []ans = h.mergeHeaps(a, b, n, m);

            //Console.Write("MergedHeap: -> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Minimum Cost of Ropes

            //int[] arr = { 4, 3, 2, 6 };
            //int n = arr.Length;
            //int ans = h.MinCostOfRopes(arr, n);

            //Console.Write($"Min Cost Of Ropes: -> {ans}");

            #endregion

            #region Get Kth Largest Sum SubArray

            //int[] arr = new int[] { 2, 6, 4, 1 };
            //int k = 3; 
            //int ans = h.getKthLargestSumSubArray(arr, k);

            //Console.WriteLine($"Kth Smallest Element-> {ans}");

            #endregion

            #region Merge k Sorted Arrays
            //int k = 3;
            //int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //4
            //1 2 3 4 0 5 10 15 2 4 8 10 3 9 27 81
            //int k = 4;
            //int[,] arr = { { 1, 2, 3, 4 }, { 0, 5, 10, 15 }, { 2, 4, 8, 10 }, { 3, 9, 27, 81 } };
            //var ans = h.MergeKSortedArrays(arr, k);

            //Console.WriteLine($"MergeKSortedArrays->");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}


            #endregion

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
            BinaryTreeCreationTopic bt = new BinaryTreeCreationTopic();

            #region Build Tree Using Recursion and Traversal

            //Node root = null;

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

            //Node root = null;
            //root = bt.BuildTreeUsingLevelOrder(root);

            #endregion

            #region Reverse Level Order

            //Console.WriteLine("Reverse Level Order Traversal");
            //bt.ReverseLevelOrderTraversal(root);

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
            //int diameter = bt.DiameterOfBinaryTree(root);
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
            //int node = 50;
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

            //Console.WriteLine("\n");
            //bool ans = bt.isBalancedTree(root);

            //Console.Write($"Is Balanced Tree {ans}");

            #endregion

            #region Heap using Tree

            #region Is Binary Tree Heap

            //Console.WriteLine("\n");
            //bool ans = h.isBinaryTreeHeap(root);

            //Console.Write($"Is Binary Tree heap-> {ans}");


            #endregion

            #region Convert BST to MinHeap

            //Console.WriteLine("\n");
            //Node ans = h.ConvertBSTtoMinHeap(root);

            //Console.WriteLine("Converted BST to Min Heap");
            //bt.LevelOrderTraversal(ans);

            #endregion

            #region Convert BST to MaxHeap

            //Console.WriteLine("\n");
            //Node ans = h.ConvertBSTtoMaxHeap(root);

            //Console.WriteLine("Converted BST to Max Heap");
            //bt.LevelOrderTraversal(ans);

            #endregion

            #endregion

            #endregion

            #region Searching and Sorting

            BinarySearchAlgorithm bs = new BinarySearchAlgorithm();

            #region Binary Search

            //int[] even = { 2, 4, 6, 8, 12, 18 };
            //int[] even = { 5, 7, 7, 8, 8, 10 };
            //int low = 0;
            //int high = even.Length - 1;
            //int key = 10;

            //int ans = bs.BinarySearch(even, low, high, key);
            //Console.Write($"Binary Search for even array {key} -> {ans}");
            //Console.WriteLine("\n");

            //int[] odd = { 3, 8, 11, 14, 16 };
            //int low = 0;
            //int high = odd.Length - 1;
            //int key = 11;

            //int ans = bs.BinarySearch(odd, low, high, key);
            //Console.Write($"Binary Search for odd array {key} -> {ans}");
            //Console.WriteLine("\n"); 
            #endregion

            #region Binary Sort Problem

            #region First and Last Element

            //int[] arr = { 5, 7, 7, 8, 8, 10 };
            //int target = 8;

            //int[] ans = bs.SearchRange(arr, target);
            //Console.Write($"First and Last Element {ans[0]} and {ans[1]}");
            //Console.WriteLine("\n");


            #endregion

            #region Pivot Element of Index

            //int ans = bs.getPivotElement(arr);
            //Console.Write($"Pivot Element -> {ans}");
            //Console.WriteLine("\n");

            #endregion

            #region Decimal Places Square Root

            //double ans = bs.MorePrecisionSquareRoot(6, 3);
            //Console.Write($"Decimal Precision SquareRoot -> {ans}");
            //Console.WriteLine("\n");

            #endregion

            #region Decimal Places Square Root

            //int[] arr = { 12, 34, 67, 90 };
            //int n = 4;
            //int m = 5;
            //int ans = bs.BookAllocation(arr, n, m);
            //Console.Write($"Book Allocation -> {ans}");
            //Console.WriteLine("\n");

            #endregion

            #region Lower Bound & Upper Bound

            //int tar = 6;
            //int[] arr = { 4, 6, 10, 12, 18, 20 };
            //int lower = bs.LowerBound(arr, tar);
            //int upper = bs.UpperBound(arr, tar);

            //Console.Write($"Target {tar}-> ");
            //Console.WriteLine($"Lower Bound: {lower} and Upper Bound: {upper}");

            #endregion

            #endregion

            #region Selection Sort

            SelectionSortAlgorithm ss = new SelectionSortAlgorithm();

            #region Using Swapping

            //int[] arr = { 4, 1, 3, 9, 7 };
            //int n = arr.Length;
            //ss.SelectionSort(ref arr, n);

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n"); 

            #endregion

            #region Using Shifting

            //int[] arr = { 4, 1, 3, 9, 7 };
            //int n = arr.Length;
            //ss.SelectionSortByShift(ref arr, n);

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");

            #endregion

            #endregion

            #region Bubble Sort

            BubbleSortAlgorithm bsa = new BubbleSortAlgorithm();

            //int N = 5;
            ////int[] arr = { 4, 1, 3, 9, 7 };
            //int[] arr = { 1, 3, 4, 7, 9 };
            //bsa.BubbleSort(ref arr, N);

            //Console.WriteLine("Bubble Sort: ");
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");

            #endregion

            #region Insertion Sort

            //InsertionSortAlgorithm ins = new InsertionSortAlgorithm();

            //int[] arr = { 5, 3, 1, 7, 9, 6 };
            //int N = arr.Length;
            //ins.InsertionSort(ref arr);

            //Console.WriteLine("Insertion Sort: ");
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");

            #endregion

            #region Merge Sort

            MergeSortAlgorithm msa = new MergeSortAlgorithm();

            //int[] arr = { 10, 1, 7, 4, 8, 2, 11 };
            //msa.MergeSort(ref arr);

            //Console.WriteLine("Merge Sort: ");
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");

            #endregion

            #region Quick Sort

            //QuickSortAlgorithm qsa = new QuickSortAlgorithm();

            //int[] arr = { 10, 1, 7, 4, 8, 2, 11 };
            //qsa.QuickSortAlgo(ref arr);

            //Console.WriteLine("Quick Sort: ");
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");

            #endregion

            #endregion

            #region Bitwise Operation

            BitwiseOperationAlgorithm bos = new BitwiseOperationAlgorithm();

            #region Decimal to Binary

            //bos.DecimalToBinary();

            #endregion

            #region Binary To Decimal

            //bos.BinaryToDecimal();

            #endregion

            #region Prime Number using Sieve

            //int n = 40;
            //int ans = bos.IsPrime(n);

            //Console.WriteLine($"No. of Prime numbers between 1 - {n} -> {ans}");
            //Console.WriteLine("\n");

            #endregion

            #region Segmented Sieve

            //int n = 10;
            //bos.SegmentedSieve(n);

            //Console.WriteLine($"No. of Prime numbers between 1 - {n} -> {ans}");
            //Console.WriteLine("\n");

            #endregion

            #region Missing Number
            //int[] nums = { 1, 2, 4, 5 };
            //int ans = bos.MissingNumber(nums);
            //Console.WriteLine($"Missing number in array {ans}");

            #endregion

            #endregion

            #region Linked List

            #region Singly Linked List

            SinglyLinkedList ll = new SinglyLinkedList();

            #region Insertion/Deletion

            //int[] arr = { 10, 20, 30, 40 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtHead(ref head, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //if (ll.IsCircular(head))
            //{
            //    Console.WriteLine("Is Circular");
            //}
            //else
            //{
            //    Console.WriteLine("Not Circular");
            //}

            //ll.PrintHead(ref head);

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //ll.InsertAtPosition(ref head, ref tail, 25, 3);
            //ll.PrintHead(ref head);

            //ll.InsertAtPosition(ref head, ref tail, 5, 1);
            //ll.PrintHead(ref head);

            //ll.DeleteAtPosition(ref head, 3);
            //ll.PrintHead(ref head);

            //Console.WriteLine($"Head {head.data}");
            //Console.WriteLine($"Tail {tail.data}");  

            #endregion

            #region Remove Duplicate in Unsorted List

            //int[] arr = { 20, 10, 20, 30, 10, 30, 30 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //ll.RemoveDuplicateMap(ref head);
            //Console.WriteLine("After removing unsorted duplicate");
            //ll.PrintHead(ref head);


            #endregion

            #region Sort a Linked List

            //int[] arr = { 40, 30, 10, 20 };
            //int[] arr = { 40, 25, 30, 10, 20 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //ll.SortUsingMerge(ref head);
            //Console.WriteLine("Sort list using Merge Sort");
            //ll.PrintHead(ref head);

            #endregion

            #region Sort 0's, 1's, 2's 

            #region Using Approach-1

            //int[] arr = { 1, 0, 1, 2, 1, 2, 0 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //ll.SortUsingCountApproachOne(ref head);
            //Console.WriteLine("Sort  0's, 1's, 2's");
            //ll.PrintHead(ref head);

            #endregion

            #region Using Approach-2

            //int[] arr = { 1, 0, 1, 2, 1, 2, 0 };
            ////int[] arr = { 0, 2, 2, 0 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //ll.PrintHead(ref head);

            //ll.SortUsingApproachTwo(ref head);
            //Console.WriteLine("Sort  0's, 1's, 2's");
            //ll.PrintHead(ref head);

            #endregion

            #endregion

            #region Merge Two Sorted LL

            #region Using Recursion

            //int[] arr1 = { 1, 4, 5 };
            //SingleNode head1 = new SingleNode(arr1[0]);
            //SingleNode tail1 = head1;
            //for (int i = 1; i < arr1.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail1, arr1[i]);
            //}
            //Console.WriteLine("Linked List-1");
            //ll.PrintHead(ref head1);

            //int[] arr2 = { 2, 3, 5 };
            //SingleNode head2 = new SingleNode(arr2[0]);
            //SingleNode tail2 = head2;
            //for (int i = 1; i < arr2.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail2, arr2[i]);
            //}

            //Console.WriteLine("Linked List-2");
            //ll.PrintHead(ref head2);

            //SingleNode headRef = ll.MergeTwoSortedLinkedListUsingRecursion(head1, head2);

            //Console.WriteLine("Merge Two Sorted List using Recursion");
            //ll.PrintHead(ref headRef);

            #endregion

            #region Using Iteration

            //int[] arr1 = { 1, 4, 5 };
            //SingleNode head1 = new SingleNode(arr1[0]);
            //SingleNode tail1 = head1;
            //for (int i = 1; i < arr1.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail1, arr1[i]);
            //}
            //Console.WriteLine("Linked List-1");
            //ll.PrintHead(ref head1);

            //int[] arr2 = { 2, 3, 5 };
            //SingleNode head2 = new SingleNode(arr2[0]);
            //SingleNode tail2 = head2;
            //for (int i = 1; i < arr2.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail2, arr2[i]);
            //}

            //Console.WriteLine("Linked List-2");
            //ll.PrintHead(ref head2);

            //SingleNode headRef = ll.MergeTwoSortedLinkedListUsingIteration(head1, head2);

            //Console.WriteLine("Merge Two Sorted List using Recursion");
            //ll.PrintHead(ref headRef);



            #endregion

            #endregion

            #region Palindrome

            //int[] arr = { 1, 2, 2, 1 };
            //SingleNode head = new SingleNode(arr[0]);
            //SingleNode tail = head;
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail, arr[i]);
            //}

            //Console.WriteLine("Linked List");
            //ll.PrintHead(ref head);

            //bool ans = ll.IsPalindrome(ref head);

            //Console.WriteLine($"Is Palindrome {ans}");

            #endregion

            #region Add Two Linked List

            //int[] arr1 = { 2, 4, 9 };
            ////int[] arr1 = { 2, 4, 3 };
            //SingleNode head1 = new SingleNode(arr1[0]);
            //SingleNode tail1 = head1;
            //for (int i = 1; i < arr1.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail1, arr1[i]);
            //}
            //Console.WriteLine("Linked List-1");
            //ll.PrintHead(ref head1);

            //int[] arr2 = { 5, 6, 4, 9 };
            ////int[] arr2 = { 5,6,4};
            //SingleNode head2 = new SingleNode(arr2[0]);
            //SingleNode tail2 = head2;
            //for (int i = 1; i < arr2.Length; i++)
            //{
            //    ll.InsertAtTail(ref tail2, arr2[i]);
            //}

            //Console.WriteLine("Linked List-2");
            //ll.PrintHead(ref head2);

            //SingleNode headRef = ll.AddTwoNumbersOther(head1, head2);

            //Console.WriteLine("Add two Linked List");
            //ll.PrintHead(ref headRef);

            #endregion

            #region Multilevel

            MultiLevelLinkedList L = new MultiLevelLinkedList();

            /*
             * Let us create the following linked list 5 -> 10
             * -> 19 -> 28 | | | | V V V V 7 20 22 35 | | | V V
             * V 8 50 40 | | V V 30 45
             */

            ////Test Case-1
            //L.head = L.Push(L.head, 30);
            //L.head = L.Push(L.head, 8);
            //L.head = L.Push(L.head, 7);
            //L.head = L.Push(L.head, 5);

            //L.head.next = L.Push(L.head.next, 20);
            //L.head.next = L.Push(L.head.next, 10);

            //L.head.next.next = L.Push(L.head.next.next, 50);
            //L.head.next.next = L.Push(L.head.next.next, 22);
            //L.head.next.next = L.Push(L.head.next.next, 19);

            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 45);
            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 40);
            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 35);
            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 28);

            //Test Case-2
            //L.head = L.Push(L.head, 17);
            //L.head = L.Push(L.head, 9);
            //L.head = L.Push(L.head, 3);

            //L.head.next = L.Push(L.head.next, 47);
            //L.head.next = L.Push(L.head.next, 10);

            //L.head.next.next = L.Push(L.head.next.next, 30);
            //L.head.next.next = L.Push(L.head.next.next, 15);
            //L.head.next.next = L.Push(L.head.next.next, 7);

            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 22);
            //L.head.next.next.next
            //    = L.Push(L.head.next.next.next, 14);

            //// Function call
            //L.head = L.FlattenNode(L.head);

            //L.printList();

            #endregion

            #endregion

            #region Doubly Linked List

            DoublyLinkedList dl = new DoublyLinkedList();

            //int[] arr = { 10, 20, 30, 40 };
            //DoubleNode head = new DoubleNode(arr[0]);
            //DoubleNode tail = head;

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    dl.InsertAtHeadDoubly(ref head, arr[i]);
            //}

            //dl.PrintHeadDouble(ref head);

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    dl.InsertAtTailDoubly(ref tail, arr[i]);
            //}

            //dl.PrintHeadDouble(ref head);

            //dl.InsertAtPositionDoubly(ref head, ref tail, 25, 3);
            //dl.PrintHeadDouble(ref head);

            //dl.InsertAtPositionDoubly(ref head, ref tail, 5, 1);
            //dl.PrintHeadDouble(ref head);

            //dl.InsertAtPositionDoubly(ref head, ref tail, 45, 7);
            //dl.PrintHeadDouble(ref head);

            //dl.DeleteDoublyAtPosition(ref head, 3);
            //dl.PrintHeadDouble(ref head);

            //Console.WriteLine($"Head {head.data}");
            //Console.WriteLine($"Tail {tail.data}");

            #endregion

            #region Circular Linked List

            CircularSinglyLinkedList cll = new CircularSinglyLinkedList();

            //CircularSingleNode tail = null;

            //cll.InsertNode(ref tail, 5, 3);

            //cll.InsertNode(ref tail, 3, 5);

            //cll.InsertNode(ref tail, 5, 7);

            //cll.InsertNode(ref tail, 7, 9);
            //cll.PrintCircluarSingle(ref tail);

            //if (cll.IsCircular(tail))
            //{
            //    Console.WriteLine("Is Circular");
            //}
            //else
            //{
            //    Console.WriteLine("Not Circular");
            //}

            #endregion


            #endregion

            #region Recursion 

            /////int n = 5;
            //int ans = Factorial(n);
            //Console.Write("Factorial of {0}: {1}", n.ToString(), ans.ToString());

            //PrintCount(n);

            //ReachHome(1, 10);

            //int ans = Fibonacci(4);
            //Console.WriteLine("Fibonacci: {0}", ans.ToString());

            //int ans = CountDistinctWays(n);
            //Console.WriteLine("Count Distinct Ways: {0}", ans.ToString());

            //string[] arr = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            //SayDigits(412, arr);

            //int[] arr = { 3, 2, 5, 1, 6 };
            //int size = arr.Length;
            //int ans = SumArray(arr, size);
            //Console.WriteLine("Sum Of Array: {0}", ans.ToString());

            //int[] arr = { 3, 2, 5, 1, 6 };
            //int size = arr.Length;
            //var result = LinearSearch(arr, size, 0);
            //Console.WriteLine("Linear Search Result: {0}", result.ToString());

            //int[] arr = { 2, 4, 6, 10, 14, 18, 22, 38, 49, 55, 222 };
            //int size = arr.Length;
            //Array.Sort(arr);
            //int key = 22;
            //var result = BinarySearch(arr, 0, size, key);
            //Console.WriteLine("Binary Search Result: {0}", result.ToString());

            //string s = "imtiaz";
            //char[] sChar = s.ToCharArray();
            //ReverString(ref sChar, 0, s.Length - 1);
            //PrintCharArray(sChar, 0, sChar.Length);

            //int baseNumber = 3;
            //int power = 11;
            //int ans = PowerOfNumber(baseNumber, power);
            //Console.WriteLine("Power of {0} ^ {1}: {2}", baseNumber.ToString(), power.ToString(), ans.ToString());

            //int[] arr = { 1, 2, 3 };
            //var sub = Subsets(arr);
            //foreach (var item in sub)
            //{
            //    foreach (var val in item)
            //    {
            //        Console.Write(val + " ");
            //        Console.WriteLine("\n");
            //    }
            //}

            #endregion

            #region Revision

            Revision rr = new Revision();

            #region is Sum Tree

            //bool ans = rr.isSumTree(root);
            //Console.WriteLine($"Is Sum Tree: {ans}");

            #endregion

            #region Zig Zag Traversal

            //List<int>ans = rr.ZigZagTraversal(root);
            ////Console.WriteLine($"Is Sum Tree: {ans}");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Boundary Traversal

            //Console.WriteLine("\n");
            //List<int> ans = rr.boundary(root);
            //Console.Write($"Boundary Traversal-> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Vertical order Traversal

            //Console.WriteLine("\n");
            //IList<IList<int>> ans = rr.VerticalTraversal(root);
            //Console.Write($"Boundary Traversal-> ");
            //foreach (var item in ans)
            //{
            //    for (int i = 0; i < item.Count(); i++)
            //    {
            //        Console.Write(item[i] + " ");
            //    }
            //}

            #endregion

            #region Top View

            //Console.WriteLine("\n");
            //List<int> ans = rr.topView(root);
            //Console.Write($"Top View-> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Bottom View

            //Console.WriteLine("\n");
            //List<int> ans = rr.bottomView(root);
            //Console.Write($"Bottom View-> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Left View

            //Console.WriteLine("\n");
            ////List<int> ans = rr.LeftView(root);
            //List<int> ans = rr.LeftViewRecursion(root);
            //Console.Write($"Left View-> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Diagonal Traversal

            //Console.WriteLine("\n");
            //List<int> ans = rr.diagonal(root);
            //Console.Write($"Diagonal Traversal-> ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Longest Path and Sum of BT

            //Console.WriteLine("\n");
            //int sumMax = 0;
            //IList<IList<int>> ans = rr.sumOfLongRootToLeafPath(root, ref sumMax);
            //Console.WriteLine($"Longest Path Sum: {sumMax}");
            //Console.Write($"Longest Path-> ");
            //foreach (var item in ans)
            //{
            //    for (int i = 0; i < item.Count(); i++)
            //    {
            //        Console.Write(item[i] + " ");
            //    }
            //}

            #endregion

            #region Kth-Ancestor of Node

            //Console.WriteLine("\n");
            //int node = 4;
            //int k = 2;
            //int ans = rr.kthAncestor(root, k, node);
            //Console.Write($"K-th Ancestor of Node {node}-> {ans}");

            #endregion

            #region Maximum Sum of Non-Adjacent Nodes

            //Console.WriteLine("\n");
            //int ans = rr.getMaxSum(root);
            //Console.Write($"Maximum Sum of Non-Adjacent Nodes-> {ans}");

            #endregion

            #region Construct tree using Inorder and PreOrder

            //Test Case-1
            //int[] inorder = { 3, 1, 4, 0, 5, 2 };
            //int[] preorder = { 0, 1, 3, 4, 2, 5 };

            //Test Case-2
            //int[] inorder = { 1, 6, 8, 7 };
            //int[] preorder = { 1, 6, 7, 8 };

            //Test Case-3
            //int[] inorder = { 9, 3, 15, 20, 7 };
            //int[] preorder = { 3, 9, 20, 15, 7 };

            //Node tree = rr.BuildTreeUsingInorderPreorder(preorder, inorder);
            //Console.Write($"Tree using Inorder and Preorder:-> ");
            //bt.LevelOrderTraversal(tree);

            #endregion

            #region Construct tree using Inorder and Post-Order

            //Test Case-1
            //int[] inorder = { 3, 1, 4, 0, 5, 2 };
            //int[] postorder = { 0, 1, 3, 4, 2, 5 };

            //Test Case-2
            //int[] inorder = { 1, 6, 8, 7 };
            //int[] postorder = { 1, 6, 7, 8 };

            //Test Case-3
            //int[] inorder = { 9, 3, 15, 20, 7 };
            //int[] postorder = { 9, 15, 7, 20, 3 };

            //Node tree = rr.BuildTreeUsingInorderPostOrder(postorder, inorder);
            //Console.Write($"Tree using Inorder and Postorder:-> ");
            //bt.LevelOrderTraversal(tree);

            #endregion

            #region Morris Traversal/Flatten Tree into LL

            //rr.Flatten(root);

            #endregion

            #region Find Pred/Succ in BST

            //int key = 5;
            //rr.findPreSuc(root, key);

            #endregion

            #region Flatten BST to Sorted List

            //Console.WriteLine("\n");

            //Node ans = rr.flattenBST(root);
            //Console.WriteLine("Flatten BST into LL");
            //bt.LevelOrderTraversal(ans);

            #endregion

            #region Balance a BST

            //Console.WriteLine("\n");

            //Node ans = rr.BalanceBST(root);
            //Console.WriteLine("Balance a BST");
            //bt.LevelOrderTraversal(ans);

            #endregion

            #region Largest BST

            //Console.WriteLine("\n");

            //int ans = rr.largestBst(root);
            //Console.WriteLine($"Largest BST is of size {ans}");

            #endregion

            #region Path Sum

            //int target = 8;
            //rr.PathSum(root, target);

            #endregion

            #endregion

            #region Stack 

            //Constructor for Custom Stack implementation
            StackImplementation st = new StackImplementation(5);

            StackImplementation si = new StackImplementation();

            #region Custom Stack Implementation

            //st.Push(10);
            //st.Push(20);
            //st.Push(30);
            //st.Push(40);
            //st.Push(50);


            //bool ans = st.isEmpty();

            #endregion

            #region Reverse String

            //string str = "imtiaz";
            //si.ReverseString(str);

            #endregion

            #region Delete Mid in Stack

            ////int[] stack = { 10, 20, 30, 40, 50 };
            //int[] stack = { 10, 20, 40, 50 };
            //si.DeleteMidInStack(ref stack);
            //foreach (var item in stack)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Valid Parenthesis

            //string s = "()[]{}";
            //si.IsValid(s);

            #endregion

            #region Insert at Bottom of Stack

            //Stack<int> sNode = new Stack<int>();
            //int[] stArr = { 7, 1, 4, 5 };

            //for (int i = 0; i < stArr.Length; i++)
            //    sNode.Push(stArr[i]);

            //si.InsertAtBottom(ref sNode, 15);
            //Console.WriteLine("Insert at Bottom of Stack: ");
            //while (sNode.Any())
            //{
            //    int top = sNode.Pop();
            //    Console.Write(top + " ");
            //}


            #endregion

            #region Reverse a Stack using Recursion

            //Stack<int> sNode = new Stack<int>();
            //int[] stArr = { 3, 4, 7, 9};

            //for (int i = 0; i < stArr.Length; i++)
            //    sNode.Push(stArr[i]);

            //si.ReverseStackUsingRecursion(sNode);

            #endregion

            #region Sort A Stack

            //Stack<int> sNode = new Stack<int>();
            //int[] stArr = { 5, -2, 9, -7, 3};

            //for (int i = 0; i < stArr.Length; i++)
            //    sNode.Push(stArr[i]);

            //si.SortAStack(sNode);

            #endregion

            #region Check Redundant Bracket

            //string s = "((a+b))";
            ////string s = "(a+b+(c+d))";
            //bool ans = si.checkRedundancy(s);

            //Console.WriteLine($"Is Redundant Bracket Present: {ans}");

            #endregion

            #region Next Larger Element

            //int n = 4;
            //long[] arr = { 1, 3, 2, 4 };
            //var ans = si.nextLargerElement(arr, n);

            //Console.WriteLine("Next Largest Element");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Final Prices Element

            //int[] prices = {8, 4, 6, 2, 3};
            //var ans = si.FinalPrices(prices);

            //Console.WriteLine("Next Smallest Element");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Next Smaller Element

            //int[] arr = { 4, 2, 1, 5, 3 };
            //int n = arr.Length;
            //var ans = si.immediateSmaller(arr, n);

            //Console.Write("Input Elements-> ");
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine();

            //Console.WriteLine("Next Smallest Element");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Celebrity Problem

            //int[,] matrix = { { 0, 0, 1, 0 },
            //               { 0, 0, 1, 0 },
            //               { 0, 0, 0, 0 },
            //               { 0, 0, 1, 0 } };

            //int[,] matrix = { { 0,1,0 },
            //               { 0,0,0 },
            //               { 0,1,0 }};

            //int[,] matrix = { { 0,1 },
            //               { 0,1,} };

            //int ans = si.celebrity(matrix);
            //Console.WriteLine($"Celebrity-> {ans}");

            #endregion

            #endregion

            #region Queue

            QueueImplementation qi = new QueueImplementation();

            #region First negative in every window of size k

            //long n = 5;
            //long[] a = { -8, 2, 3, -6, 10 };
            //long k = 2;

            ////var ans = qi.FirstNegativeInteger(a, n, k);

            //var ans = qi.FirstNegativeIntegerSlidingWindow(a, n, k);

            //Console.Write("First Negative in K window: ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Reverse First K elements of Queue

            //int[] arr = { 1, 2, 3, 4, 5 };
            //int k = 3;
            //Queue<int> q = new Queue<int>();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    q.Enqueue(arr[i]);
            //}

            //qi.modifyQueue(q, k);

            #endregion

            #region First non-repeating character in a stream

            //string A = "aabc";
            //var ans = qi.FirstNonRepeating(A);
            //Console.WriteLine(ans);

            #endregion

            #region Interleave the First Half of the Queue with Second Half

            //int[] arr = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //Queue<int> q = new Queue<int>();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    q.Enqueue(arr[i]);
            //}

            //var ans = qi.RearrangeInterLeaveQueue(q);
            //while (ans.Any())
            //{
            //    int item = ans.Dequeue();
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Sum of minimum and maximum elements of all subarrays of size k

            //int[] arr = { 2, 5, -1, 7, -3, -1, -2 };
            //int n = arr.Length;
            //int k = 4;
            //var ans = qi.SumOfKsubArray(arr, n, k);

            //Console.WriteLine($"Sum of Min and Max of Subarrays of size K-> {ans}");

            #endregion

            #region K Sized Subarray Maximum

            //int k = 3;
            //int[] arr = { 1, 2, 3, 1, 4, 5, 2, 3, 6 };
            //int n = arr.Length;

            //var ans = qi.MaxofSubarrays(arr, n, k);
            //Console.Write($"K Sized Subarray Maximum:");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #endregion

            #region Heaps Revision

            HeapRevision hr = new HeapRevision();

            #region Insert and Delete

            //hr.Insert(50);
            //hr.Insert(55);
            //hr.Insert(53);
            //hr.Insert(52);
            //hr.Insert(54);

            //hr.Print();
            //hr.Delete();

            //hr.Print(); 

            #endregion

            #region Build Max heap

            //int[] arr = { -1, 54, 53, 55, 52, 50 };
            //int n = arr.Length;
            //for (int i = n / 2 - 1; i > 0; i--)
            //{
            //    hr.HeapifyMax(arr, n, i);
            //}

            //Console.WriteLine("Print Heapify");

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine(); 

            #endregion

            #region Build Min heap- Zero

            //int[] arr = { 54, 53, 55, 52, 50 };
            //int n = arr.Length;

            //for (int i = n / 2; i >= 0; i--)
            //{
            //    hr.HeapifyMinZero(arr, n, i);
            //}

            //Console.WriteLine("Print Heapify");

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();

            #endregion

            #region Heap Sort

            //int[] arr = { -1, 54, 53, 55, 52, 50 };
            //int n = arr.Length - 1;
            //for (int i = n / 2; i > 0; i--)
            //{
            //    hr.HeapifyMax(arr, n, i);
            //}

            //Console.WriteLine("Print Heapify");

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine("Heap Sort");
            //hr.HeapSort(arr, n);
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}

            #endregion

            #region kth Smallest Element

            //int[] arr = { 7, 3, 8, 2, 6, 5,1, 4 };
            //int[] arr = { 1, 3, 2, 4 };
            //int k = 4;
            //int l = 0;
            //int r = arr.Length - 1;

            //int ans = hr.kthSmallest(arr, l, r, k);
            //Console.Write($"kth Smallest Element-> {ans}");

            #endregion

            #region Kth Largest Element

            //int[] arr = { 3, 2, 1, 5, 6, 4 };
            //int k = 2;

            //int ans = hr.FindKthLargest(arr, k);
            //Console.Write($"kth Largest Element-> {ans}");

            #endregion

            #region Check if a given Binary Tree is a Heap

            //bool ans = hr.isHeap(root);
            //Console.WriteLine($"Is Binary Tree Heap-> {ans}");

            #endregion

            #region Merge two binary max heap

            //int[] a = { 10, 5, 6, 2 };
            //int[] b = { 12, 7, 9 };

            //var ans = hr.MergeHeaps(a, b);

            //Console.WriteLine("Merge two binary max heap");
            //for (int i = 0; i < ans.Length; i++)
            //{
            //    Console.Write(ans[i] + " ");
            //}
            //Console.WriteLine();

            #endregion

            #region Minimum Cost of ropes

            //int[] arr = { 4, 3, 2, 6 };
            //int[] arr = { 4, 2, 7, 6, 9 };
            //int ans = hr.MinimumCostOfRopes(arr);
            //Console.WriteLine($"Minimum Cost of ropes-> {ans}");

            #endregion

            #region Convert BST to Min Heap

            //Node ans = hr.ConvertBSTToMinHeapUtil(root);
            //Console.WriteLine();
            //bt.LevelOrderTraversal(ans);

            #endregion

            #region Convert BST to Max Heap

            //Node ans = hr.ConvertBSTToMaxHeapUtil(root);
            //Console.WriteLine();
            //bt.LevelOrderTraversal(ans);

            #endregion

            #region K-th Largest Sum Contiguous Subarray

            //int[] a = { 20, -5, -1 };
            //int k = 3;

            //int[] a = { 2, 6, 4, 1 };
            //int k = 3;

            //int[] a = { 10, -10, 20, -40 };
            //int k = 6;

            //int ans = hr.kthLargestSumSubarrray(a, k);
            //Console.WriteLine($"K-th Largest Sum Contiguous Subarray-> {ans}");

            #endregion

            #region Maximum Contigous Subarray

            //int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //var ans = hr.MaxSubArray(nums);
            //Console.WriteLine($"Maximum Contigous Subarray-> {ans}");

            #endregion

            #region Merge K-Sorted Arrays

            //int k = 3;
            //int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //4
            //1 2 3 4 0 5 10 15 2 4 8 10 3 9 27 81


            //int k = 4;
            //int[,] arr = { { 1, 2, 3, 4 }, { 0, 5, 10, 15 }, { 2, 4, 8, 10 }, { 3, 9, 27, 81 } };

            //int k = 3;
            //int[,] arr = { { 5, 9, 44 }, { 51, 65, 88 }, { 2, 79, 89 } };

            //int k = 2;
            //int[,] arr = { { 51, 81 }, { 63, 71 } };


            //var ans = hr.MergeKSortedArrays(arr, k);
            //Console.WriteLine($"MergeKSortedArrays->");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Smallest Range

            //int[][] nums =  new int[][] { new int[]{ 4, 10, 15, 24, 26 }, new int[] { 0, 9, 12, 20 }, new int[] { 5, 18, 22, 30 } };
            //int[] ans = hr.SmallestRange(nums);

            //Console.WriteLine($"Smallest Range->");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Smallest Range- Using MinHeap Custom Class

            //int[][] nums = new int[][] { new int[] { 4, 10, 15, 24, 26 }, new int[] { 0, 9, 12, 20 }, new int[] { 5, 18, 22, 30 } };
            //int[] ans = hr.SmallestRangeUsingMinHeap(nums);

            //Console.WriteLine($"Smallest Range Custom Class->");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #endregion

            #region test Array of List

            //List<int>[] adj = new List<int>[3];

            //for (int i = 0; i < adj.Length; i++)
            //{
            //    adj[i] = new List<int>();
            //}


            //adj[0].Add(0);
            //adj[0].Add(1);

            //adj[2].Add(0);
            //adj[2].Add(1);

            //for (int i = 0; i < adj.Length; i++)
            //{
            //    List<int> item = adj[i];
            //}


            #endregion

            #region Revision Graphs

            #region Shortest path for Undirected, non-weighted Graph

            //int vertex = 10;
            //int[,] edges = { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 5 }, { 3, 8 }, { 4, 6 }, { 5, 8 }, { 6, 7 }, { 7, 8 }, { 8, 0 } };
            //int source = 1;
            //int destination = 8;
            //ShortestPathInGraphRevision spg = new ShortestPathInGraphRevision();
            //spg.ShortestPathForUndirectedGraph(edges, source, destination, vertex);

            #endregion

            #region Shortest Path for Directed, Weighted Graph

            //int source = 1;
            //ShortestPathInGraphRevision spg = new ShortestPathInGraphRevision();
            //spg.ShortestDistanceForWeightedGraph(source);

            #endregion

            #region Shortest Path using Dijkstra's Algo

            //int source = 0;
            //ShortestPathInGraphRevision spg = new ShortestPathInGraphRevision();
            //spg.ShortestPathUsingDijkstra(source);

            #endregion

            #region Minimum Spanning tree using Prim's Algo

            //int source = 0;
            //MinimumSpanningTreeRevision mst = new MinimumSpanningTreeRevision();
            //mst.MinimumSpanningTreeUsingPrims(source);

            #endregion

            #region Minimum Spanning Tree using Kruskal's Algo

            //MinimumSpanningTreeRevision mst = new MinimumSpanningTreeRevision();
            //mst.MinimumSpannigTreeUsingKruskal();

            #endregion

            #region Bridges in Graph

            //int[,] edges = { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 3, 4 }, { 4, 3 } };
            //int vertex = 5;
            //BridgesRevision bd = new BridgesRevision();
            //bd.BridgeInGraph(edges, vertex);

            #endregion

            #region Articulation Point

            //int[,] edges = { { 0, 1 }, { 0, 3 }, { 0, 4 }, { 1, 2 }, { 3, 4 } };
            //int[,] edges = { { 0, 1 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 3, 4 } };
            //int vertex = 5;
            //ArticulationPointRevision ap = new ArticulationPointRevision();
            //ap.FindArticulationPoint(edges, vertex);

            #endregion

            #region Strongly Connected Components- Kosaraju's Algo

            //int[,] edges = { { 0, 1 }, { 1, 2 }, { 1, 3 }, { 2, 0 }, { 3, 4 } };
            //int[,] edges = { { 0, 3 }, { 0, 2 }, { 1, 0 }, { 2, 1 }, { 3, 4 } };
            //int vertex = 5;
            //StronglyConnectedComponentsRevision scc = new StronglyConnectedComponentsRevision();
            //scc.SCCUsingKosaraju(edges, vertex);

            #endregion

            #endregion

            #region Dynamic Programming

            DynamicProgramming dp = new DynamicProgramming();

            #region Min Cost of Climbing Stairs

            //int[] cost = { 10, 15, 20 };
            //int ans = dp.MinCostClimbingStairs(cost);
            //Console.WriteLine($"Minimum Cost of Climbing Stairs: {ans}");

            #endregion

            #region Min Number of coins

            //int[] cost = { 1, 2, 5 };
            //int amount = 11;
            //int ans = dp.CoinChange(cost, amount);
            //Console.WriteLine($"Minimum Number of Coins: {ans}");

            #endregion

            #region Non-Adjacent Elements

            //int[] cost = { 1, 3, 1 };
            //int ans = dp.Rob(cost);
            //Console.WriteLine($"Non-Adjacent: {ans}");

            #endregion

            #region Derangement

            //int n = 5;
            //long ans = dp.CountDerangements(n);
            //Console.WriteLine($"Derangement of array: {ans}");

            #endregion

            #region Knapsack

            //int N = 58;
            //int W = 41;
            //int[] values = { 57, 95, 13, 29, 1, 99, 34, 77, 61, 23, 24, 70, 73, 88, 33, 61, 43, 5, 41, 63, 8, 67, 20, 72, 98, 59, 46, 58, 64, 94, 97, 70, 46, 81, 42, 7, 1, 52, 20, 54, 81, 3, 73, 78, 81, 11, 41, 45, 18, 94, 24, 82, 9, 19, 59, 48, 2, 72 };
            //int[] weight = { 83, 84, 85, 76, 13, 87, 2, 23, 33, 82, 79, 100, 88, 85, 91, 78, 83, 44, 4, 50, 11, 68, 90, 88, 73, 83, 46, 16, 7, 35, 76, 31, 40, 49, 65, 2, 18, 47, 55, 38, 75, 58, 86, 77, 96, 94, 82, 92, 10, 86, 54, 49, 65, 44, 77, 22, 81, 52 };

            //var ans = dp.knapSack(W, weight, values, N);
            //Console.WriteLine($"KnapSack {ans}");



            #endregion

            #region Catalan Number

            //int n = 5;
            //int ans = dp.NumberOfWaysCatalan(n);
            //Console.WriteLine($"Number of ways-> {ans}");

            #endregion

            #region LIS

            //int[] nums = { 5, 8, 3, 7, 9, 1 };
            //dp.LengthOfLIS(nums);

            #endregion

            #region Russian Doll

            dp.MaxEnvelopes();

            #endregion

            #region Dice Roll

            //int n = 2;
            //int k = 6;
            //int target = 7;

            //int ans = dp.NumRollsToTarget(n, k, target);
            //Console.WriteLine($"Number of Ways to make {target}-> {ans}");

            #endregion

            #region Longest Arithmetic Progression

            //int[] nums = { 3, 6, 9, 12 };
            //int ans = dp.LongestArithSeqLength(nums);

            //Console.WriteLine($"Longest Arithmetic Progression-> {ans}");


            #endregion

            #region Longest Arithmetic Subsequence of Given Difference

            //int[] nums = { 1, 5, 7, 8, 5, 3, 4, 2, 1 };
            //int diff = -2;
            //int ans = dp.LongestSubsequence(nums, diff);

            //Console.WriteLine($"Longest Subsequence with Given Diff-> {ans}");

            #endregion

            #region Find all Subsequence

            //string output = "";
            //string input = "abcd";

            //dp.printSubsequence(input, output);

            #endregion

            #endregion

            #region Greedy Algorithm

            GreedyAlgorithm ga = new GreedyAlgorithm();

            #region N-Meeting

            //int[] start = { 75250, 50074, 43659, 8931, 11273, 27545, 50879, 77924 };
            //int[] end = { 112960, 114515, 81825, 93424, 54316, 35533, 73383, 160252 };
            //int n = start.Length;

            //int ans = ga.N_maxMeetings(n, start, end);

            //Console.WriteLine($"N-Meeting: {ans}");

            #endregion

            #region Maximum Meetings in One Room

            //int[] start = { 1, 3, 0, 5, 8, 5 };
            //int[] end = { 2, 4, 6, 7, 9, 9 };
            //int n = start.Length;

            //var ans = ga.maxMeetings(n, start, end);

            //Console.WriteLine("Maximum Meetings in One Room: ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Shop in Candy Store

            //int N = 4;
            //int K = 2;
            //int[] candies = { 3, 2, 1, 4 };

            //var ans = ga.candyStore(candies, N, K);

            //Console.WriteLine("Shop in Candy Store: ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Check if it is possible to survive on Island

            //int s = 10;
            //int n = 9;
            //int m = 8;

            ////int s = 5;
            ////int n = 2;
            ////int m = 2;
            //int ans = ga.minimumDays(s, n, m);
            //Console.WriteLine($"Minimum Days to survive: {ans}");

            #endregion

            #region Chocolate Distribution Problem

            //int N = 8, M = 5;
            //List<long> A = new List<long> { 3, 4, 1, 9, 56, 7, 9, 12 };
            //var ans = ga.findMinDiff(A, N, M);
            //Console.WriteLine($"Chocolate Distribution Problem: {ans}");


            #endregion

            #region Huffamn Encoding

            //string S = "abcdef";
            //int[] f = { 5, 9, 12, 13, 16, 45 };
            //int N = f.Length;
            //var ans = ga.huffmanCodes(S, f, N);
            //Console.WriteLine("Huffman Encoding: ");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #region Fractional Knapsack

            //int n = 3;
            //int w = 50;
            //int[] value = { 60, 100, 120 };
            //int[] weight = { 10, 20, 30 };
            //Item[] item = new Item[n];
            //ga.AddItem(ref item, value, weight);

            //var ans = ga.fractionalKnapsack(w, item, n);
            //Console.WriteLine($"Fractional Knapsack: {ans}");


            #endregion

            #region Job Sequencing

            //int[] jobID = { 1, 2, 3, 4 };
            //int[] deadline = { 4, 1, 1, 1 };
            //int[] profit = { 20, 1, 40, 30 };
            //int n = jobID.Length;
            //Job[] job = new Job[n];
            //ga.FillJob(ref job, jobID, deadline, profit);
            //var ans = ga.JobScheduling(job, n);

            //int count = 0;
            //Console.WriteLine("Job Sequencing: ");
            //foreach (var item in ans)
            //{
            //    if (count == 0)
            //    {
            //        Console.WriteLine($"Max Job: {item}");
            //        count++;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Max Profit: {item}");
            //    }
            //}


            #endregion

            #endregion

            #region Backtracking

            BacktrackingAlgo backtrack = new BacktrackingAlgo();

            #region Rat In Maze Problem

            //int[,] mat = { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 1, 1 } };
            //var ans = backtrack.FindRatPath(mat);
            //Console.WriteLine("Rat In Maze Problem");
            //foreach (var item in ans)
            //{
            //    Console.Write(item + " ");
            //}

            #endregion

            #endregion

            Console.ReadLine();
        }
    }
}
