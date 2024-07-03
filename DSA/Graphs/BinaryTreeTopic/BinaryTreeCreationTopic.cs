using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Graphs.BinaryTreeTopic
{
    internal class BinaryTreeCreationTopic
    {
        public Node BuildTree(Node root)
        {
            Console.WriteLine("Enter Data");
            int data = Convert.ToInt16(Console.ReadLine());
            root = new Node(data);

            if (data == -1)
            {
                return null;
            }

            Console.WriteLine("Enter Data to Left of {0}", data);
            root.Left = BuildTree(root.Left);

            Console.WriteLine("Enter Data to Right of {0}", data);
            root.Right = BuildTree(root.Right);
            return root;
        }

        #region Build Tree Using Level Order

        public Node BuildTreeUsingLevelOrder(Node root)
        {
            Queue<Node> qNode = new Queue<Node>();
            Console.WriteLine("Enter Data");
            int data = Convert.ToInt16(Console.ReadLine());
            root = new Node(data);
            qNode.Enqueue(root);

            while (qNode.Count() > 0)
            {
                Node temp = qNode.Dequeue();

                Console.WriteLine("Enter Data for Left {0}", temp.data);
                int left = Convert.ToInt16(Console.ReadLine());
                if (left != -1)
                {
                    temp.Left = new Node(left);
                    qNode.Enqueue(temp.Left);
                }

                Console.WriteLine("Enter Data for Right {0}", temp.data);
                int right = Convert.ToInt16(Console.ReadLine());
                if (right != -1)
                {
                    temp.Right = new Node(right);
                    qNode.Enqueue(temp.Right);
                }
            }
            return root;
        }

        #endregion

        #region Level Order Traversal

        public void LevelOrderTraversal(Node root)
        {
            Queue<Node> que = new Queue<Node>();
            que.Enqueue(root);

            while (que.Count() > 0)
            {
                Node temp = que.Dequeue();
                Console.Write(temp.data + " ");

                if (temp.Left != null)
                {
                    que.Enqueue(temp.Left);
                }

                if (temp.Right != null)
                {
                    que.Enqueue(temp.Right);
                }
            }
        }

        #endregion

        #region Reverse Level Order Traversal

        public void ReverseLevelOrderTraversal(Node root)
        {
            Queue<Node> queNode = new Queue<Node>();
            Stack<Node> stackNode = new Stack<Node>();

            queNode.Enqueue(root);

            while (queNode.Count() > 0)
            {
                Node temp = queNode.Dequeue();
                stackNode.Push(temp);

                if (temp.Left != null)
                {
                    queNode.Enqueue(temp.Left);
                }

                if (temp.Right != null)
                {
                    queNode.Enqueue(temp.Right);
                }
            }

            while (stackNode.Count() > 0)
            {
                Node temp = stackNode.Pop();
                Console.Write(temp.data + " ");
            }
        }

        #endregion

        #region In-Order Traversal using Recursion

        public void InOrderTraversal(Node root)
        {
            //base case
            if (root == null)
            {
                return;
            }

            //LNR
            Node temp = root;

            if (temp.Left != null)
            {
                InOrderTraversal(temp.Left);
            }

            Console.Write(temp.data + " ");

            if (temp.Right != null)
            {
                InOrderTraversal(temp.Right);
            }
        }

        #endregion

        #region Pre-Order Traversal using Recursion

        public void PreOrderTraversal(Node root)
        {
            //base case
            if (root == null)
            {
                return;
            }

            //LNR
            Node temp = root;

            Console.Write(temp.data + " ");

            if (temp.Left != null)
            {
                PreOrderTraversal(temp.Left);
            }

            if (temp.Right != null)
            {
                PreOrderTraversal(temp.Right);
            }
        }

        #endregion

        #region Post-Order Traversal using Recursion

        public void PostOrderTraversal(Node root)
        {
            //base case
            if (root == null)
            {
                return;
            }

            //LNR
            Node temp = root;

            if (temp.Left != null)
            {
                PostOrderTraversal(temp.Left);
            }

            if (temp.Right != null)
            {
                PostOrderTraversal(temp.Right);
            }

            Console.Write(temp.data + " ");
        }

        #endregion

        #region In-Order Traversal without Recursion

        public void InOrderTraversalWithOutRecursion(Node root)
        {
            Stack<Node> sNode = new Stack<Node>();
            Node current = root;

            while (current != null || sNode.Count() > 0)
            {
                while (current != null)
                {
                    sNode.Push(current);
                    current = current.Left;
                }

                current = sNode.Pop();

                Console.Write(current.data + " ");
                current = current.Right;
            }
        }

        #endregion

        #region Pre-Order Traversal without Recursion

        public void PreOrderTraversalWithOutRecursion(Node root)
        {
            Stack<Node> sNode = new Stack<Node>();
            sNode.Push(root);

            while (sNode.Count() > 0)
            {
                Node temp = sNode.Pop();

                Console.Write(temp.data + " ");

                if (temp.Right != null)
                {
                    sNode.Push(temp.Right);
                }

                if (temp.Left != null)
                {
                    sNode.Push(temp.Left);
                }
            }
        }

        #endregion

        #region Post-Order Traversal without Recursion

        public void PostOrderTraversalWithOutRecursion(Node root)
        {
            Stack<Node> sNode = new Stack<Node>();
            Node current = root;

            while (true)
            {
                while (current != null)
                {
                    sNode.Push(current);
                    sNode.Push(current);
                    current = current.Left;
                }


                // Check for empty stack
                if (sNode.Count == 0)
                    return;
                current = sNode.Pop();
                if (sNode.Count != 0 && sNode.Peek() == current)
                    current = current.Right;
                else
                {
                    Console.Write(current.data + " ");
                    current = null;
                }

            }

        }

        #endregion

        #region Height Of Tree

        public int HeightOfTree(Node root)
        {
            //base case
            if (root == null)
            {
                return 0;
            }

            int left = HeightOfTree(root.Left);
            int right = HeightOfTree(root.Right);

            int ans = Math.Max(left, right) + 1;
            return ans;
        }

        #endregion

        #region Diameter of Tree

        public int DiameterOfTree(Node root)
        {
            //if (root == null)
            //{
            //    return 0;
            //}

            ////Traverse left of Tree
            //int leftDia = DiameterOfTree(root.Left);

            ////Traverse Right of Tree
            //int rightDia = DiameterOfTree(root.Right);

            ////Get height of Tree
            //int height = HeightOfTree(root.Left) + HeightOfTree(root.Right) + 1;

            ////Take max of above
            //int ans = Math.Max(Math.Max(leftDia, rightDia), height);

            //return ans;

            var ans = diameterFast(root);
            int result = new int();
            foreach (var item in ans)
            {
                result = item.Value;
            }

            return result;
        }



        private Dictionary<int, int> diameterFast(Node root)
        {
            if (root == null)
            {
                Dictionary<int, int> p = new Dictionary<int, int>();
                p.Add(0, 0);
                return p;
            }

            Dictionary<int, int> left = diameterFast(root.Left);
            Dictionary<int, int> right = diameterFast(root.Right);

            Dictionary<int, int> ans = new Dictionary<int, int>();

            int op1 = new int();
            int val1 = new int();
            foreach (var item in left)
            {
                op1 = item.Key;
                val1 = item.Value;
            }

            int op2 = new int();
            int val2 = new int();
            foreach (var item in right)
            {
                op2 = item.Key;
                val2 = item.Value;
            }

            //Max Diameter
            int op3 = val1 + val2 + 1;
            int v1 = Math.Max(op1, Math.Max(op2, op3));

            //Max Height
            int v2 = Math.Max(val1, val2) + 1;

            ans.Add(v1, v2);
            return ans;


        }

        #endregion

        #region Sum of Tree

        public bool IsSumTree(Node root)
        {
            var value = IsSumTreeNew(root);
            bool result = false;
            foreach (var item in value)
            {
                result = item.Key;
            }

            return result;
        }

        private Dictionary<bool, int> IsSumTreeNew(Node root)
        {
            //base case
            if (root == null)
            {
                Dictionary<bool, int> p = new Dictionary<bool, int>();
                p.Add(true, 0);
                return p;
            }

            //leaf nodes 
            if (root.Left == null && root.Right == null)
            {
                Dictionary<bool, int> p = new Dictionary<bool, int>();
                p.Add(true, root.data);
                return p;
            }

            //recursion
            Dictionary<bool, int> leftAns = IsSumTreeNew(root.Left);
            Dictionary<bool, int> rightAns = IsSumTreeNew(root.Right);

            //ans
            Dictionary<bool, int> ans = new Dictionary<bool, int>();

            bool left = false;
            bool right = false;

            int leftSum = new int();
            int rightSum = new int();

            foreach (var item in leftAns)
            {
                left = item.Key;
                leftSum = item.Value;
            }

            foreach (var item in rightAns)
            {
                right = item.Key;
                rightSum = item.Value;
            }

            //condition
            bool condition = root.data == (rightSum + leftSum);
            if (left && right && condition)
            {
                ans.Add(true, (2 * (root.data)));
            }
            else
            {
                ans.Add(false, 0);
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
                int[] arr = new int[size];

                //Level Process
                for (int i = 0; i < size; i++)
                {
                    Node node = q.Dequeue();

                    int index = directionLR ? i : size - i - 1;
                    arr[index] = node.data;

                    if (node.Left != null)
                    {
                        q.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        q.Enqueue(node.Right);
                    }
                }

                directionLR = !directionLR;

                foreach (var item in arr)
                {
                    ans.Add(item);
                }
            }
            return ans;
        }

        #endregion

        #region Boundary Traversal of Binary Tree

        public List<int> BoundaryTraversalOfTree(Node root)
        {
            List<int> ans = new List<int>();

            if (root == null)
            {
                return ans;
            }

            //add root to ans
            ans.Add(root.data);

            //Traverse left except Leaf Nodes
            traversalLeft(root.Left, ref ans);

            //Traverse Leaf Nodes

            //Leaf node in Left Subtree -- Traverse Leaf Nodes
            traversalLeafNode(root.Left, ref ans);

            //Leaf node in Right Subtree -- Traverse Leaf Nodes
            traversalLeafNode(root.Right, ref ans);

            //Traverse Right except leaf node
            traversalRight(root.Right, ref ans);

            return ans;
        }

        /// <summary>
        /// left traversal except Leaf
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ans"></param>
        private void traversalLeft(Node root, ref List<int> ans)
        {
            //base condition
            if ((root == null) || (root.Left == null && root.Right == null))
            {
                return;
            }

            ans.Add(root.data);

            if (root.Left != null)
            {
                traversalLeft(root.Left, ref ans);
            }
            else if (root.Right != null)
            {
                traversalLeft(root.Right, ref ans);
            }
        }

        private void traversalLeafNode(Node root, ref List<int> ans)
        {
            //base condition
            if (root == null)
            {
                return;
            }

            if (root.Left == null && root.Right == null)
            {
                ans.Add(root.data);
                return;
            }

            traversalLeafNode(root.Left, ref ans);
            traversalLeafNode(root.Right, ref ans);
        }

        /// <summary>
        /// left traversal except Right
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ans"></param>
        private void traversalRight(Node root, ref List<int> ans)
        {
            //base condition
            if ((root == null) || (root.Left == null && root.Right == null))
            {
                return;
            }

            ans.Add(root.data);

            if (root.Right != null)
            {
                traversalRight(root.Right, ref ans);
            }
            else if (root.Left != null)
            {
                traversalRight(root.Left, ref ans);
            }
        }


        #endregion

        #region Vertical Traversal of Tree

        public List<int> verticalOrder(Node root)
        {
            List<int> ans = new List<int>();

            if (root == null)
            {
                return ans;
            }

            Dictionary<int, List<int>> levelData = new Dictionary<int, List<int>>();
            int min = 0, max = 0;
            int hd = 0;

            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(root, hd));

            while (q.Count() > 0)
            {
                Pair frontNode = q.Dequeue();

                Node temp = frontNode.node;
                hd = frontNode.second;

                if (!levelData.ContainsKey(hd))
                {
                    levelData.Add(hd, new List<int>());
                }
                levelData[hd].Add(temp.data);

                if (temp.Left != null)
                {
                    q.Enqueue(new Pair(temp.Left, hd - 1));
                }

                if (temp.Right != null)
                {
                    q.Enqueue(new Pair(temp.Right, hd + 1));
                }

                if (min > hd)
                {
                    min = hd;
                }
                else if (max < hd)
                {
                    max = hd;
                }
            }

            for (int i = min; i <= max; i++)
            {
                List<int> temp = levelData[i];
                foreach (var item in temp)
                {
                    ans.Add(item);
                }
            }

            return ans;
        }

        #endregion

        #region Diagonal Traversal of Tree

        public List<int> DiagonalOrder(Node root)
        {
            List<int> ans = new List<int>();

            if (root == null)
            {
                return ans;
            }

            Dictionary<int, List<int>> levelData = new Dictionary<int, List<int>>();
            int min = 0, max = 0;
            int hd = 0;

            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(root, hd));

            while (q.Count() > 0)
            {
                Pair frontNode = q.Dequeue();

                Node temp = frontNode.node;
                hd = frontNode.second;

                if (!levelData.ContainsKey(hd))
                {
                    levelData.Add(hd, new List<int>());
                }
                levelData[hd].Add(temp.data);

                if (temp.Left != null)
                {
                    q.Enqueue(new Pair(temp.Left, hd - 1));
                }

                if (temp.Right != null)
                {
                    q.Enqueue(new Pair(temp.Right, hd));
                }

                if (min > hd)
                {
                    min = hd;
                }
                else if (max < hd)
                {
                    max = hd;
                }
            }

            for (int i = max; i >= min; i--)
            {
                List<int> temp = levelData[i];
                foreach (var item in temp)
                {
                    ans.Add(item);
                }
            }

            return ans;
        }

        #endregion

        #region Sum of nodes on the longest path from root to leaf node
        public int sumOfLongRootToLeafPath(Node root)
        {
            int sum = 0, sumMax = 0, len = 0, lenMax = 0;

            SolveLongRootToLeafPath(root, sum, ref sumMax, len, ref lenMax);
            Console.WriteLine("Longest Path " + lenMax + " ");

            return sumMax;
        }

        private void SolveLongRootToLeafPath(Node root, int sum, ref int sumMax, int len, ref int lenMax)
        {
            //base case
            if (root == null)
            {
                if (len > lenMax)
                {
                    lenMax = len;
                    sumMax = sum;
                }
                else if (len == lenMax)
                {
                    sumMax = Math.Max(sumMax, sum);
                }
                return;
            }

            sum = sum + root.data;

            SolveLongRootToLeafPath(root.Left, sum, ref sumMax, len + 1, ref lenMax);

            SolveLongRootToLeafPath(root.Right, sum, ref sumMax, len + 1, ref lenMax);
        }


        #endregion

        #region K Sum Paths

        public int sumK(Node root, int k)
        {
            int count = 0;
            List<int> result = new List<int>();

            SolveSumK(root, ref count, result, k);

            return count;
        }

        private void SolveSumK(Node root, ref int count, List<int> result, int k)
        {
            //base case
            if (root == null)
            {
                return;
            }

            result.Add(root.data);

            //left
            SolveSumK(root.Left, ref count, result, k);

            //right
            SolveSumK(root.Right, ref count, result, k);

            int size = result.Count();
            int sum = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                sum = sum + result[i];
                if (sum == k)
                {
                    count++;
                }
            }

            //Backtrack to remove the item added to get desired sum-k in the current iteration
            result.RemoveAt(size - 1);

        }

        #endregion

        #region Kth Ancestor in a Tree

        public int kthAncestor(Node root, int k, int node)
        {
            Node ans = SolvekthAncestor(root, ref k, node);
            if (ans == null || ans.data == node)
            {
                return -1;
            }
            else
            {
                return ans.data;
            }
        }

        private Node SolvekthAncestor(Node root, ref int k, int node)
        {
            //base case
            if (root == null)
            {
                return null;
            }

            //2nd base
            if (root.data == node)
            {
                return root;
            }

            Node leftAns = SolvekthAncestor(root.Left, ref k, node);
            Node rightAns = SolvekthAncestor(root.Right, ref k, node);

            if (leftAns != null && rightAns == null)
            {
                k--;
                if (k <= 0)
                {
                    k = int.MaxValue; // Locking answer so that returning root is not changed
                    return root;
                }
                return leftAns;
            }

            if (leftAns == null && rightAns != null)
            {
                k--;
                if (k <= 0)
                {
                    k = int.MaxValue; // Locking answer so that returning root is not changed
                    return root;
                }

                return rightAns;
            }

            return null;
        }

        #endregion

        #region Burning Tree

        public int BurnTree(Node root, int target)
        {

            Dictionary<Node, Node> parentNodeMap = new Dictionary<Node, Node>();
            Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
            Node targetNode = CreateMapping(root, target, ref parentNodeMap, ref visited);

            int ans = SolveminTime(targetNode, ref parentNodeMap, ref visited);
            return ans;
        }

        private int SolveminTime(Node root, ref Dictionary<Node, Node> parentNodeMap, ref Dictionary<Node, bool> visited)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            visited[root] = true;
            int count = 0;
            while (q.Count() > 0)
            {
                bool flag = false;
                int size = q.Count();
                for (int i = 0; i < size; i++)
                {
                    Node front = q.Dequeue();

                    if (front.Left != null && !visited[front.Left])
                    {
                        flag = true;
                        q.Enqueue(front.Left);
                        visited[front.Left] = true;
                    }

                    if (front.Right != null && !visited[front.Right])
                    {
                        flag = true;
                        q.Enqueue(front.Right);
                        visited[front.Right] = true;
                    }

                    if (parentNodeMap[front] != null && !visited[parentNodeMap[front]])
                    {
                        flag = true;
                        q.Enqueue(parentNodeMap[front]);
                        visited[parentNodeMap[front]] = true;
                    }
                    
                }

                if (flag == true)
                {
                    count++;
                }
            }

            return count;
        }

        private Node CreateMapping(Node root, int target, ref Dictionary<Node, Node> parentNodeMap, ref Dictionary<Node, bool> visited)
        {
            Node result = null;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            parentNodeMap[root] = null;
            visited[root] = false;

            while (q.Count() > 0)
            {
                Node front = q.Dequeue();
                visited[front] = false;
                if (front.data == target)
                {
                    result = front;
                }

                if (front.Left != null)
                {
                    parentNodeMap[front.Left] = front;
                    q.Enqueue(front.Left);
                }

                if (front.Right != null)
                {
                    parentNodeMap[front.Right] = front;
                    q.Enqueue(front.Right);
                }
            }

            return result;
        }

        #endregion

        #region Deletion BST

        public Node deleteNode(Node root, int X)
        {
            if (root == null)
            {
                return root;
            }

            if (root.data == X)
            {
                //0-Child
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                    return root;
                }

                //1-Child

                //Left Child
                if (root.Left != null && root.Right == null)
                {
                    Node temp = root.Left;
                    return temp;
                }

                //right Child
                if (root.Left == null && root.Right != null)
                {
                    Node temp = root.Right;
                    return temp;
                }

                //2-Child
                if (root.Left != null && root.Right != null)
                {
                    int mini = MinVal(root.Right);
                    root.data = mini;
                    root.Right = deleteNode(root.Right, mini);
                }
            }
            else if (root.data > X)
            {
                root.Left = deleteNode(root.Left, X);
            }

            else if (root.data < X)
            {
                root.Right = deleteNode(root.Right, X);
            }

            return root;
        }

       


        #endregion

        #region Kth Smallest in BST

        public int KthSmallestElement(Node root, int K)
        {
            int i = 0;

            int ans = SolveKthSmallestElement(root, ref i, K);
            return ans;
        }

        private int SolveKthSmallestElement(Node root, ref int i, int k)
        {
            //base case
            if (root == null)
            {
                return -1;
            }

            //Inorder -- LNR

            //l
            int left = SolveKthSmallestElement(root.Left, ref i, k);

            if (left != -1)
            {
                return left;
            }

            //N
            i++;
            if (i == k)
            {
                return root.data;
            }


            //R
            return SolveKthSmallestElement(root.Right, ref i, k);
        }

        #endregion

        #region Predecessor & Successor

        public void findPreSuc(Node root, ref Node pre, ref Node suc, int key)
        {
            //find key
            Node temp = root;

            while (temp.data != key)
            {
                if (temp.data > key)
                {
                    suc = temp;
                    temp = temp.Left;
                }
                else if (temp.data < key)
                {
                    pre = temp;
                    temp = temp.Right;
                }
            }

            //prec
            Node leftSub = temp.Left;
            while (leftSub != null)
            {
                pre = leftSub;
                leftSub = leftSub.Right;
            }

            //suc
            Node rightSub = temp.Right;
            while (rightSub != null)
            {
                suc = rightSub;
                rightSub = rightSub.Left;
            }
        }

        #endregion

        #region Balanced Tree Check

        public bool isBalancedTree(Node root)
        {
            PairBool p = SolveisBalancedTree(root);
            return p.first;
        }

        private PairBool SolveisBalancedTree(Node root)
        {
            PairBool ans = null;
            if (root == null)
            {
                PairBool p = new PairBool(true, 0);
                return p;
            }

            PairBool left = SolveisBalancedTree(root.Left);
            PairBool right = SolveisBalancedTree(root.Right);

            bool diffheight = Math.Abs(left.second - right.second) <= 1;

            bool v1 = (left.first && right.first && diffheight);
            int maxHeight = Math.Max(left.second, right.second) + 1;

            ans = new PairBool(v1, maxHeight);

            return ans;
        }


        #endregion

        #region Common Functions

        private int MinVal(Node root)
        {
            int mini = root.data;
            while (root.Left != null)
            {
                mini = root.Left.data;
                root = root.Left;
            }

            return mini;
        }

        private int MaxVal(Node root)
        {
            int max = root.data;
            while (root.Right != null)
            {
                max = root.data;
                root = root.Right;
            }

            return max;
        }

        #endregion
    }

    internal class Pair
    {
        public Node node;
        public int second;

        public Pair(Node node, int second)
        {
            this.node = node;
            this.second = second;
        }
    }

    internal class PairBool
    {
        public bool first;
        public int second;

        public PairBool(bool first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }


    public class Node
    {
        public int data;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            data = value;
            Left = null;
            Right = null;
        }
    }

}
