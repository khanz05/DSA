using Graphs.BinaryTreeTopic;
using Graphs.LinkedListOperations;
using NetTopologySuite.Index.Bintree;
using NetTopologySuite.Operation.Valid;
using NetTopologySuite.Precision;
using NetTopologySuite.Triangulate;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.RevisionProblems
{
    internal class Revision
    {
        #region Sum Tree

        public bool isSumTree(Node root)
        {
            PairBool result = solveIsSum(root);
            return result.first;
        }

        private PairBool solveIsSum(Node root)
        {
            //base cases
            if (root == null)
            {
                PairBool p = new PairBool(true, 0);
                return p;
            }

            if (root.Left == null && root.Right == null)
            {
                PairBool p = new PairBool(true, root.data);
                return p;
            }

            Node temp = root;
            PairBool leftSubSum = solveIsSum(temp.Left);
            PairBool rightSubSum = solveIsSum(temp.Right);

            bool leftAns = leftSubSum.first;
            bool rightAns = rightSubSum.first;
            bool sumRoot = (temp.data == (leftSubSum.second + rightSubSum.second));

            PairBool ans = new PairBool();
            if (leftAns && rightAns && sumRoot)
            {
                ans.first = true;
                ans.second = 2 * root.data;
            }
            else
            {
                ans.first = false;
                ans.second = -1;
            }
            return ans;
        }

        #endregion

        #region Zig Zag Traversal

        public List<int> ZigZagTraversal(Node root)
        {
            List<int> ans = new List<int>();

            //base case
            if (root == null)
            {
                return ans;
            }

            //Condition
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            bool directionLR = true;

            while (q.Count() > 0)
            {
                int size = q.Count();
                //int[] arr = new int[size];
                List<int> values = new List<int>();

                while (size > 0)
                {
                    Node temp = q.Dequeue();
                    if (directionLR)
                    {
                        values.Add(temp.data);
                    }
                    else
                    {
                        values.Insert(0, temp.data);

                    }

                    if (temp.Left != null)
                    {
                        q.Enqueue(temp.Left);
                    }

                    if (temp.Right != null)
                    {
                        q.Enqueue(temp.Right);
                    }
                    size--;
                }

                //Level Process
                //for (int i = 0; i < size; i++)
                //{
                //    Node node = q.Dequeue();

                //    int index = directionLR ? i : size - i - 1;
                //    arr[index] = node.data;

                //    if (node.Left != null)
                //    {
                //        q.Enqueue(node.Left);
                //    }

                //    if (node.Right != null)
                //    {
                //        q.Enqueue(node.Right);
                //    }
                //}

                directionLR = !directionLR;

                foreach (var item in values)
                {
                    ans.Add(item);
                }
            }
            return ans;
        }

        #endregion

        #region Boundary Traversal 

        public List<int> boundary(Node root)
        {
            List<int> ans = new List<int>();
            if (root == null)
            {
                return ans;
            }

            ans.Add(root.data);

            //Traverse Left Subtree
            traverseLeft(root.Left, ref ans);

            //Traverse Leaf Nodes Left/Right separately
            traverseleafNodes(root.Left, ref ans);

            traverseleafNodes(root.Right, ref ans);

            //Traverse Right Subtree
            traverseRight(root.Right, ref ans);

            return ans;
        }

        private void traverseLeft(Node root, ref List<int> ans)
        {
            if (root == null || root.Left == null && root.Right == null)
            {
                return;
            }

            ans.Add(root.data);

            if (root.Left != null)
            {
                traverseLeft(root.Left, ref ans);
            }
            else if (root.Right != null)
            {
                traverseLeft(root.Right, ref ans);
            }
        }

        private void traverseleafNodes(Node root, ref List<int> ans)
        {
            if (root == null)
            {
                return;
            }
            if (root.Left == null && root.Right == null)
            {
                ans.Add(root.data);
                return;
            }

            traverseleafNodes(root.Left, ref ans);
            traverseleafNodes(root.Right, ref ans);
        }

        private void traverseRight(Node root, ref List<int> ans)
        {
            if (root == null || root.Left == null && root.Right == null)
            {
                return;
            }

            if (root.Right != null)
            {
                traverseRight(root.Right, ref ans);
            }
            else if (root.Left != null)
            {
                traverseRight(root.Left, ref ans);
            }

            ans.Add(root.data);
        }



        #endregion

        #region Vertical Traversal

        public IList<IList<int>> VerticalTraversal(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<Pair> qNode = new Queue<Pair>();
            SortedDictionary<int, List<KeyValuePair<int, int>>> levelData = new SortedDictionary<int, List<KeyValuePair<int, int>>>();
            int row = 0;
            int col = 0;
            qNode.Enqueue(new Pair(root, row, col));
            int min = 0, max = 0; //for traversing Dictionary

            while (qNode.Count() > 0)
            {
                Pair temp = qNode.Dequeue();
                Node node = temp.first;
                row = temp.row;
                col = temp.col;
                if (!levelData.ContainsKey(col))
                {
                    levelData[col] = new List<KeyValuePair<int, int>>();
                }
                levelData[col].Add(new KeyValuePair<int, int>(row, node.data));

                if (node.Left != null)
                {
                    qNode.Enqueue(new Pair(node.Left, row + 1, col - 1));
                }

                if (node.Right != null)
                {
                    qNode.Enqueue(new Pair(node.Right, row + 1, col + 1));
                }
            }

            foreach (var entry in levelData)
            {
                entry.Value.Sort((a, b) =>
                {
                    if (a.Key == b.Key)
                    {
                        return a.Value.CompareTo(b.Value);
                    }
                    return a.Key.CompareTo(b.Key);
                });

                IList<int> column = new List<int>();
                foreach (var pair in entry.Value)
                {
                    column.Add(pair.Value);
                }
                result.Add(column);
            }
            return result;
        }

        #endregion

        #region Top View

        public List<int> topView(Node root)
        {
            List<int> result = new List<int>();
            SortedDictionary<int, int> levelData = new SortedDictionary<int, int>();
            int row = 0;
            int col = 0;
            Queue<Pair> qNode = new Queue<Pair>();
            qNode.Enqueue(new Pair(root, row, col));

            while (qNode.Count() > 0)
            {
                Pair temp = qNode.Dequeue();
                Node node = temp.first;
                row = temp.row;
                col = temp.col;

                if (!levelData.ContainsKey(col))
                {
                    levelData.Add(col, node.data);
                }

                if (node.Left != null)
                {
                    qNode.Enqueue(new Pair(node.Left, row, col - 1));
                }

                if (node.Right != null)
                {
                    qNode.Enqueue(new Pair(node.Right, row, col + 1));
                }
            }

            foreach (var item in levelData)
            {
                result.Add(item.Value);
            }
            return result;
        }

        #endregion

        #region Bottom View

        public List<int> bottomView(Node root)
        {
            List<int> result = new List<int>();
            SortedDictionary<int, int> levelData = new SortedDictionary<int, int>();
            int row = 0;
            int col = 0;
            Queue<Pair> qNode = new Queue<Pair>();
            qNode.Enqueue(new Pair(root, row, col));

            while (qNode.Count() > 0)
            {
                Pair temp = qNode.Dequeue();
                Node node = temp.first;
                row = temp.row;
                col = temp.col;

                if (!levelData.ContainsKey(col))
                {
                    levelData.Add(col, node.data);
                }
                else
                {
                    levelData[col] = node.data;
                }

                if (node.Left != null)
                {
                    qNode.Enqueue(new Pair(node.Left, row, col - 1));
                }

                if (node.Right != null)
                {
                    qNode.Enqueue(new Pair(node.Right, row, col + 1));
                }
            }

            foreach (var item in levelData)
            {
                result.Add(item.Value);
            }
            return result;
        }

        #endregion

        #region Left View 

        public List<int> LeftView(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }

            SortedDictionary<int, int> levelData = new SortedDictionary<int, int>();
            Queue<Pair> qNode = new Queue<Pair>();
            int row = 0;
            int col = 0;
            qNode.Enqueue(new Pair(root, row, col));

            while (qNode.Any())
            {
                Pair temp = qNode.Dequeue();
                Node node = temp.first;
                row = temp.row;
                col = temp.col;

                if (!levelData.ContainsKey(col))
                {
                    levelData.Add(col, node.data);
                }

                if (node.Left != null)
                {
                    qNode.Enqueue(new Pair(node.Left, row + 1, col + 1));
                }

                if (node.Right != null)
                {
                    qNode.Enqueue(new Pair(node.Right, row + 1, col + 1));
                }
            }

            foreach (var item in levelData)
            {
                result.Add(item.Value);
            }
            return result;
        }

        public List<int> LeftViewRecursion(Node root)
        {
            List<int> result = new List<int>();
            int level = 0;
            if (root == null)
            {
                return result;
            }
            solveLeftViewRecursion(root, ref result, level);

            return result;
        }

        private void solveLeftViewRecursion(Node root, ref List<int> result, int level)
        {
            if (root == null)
            {
                return;
            }

            if (level == result.Count())
            {
                result.Add(root.data);
            }

            solveLeftViewRecursion(root.Left, ref result, level + 1);
            solveLeftViewRecursion(root.Right, ref result, level + 1);


        }

        #endregion

        #region Diagonal Traversal

        public List<int> diagonal(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            int row = 0;
            int col = 0;
            Dictionary<int, List<int>> levelData = new Dictionary<int, List<int>>();

            Queue<Pair> qNode = new Queue<Pair>();
            qNode.Enqueue(new Pair(root, row, col));
            int min = 0, max = 0;

            while (qNode.Any())
            {
                Pair temp = qNode.Dequeue();
                Node node = temp.first;
                row = temp.row;
                col = temp.col;
                if (!levelData.ContainsKey(col))
                {
                    levelData.Add(col, new List<int>());
                }
                levelData[col].Add(node.data);

                if (node.Left != null)
                {
                    qNode.Enqueue(new Pair(node.Left, row + 1, col - 1));
                }

                if (node.Right != null)
                {
                    qNode.Enqueue(new Pair(node.Right, row + 1, col));
                }

                if (min > col)
                {
                    min = col;
                }

                if (max < col)
                {
                    max = col;
                }
            }

            for (int i = max; i >= min; i--)
            {
                List<int> item = levelData[i];
                foreach (var val in item)
                {
                    result.Add(val);
                }
            }

            return result;
        }


        #endregion

        #region Longest Path and Sum of BT

        public IList<IList<int>> sumOfLongRootToLeafPath(Node root, ref int sumMax)
        {
            if (root == null)
                return null;
            IList<IList<int>> path = new List<IList<int>>();
            int sum = 0, len = 0, lenMax = 0;
            List<int> list = new List<int>();
            GetSumPath(root, ref sumMax, ref lenMax, sum, len, ref path, ref list);

            return path;
        }

        private void GetSumPath(Node root, ref int sumMax, ref int lenMax, int sum, int len, ref IList<IList<int>> path, ref List<int> list)
        {
            //base case
            if (root == null)
            {
                if (lenMax < len)
                {
                    lenMax = len;
                    sumMax = sum;
                    if (path.Count() == 0)
                    {
                        path.Add(new List<int>(list));
                    }
                    else
                    {
                        path.RemoveAt(0);
                        path.Add(new List<int>(list));
                    }

                }
                else if (lenMax == len)
                {
                    if (sum > sumMax)
                    {
                        if (path.Count() == 0)
                        {
                            path.Add(new List<int>(list));
                        }
                        else
                        {
                            path.RemoveAt(0);
                            path.Add(new List<int>(list));
                        }
                    }
                    sumMax = Math.Max(sumMax, sum);
                }
                return;
            }

            list.Add(root.data);

            sum = sum + root.data;

            GetSumPath(root.Left, ref sumMax, ref lenMax, sum, len + 1, ref path, ref list);
            GetSumPath(root.Right, ref sumMax, ref lenMax, sum, len + 1, ref path, ref list);

            list.RemoveAt(list.Count() - 1);
        }

        #endregion

        #region Kth-Ancestor of Node

        public int kthAncestor(Node root, int k, int node)
        {
            if (root == null)
                return 0;

            Node result = solveKthAncestor(root, ref k, node);
            return result.data;
        }

        private Node solveKthAncestor(Node root, ref int k, int node)
        {
            if (root == null)
            {
                return null;
            }

            if (root.data == node)
            {
                return root;
            }

            Node leftAns = solveKthAncestor(root.Left, ref k, node);
            Node rightAns = solveKthAncestor(root.Right, ref k, node);

            if (leftAns != null && rightAns == null)
            {
                k--;
                if (k <= 0)
                {
                    k = int.MaxValue; //locking
                    return root;
                }
                return leftAns;
            }

            if (rightAns != null && leftAns == null)
            {
                k--;
                if (k <= 0)
                {
                    k = int.MaxValue; //locking
                    return root;
                }
                return rightAns;
            }

            return null;
        }


        #endregion

        #region Maximum Sum of Non-Adjacent Nodes

        public int getMaxSum(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            PairTwoNum ans = solveMaxSum(root);
            return Math.Max(ans.first, ans.second);
        }

        private PairTwoNum solveMaxSum(Node root)
        {
            if (root == null)
            {
                PairTwoNum p = new PairTwoNum(0, 0);
                return p;
            }

            PairTwoNum leftAns = solveMaxSum(root.Left);
            PairTwoNum rightAns = solveMaxSum(root.Right);

            PairTwoNum result = new PairTwoNum(0, 0);

            result.first = root.data + leftAns.second + rightAns.second;
            result.second = Math.Max(leftAns.first, leftAns.second) + Math.Max(rightAns.first, rightAns.second);

            return result;
        }


        #endregion

        #region Build Tree Using Inorder and Pre-Order

        public Node BuildTreeUsingInorderPreorder(int[] preorder, int[] inorder)
        {
            int preOrderIndex = 0;
            Dictionary<int, int> nodeToIndex = new Dictionary<int, int>();
            CreateMapping(inorder, nodeToIndex);
            int size = preorder.Length;
            Node tree = ConstructTreeUsingInorderPreorder(preorder, inorder, ref preOrderIndex, 0, size - 1, size, nodeToIndex);

            return tree;
        }

        private Node ConstructTreeUsingInorderPreorder(int[] preorder, int[] inorder, ref int preIndex, int inStart, int inEnd, int size, Dictionary<int, int> nodeToIndex)
        {
            //base condition
            if (inStart > inEnd || preIndex >= size)
            {
                return null;
            }

            int element = preorder[preIndex];
            preIndex++;

            Node root = new Node(element);
            int position = nodeToIndex[element];

            root.Left = ConstructTreeUsingInorderPreorder(preorder, inorder, ref preIndex, inStart, position - 1, size, nodeToIndex);
            root.Right = ConstructTreeUsingInorderPreorder(preorder, inorder, ref preIndex, position + 1, inEnd, size, nodeToIndex);

            return root;

        }

        #endregion

        #region Build Tree Using Inorder and Post-Order

        public Node BuildTreeUsingInorderPostOrder(int[] postOrder, int[] inorder)
        {
            int postOrderIndex = postOrder.Length - 1;
            Dictionary<int, int> nodeToIndex = new Dictionary<int, int>();
            CreateMapping(inorder, nodeToIndex);
            int size = postOrder.Length;

            Node tree = ConstructTreeUsingInorderPostOrder(postOrder, inorder, ref postOrderIndex, 0, size - 1, size, nodeToIndex);
            return tree;
        }

        private Node ConstructTreeUsingInorderPostOrder(int[] postorder, int[] inorder, ref int postIndex, int inStart, int inEnd, int size, Dictionary<int, int> nodeToIndex)
        {
            //base case
            if (inStart > inEnd || postIndex < 0)
            {
                return null;
            }

            int element = postorder[postIndex];
            postIndex--;

            Node root = new Node(element);
            int position = nodeToIndex[element];

            root.Right = ConstructTreeUsingInorderPostOrder(postorder, inorder, ref postIndex, position + 1, inEnd, size, nodeToIndex);
            root.Left = ConstructTreeUsingInorderPostOrder(postorder, inorder, ref postIndex, inStart, position - 1, size, nodeToIndex);

            return root;
        }


        #endregion

        #region Flatten a Tree into LL

        public void Flatten(Node root)
        {
            Node current = root;
            while (current != null)
            {
                if (current.Left != null)
                {
                    Node pred = current.Left;
                    while (pred.Right != null)
                    {
                        pred = pred.Right;
                    }

                    pred.Right = current.Right;
                    current.Right = current.Left;
                    current.Left = null;
                }
                else
                {
                    current = current.Right;
                }
            }
        }


        #endregion

        #region Find Pred/Successor

        public void findPreSuc(Node root, int key)
        {
            Node temp = root;
            int pred = -1;
            int succ = -1;

            while (temp.data != key)
            {
                if (temp.data > key)
                {
                    succ = temp.data;
                    temp = temp.Left;
                }
                else if (temp.data < key)
                {
                    pred = temp.data;
                    temp = temp.Right;
                }
            }

            Node leftAns = temp.Left;
            while (leftAns != null)
            {
                pred = leftAns.data;
                leftAns = leftAns.Right;
            }

            Node rightAns = temp.Right;
            while (rightAns != null)
            {
                succ = rightAns.data;
                rightAns = rightAns.Left;
            }

            Console.WriteLine();
            Console.WriteLine($"Predecessor and  Successor of {key}");
            Console.Write($"Predecessor {pred} and Successor {succ}");
        }

        #endregion

        #region Flatten BST to Sorted LL

        public Node flattenBST(Node root)
        {
            List<int> inorder = new List<int>();
            CreateInOrder(root, ref inorder);
            int size = inorder.Count();

            Node newRoot = new Node(inorder[0]);
            Node current = newRoot;
            for (int i = 1; i < size; i++)
            {
                Node temp = new Node(inorder[i]);
                current.Left = null;
                current.Right = temp;
                current = temp;
            }

            current.Left = null;
            current.Right = null;
            return newRoot;
        }

        #endregion

        #region Balance a BST
        public Node BalanceBST(Node root)
        {
            List<int> inorder = new List<int>();
            CreateInOrder(root, ref inorder);

            return solveBalanceBST(0, inorder.Count() - 1, inorder);
        }

        private Node solveBalanceBST(int start, int end, List<int> inorder)
        {
            if (start > end)
            {
                return null;
            }

            int mid = start + (end - start) / 2;
            Node root = new Node(inorder[mid]);
            root.Left = solveBalanceBST(start, mid - 1, inorder);
            root.Right = solveBalanceBST(mid + 1, end, inorder);

            return root;
        }


        #endregion

        #region Largest BST

        public int largestBst(Node root)
        {
            int maxSize = 0;
            Info result = solveLargestBST(root, ref maxSize);
            return maxSize;
        }

        private Info solveLargestBST(Node root, ref int ans)
        {
            if (root == null)
            {
                return new Info(int.MinValue, int.MaxValue, true, 0);
            }

            Info leftAns = solveLargestBST(root.Left, ref ans);
            Info rightAns = solveLargestBST(root.Right, ref ans);

            Info currentNode = new Info();

            currentNode.size = leftAns.size + rightAns.size + 1;
            currentNode.maxi = Math.Max(root.data, rightAns.maxi);
            currentNode.mini = Math.Min(root.data, leftAns.mini);

            if (leftAns.isBST && rightAns.isBST && (root.data < rightAns.mini && root.data > leftAns.maxi))
            {
                currentNode.isBST = true;
            }
            else
            {
                currentNode.isBST = false;
            }

            //Largest BST
            if (currentNode.isBST)
            {
                ans = Math.Max(ans, currentNode.size);
            }

            return currentNode;
        }

        #endregion

        #region Helper Methods

        private void CreateMapping(int[] inorder, Dictionary<int, int> nodeToIndex)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                nodeToIndex.Add(inorder[i], i);
            }
        }

        private void CreateInOrder(Node root, ref List<int> inorder)
        {
            if (root == null)
            {
                return;
            }

            CreateInOrder(root.Left, ref inorder);
            if (root.data != -1)
            {
                inorder.Add(root.data);
            }
            CreateInOrder(root.Right, ref inorder);
        }

        #endregion

        #region Helper Class

        public class Info
        {
            public int maxi;
            public int mini;
            public bool isBST;
            public int size;

            public Info(int maxi, int mini, bool isBST, int size)
            {
                this.maxi = maxi;
                this.mini = mini;
                this.isBST = isBST;
                this.size = size;
            }

            public Info()
            {
                
            }
        }

        public class PairBool
        {
            public bool first;
            public int second;
            public PairBool(bool first, int second)
            {
                this.first = first;
                this.second = second;
            }
            public PairBool()
            {

            }
        }

        public class Pair
        {
            public Node first;
            public int row;
            public int col;
            public Pair(Node first, int row, int col)
            {
                this.first = first;
                this.row = row;
                this.col = col;
            }
        }

        public class PairTwoNum
        {
            public int first;
            public int second;

            public PairTwoNum(int first, int second)
            {
                this.first = first;
                this.second = second;
            }
        }

        #endregion
    }
}
