using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordTree.Tree_Structure
{
    public class Node
    {
        string key;
        object value;
        internal int level;
        string path;
        Node parent;
        internal List<Node> children = new List<Node>();

        public Node(string name, object data = null)
        {
            key = name;
            value = data;
            path = name;
        }
        public Node(Node node)
        {
            key = node.key;
            value = node.value;
            level = node.level;
            path = node.path;
            parent = node.parent;
            children = node.children.ToList();
        }

        public string Key { get => key; set => key = value; }
        public object Value { get => value; set => this.value = value; }
        public int Level { get => level; }
        public bool hasParent { get => !(parent == null); }
        public string Path { get => path; }
        public Node Parent { get => parent; }
        public Node this[int index] { get => children[index]; }
        public Node this[string nodeName] { get => children.Where(x => x.key == nodeName).ToList()[0]; }
        public int ChildrenCount { get => children.Count; }

        public void AddChild(Node childNode)
        {
            childNode.level = this.level + 1;
            childNode.parent = this;
            childNode.path = $"{path}->{childNode.key}";
            children.Add(childNode);
        }
        public void AddChild(string childName)
        {
            AddChild(new Node(childName));
        }
        public void AddChildren(params string[] childrenNames)
        {
            foreach (string nodeName in childrenNames)
            {
                AddChild(nodeName);
            }
        }

        public void DeleteChild(Node node)
        {
            if (children.Contains(node)) children.Remove(node);
        }
        public void DeleteChildAt(int childIndex)
        {
            DeleteChild(children[childIndex]);
        }

        public bool SameAncestorLevel(Node node, int level)
        {
            if (node == null || (string.IsNullOrEmpty(node.path) ^ string.IsNullOrEmpty(path))) return false;
            return GetParentAt(level) == node.GetParentAt(level);
        }

        public Node GetParentAt(int level)
        {
            if (parent.level == level) return parent;
            return parent.GetParentAt(level);
        }

        public override string ToString()
        {
            return key;
        }


        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        public class MyEnumerator
        {
            int index;
            Node node;
            public MyEnumerator(Node coll)
            {
                node = coll;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return (index < node.children.Count);
            }

            public Node Current
            {
                get
                {
                    return node.children[index];

                }
            }
        }
    }
}
