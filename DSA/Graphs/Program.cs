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

            //Node root = null;
            //BinaryTreeCreationTopic bt = new BinaryTreeCreationTopic();
            //root = bt.BuildTreeUsingLevelOrder(root);

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

            InsertionSortAlgorithm ins = new InsertionSortAlgorithm();

            //int N = 5;
            //int[] arr = { 10, 1, 7, 4, 8, 2, 11 };
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
            L.head = L.Push(L.head, 17);
            L.head = L.Push(L.head, 9);
            L.head = L.Push(L.head, 3);

            L.head.next = L.Push(L.head.next, 47);
            L.head.next = L.Push(L.head.next, 10);

            L.head.next.next = L.Push(L.head.next.next, 30);
            L.head.next.next = L.Push(L.head.next.next, 15);
            L.head.next.next = L.Push(L.head.next.next, 7);

            L.head.next.next.next
                = L.Push(L.head.next.next.next, 22);
            L.head.next.next.next
                = L.Push(L.head.next.next.next, 14);
           
            // Function call
            L.head = L.FlattenNode(L.head);

            L.printList();

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

            Console.ReadLine();
        }


    }
}
