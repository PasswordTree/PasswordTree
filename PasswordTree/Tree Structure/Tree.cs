using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordTree.Tree_Structure
{
    public class Tree
    {
        Node root;
        public Node Root { get => root; }
        public Node[] Leaves { get => GetNodesByDFS(root).Where(x => x.ChildrenCount == 0).ToArray(); }

        public Tree(Node root)
        {
            this.root = root;
            this.root.level = 0;
        }

        public string TraverseDFS(string seprator = " ")
        {
            List<Node> nodes = GetNodesByDFS(root).ToList();
            string[] s = nodes.Select(x => $"{string.Concat(Enumerable.Repeat(seprator, x.level))}{x.Key}: {x.Value}").ToArray();
            return string.Join("\r\n", s);
        }
        List<Node> GetNodesByDFS(Node node)
        {
            List<Node> s = new List<Node> { node };
            foreach (var item in node)
            {
                s.AddRange(GetNodesByDFS(item));
            }
            return s;
        }

        public List<Node> GetNodesAt(int level)
        {
            List<Node> nodes = new List<Node> { root };

            for (int i = 1; i <= level; i++)
            {
                nodes = nodes.SelectMany(x => x.children).ToList();
            }
            return nodes;
        }
    }
}
