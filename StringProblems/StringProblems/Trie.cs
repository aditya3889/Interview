using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProblems
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Nodes;

        public TrieNode()
        {
            this.Nodes = new Dictionary<char, TrieNode>();
        }
    }

    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            this.root = new TrieNode();
        }

        // Adds a word into the data structure.
        public void AddWord(String word)
        {
            TrieNode node = root;
            foreach (char letter in word)
            {
                if (!node.Nodes.ContainsKey(letter))
                {
                    node.Nodes[letter] = new TrieNode
                    {
                        //Current = letter
                    };                    
                }

                node = node.Nodes[letter];
            }

            if (!node.Nodes.ContainsKey('\0'))
            {
                node.Nodes['\0'] = new TrieNode
                {
                    //Current = '\0'
                };
            }
        }

        // Returns if the word is in the data structure. A word could
        // contain the dot character '.' to represent any one letter.
        public bool Search(string word)
        {
            var options = new List<TrieNode>() { root };
            foreach (char letter in word)
            {
                var newOptions = new List<TrieNode>();

                foreach (TrieNode node in options)
                {
                    if (letter == '.')
                    {
                        foreach (TrieNode childNode in node.Nodes.Values)
                        {
                            newOptions.Add(childNode);
                        }
                    }
                    else
                    {
                        if (node.Nodes.ContainsKey(letter))
                        {
                            newOptions.Add(node.Nodes[letter]);
                        }
                    }
                }

                options = newOptions;
            }

            return options.Any(t => t.Nodes.ContainsKey('\0'));
        }
    }    
}
