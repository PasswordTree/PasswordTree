using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordTree.Tree_Structure
{
    internal class Tree<T>
    {
        public Node<T> Root { get; set; }

        public Tree(Node<T> root)
        {
            Root = root;
        }

        public Tree(Node<T> root, params Node<T>[] children) : this(root)
        {
            root.AddChildren(children);
        }

        public string Travers(string seperator = "\t")
        {
            string DFS(Node<T> node, int repaetCount = 0)
            {
                string s = string.Concat(Enumerable.Repeat(seperator, repaetCount)) + node + "\r\n";
                foreach (var child in node)
                {
                    s += DFS(child, repaetCount + 1);
                }
                return s;
            }
            string dfs = DFS(Root);

            return dfs;
        }
    }
}
