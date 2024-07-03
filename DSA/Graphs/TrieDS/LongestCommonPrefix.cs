using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.TrieDS
{
    internal class LongestCommonPrefix
    {
        public void LCP(string[] arr, int n)
        {
            string ans = "";
            TrieForLCP t = new TrieForLCP();

            for (int i = 0; i < n; i++)
            {
                t.InsertWord(arr[i]);
            }

            string first = arr[0];

            for (int i = 0; i < first.Length; i++)
            {
                bool match = true;
                char ch = first[i];
                if (t.root.childCount == 1)
                {
                    ans = ans + ch;
                    int index = ch - 'A';
                    t.root = t.root.children[index];
                }
                else
                {
                    match = false;
                }

                if (match == false)
                {
                    break;
                }

                if (t.root.IsTerminal == true)
                {
                    break;
                }
            }

            Console.WriteLine(ans);
        }
    }

    public class TrieNodeForLCP
    {
        public char data;
        public bool IsTerminal;
        public int childCount;
        public TrieNodeForLCP[] children;

        public TrieNodeForLCP(char ch)
        {
            children = new TrieNodeForLCP[26];
            for (int i = 0; i < 26; i++)
            {
                children[i] = null;
            }

            IsTerminal = false;
            childCount = 0;
        }
    }

    public class TrieForLCP
    {
        public TrieNodeForLCP root;

        public TrieForLCP()
        {
            root = new TrieNodeForLCP('\0');
        }

        public void InsertWord(string word)
        {
            InsertUtil(root, word);
        }

        private void InsertUtil(TrieNodeForLCP root, string word)
        {
            //base case
            if (word.Length == 0)
            {
                root.IsTerminal = true;
                return;
            }

            int index = word[0] - 'A';
            TrieNodeForLCP child;

            //Present
            if (root.children[index] != null)
            {
                child = root.children[index];
            }
            else
            {
                //Absent
                child = new TrieNodeForLCP(word[0]);
                root.children[index] = child;
                root.childCount++;
            }

            //Recursion
            InsertUtil(child, word.Substring(1));
        }
    }
}
