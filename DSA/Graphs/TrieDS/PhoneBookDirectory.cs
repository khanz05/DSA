using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.TrieDS
{
    internal class PhoneBookDirectory
    {
        public void PhoneBookDirectorySuggestion(string[] arr, int n, string prefix)
        {
            TrieForPhone t = new TrieForPhone();
            for (int i = 0; i < n; i++)
            {
                t.InsertWord(arr[i]);
            }

            //Get Suggestion
            t.GetSuggestion(prefix);
        }
    }
    public class TrieNodeForPhone
    {
        public char data;
        public int childCount;
        public TrieNodeForPhone[] children;
        public bool IsTerminal;

        public TrieNodeForPhone(char ch)
        {
            children = new TrieNodeForPhone[26];
            for (int i = 0; i < 26; i++)
            {
                children[i] = null;
            }
            IsTerminal = false;
            childCount = 0;
        }
    }

    public class TrieForPhone
    {
        TrieNodeForPhone root;

        public TrieForPhone()
        {
            root = new TrieNodeForPhone('\0');
        }

        public void InsertWord(string word)
        {
            InsertUtil(root, word);
        }

        private void InsertUtil(TrieNodeForPhone root, string word)
        {
            //Base case
            if (word.Length == 0)
            {
                root.IsTerminal = true;
                return;
            }

            int index = word[0] - 'A';
            TrieNodeForPhone child;

            //Present 
            if (root.children[index] != null)
            {
                child = root.children[index];
            }
            else
            {
                //Absent
                child = new TrieNodeForPhone(word[0]);
                root.children[index] = child;
                root.childCount++;
            }

            //Recursion
            InsertUtil(child, word.Substring(1));
        }


        public void GetSuggestion(string str)
        {
            TrieNodeForPhone prev = root;
            List<string> output = new List<string>();
            List<string> prefix = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                char lastch = str[i];
                prefix.Add(lastch.ToString());

                TrieNodeForPhone current = prev.children[lastch - 'A'];

                // If not found
                if (current == null)
                {
                    break;
                }

                PrintSuggestion(current, ref output, ref prefix);
            }

            foreach (var item in output)
            {
                Console.WriteLine(item);

            }
        }

        private void PrintSuggestion(TrieNodeForPhone current, ref List<string> output, ref List<string> prefix)
        {
            if (current.IsTerminal)
            {
                output.Add(prefix[0]);
                return;
            }

            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                TrieNodeForPhone next = current.children[ch - 'A'];

                if (next != null)
                {
                    prefix.Add(ch.ToString());
                    PrintSuggestion(next, ref output, ref prefix);
                    prefix.RemoveAt(prefix.Count() - 1);
                }
            }
        }
    }
}
