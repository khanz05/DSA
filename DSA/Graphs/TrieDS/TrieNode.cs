using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.TrieDS
{
    public class TrieNode
    {
        public TrieNode[] child;
        public bool IsTerminal;
        public char data;
        public int childCount;

        public TrieNode(char ch)
        {
            IsTerminal = false;
            child = new TrieNode[26];
            for (int i = 0; i < 26; i++)
            {
                child[i] = null;
            }
            childCount = 0;
        }
    }

    public class Trie
    {
        public TrieNode root;

        public Trie()
        {
            root = new TrieNode('\0');
        }

        #region Insert in Trie

        public void InsertWord(string word)
        {
            InsertUtil(root, word);
        }

        //Using Recursion for Inserting Into Trie
        private void InsertUtil(TrieNode root, string word)
        {
            //base case
            if (word.Length == 0)
            {
                root.IsTerminal = true;
                return;
            }

            int index = word[0] - 'A';
            TrieNode child;

            //Present
            if (root.child[index] != null)
            {
                child = root.child[index];
            }
            else
            {
                //Absent
                child = new TrieNode(word[0]);
                root.childCount++;
                root.child[index] = child;
            }

            //Recursion
            InsertUtil(child, word.Substring(1));
        } 

        #endregion

        #region Search in Trie

        public bool SearchWord(string word)
        {
            return SearchUtil(root, word);
        }

        private bool SearchUtil(TrieNode root, string word)
        {
            //Base Case
            if (word.Length == 0)
            {
                return root.IsTerminal;
            }

            int index = word[0] - 'A';
            TrieNode child;

            //Present
            if (root.child[index] != null)
            {
                child = root.child[index];
            }
            else
            {
                //Absent
                return false;
            }

            return SearchUtil(child, word.Substring(1));
        } 

        #endregion

        #region Remove word from Trie

        public void RemoveWord(string word)
        {
            RemoveUtil(root, word, 0);
        }


        static bool isEmpty(TrieNode root)
        {
            for (int i = 0; i < 26; i++)
                if (root.child[i] != null)
                    return false;
            return true;
        }

        // Recursive function to delete a key from given Trie
        private TrieNode RemoveUtil(TrieNode root, String key, int depth)
        {
            // If tree is empty
            if (root == null)
                return null;

            // If last character of key is being processed
            if (depth == key.Length)
            {

                // This node is no more end of word after
                // removal of given key
                if (root.IsTerminal)
                    root.IsTerminal = false;

                // If given is not prefix of any other word
                if (isEmpty(root))
                {
                    root = null;
                }

                return root;
            }

            // If not last character, recur for the child
            // obtained using ASCII value
            int index = key[depth] - 'A';
            root.child[index] =
                RemoveUtil(root.child[index], key, depth + 1);

            // If root does not have any child (its only child got
            // deleted), and it is not end of another word.
            if (isEmpty(root) && root.IsTerminal == false)
            {
                root = null;
            }

            return root;
        } 

        #endregion

        /// <summary>
        /// BRUTE FORCE
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        public void LongestCommonPrefix(string[] arr, int n)
        {
            string ans = "";

            //traversing all Characters of first string
            for (int i = 0; i < arr[0].Length; i++)
            {
                char ch = arr[0][i];

                bool match = true;

                //for comparing ch with rest of the strings
                for (int j = 1; j < n; j++)
                {
                    //not match
                    if (arr[j].Length < i || ch != arr[j][i])
                    {
                        match = false;
                        break;
                    }
                }

                if (match == false)
                {
                    break;
                }
                else
                {
                    ans = ans + ch;
                }
            }

            Console.WriteLine(ans);
       
        }

        public void LongestCommonPrefixTrie(string[] arr, int n)
        {
            string ans = "";
            for (int i = 0; i < arr.Length; i++)
            {
                InsertWord(arr[i]);
            }

            string first = arr[0];
            LCP(first, ref ans);

            Console.WriteLine(ans);
        }

        private void LCP(string str, ref string ans)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (root.childCount == 1)
                {
                    ans = ans + ch;
                    int index = ch - 'A';
                    root = root.child[index];
                }
                else
                {
                    break;
                }

                if (root.IsTerminal)
                {
                    break;
                }
            }
        }

    }
}
