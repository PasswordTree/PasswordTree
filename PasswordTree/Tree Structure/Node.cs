using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordTree.Tree_Structure
{
    public class Node<T> : IEnumerable<Node<T>>
    {
        public T Data { get; set; }
        public string Name { get; set; }

        List<Node<T>> children = new List<Node<T>>();
        public List<Node<T>> Children { get => children; }
        public int ChildrenCount { get => children.Count; }


        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, params Node<T>[] children) : this(data)
        {
            AddChildren(children);
        }

        public void AddChild(Node<T> child)
        {
            children.Add(child);
        }

        public void AddChildren(params Node<T>[] children)
        {
            foreach (Node<T> child in children)
            {
                AddChild(child);
            }
        }

        public void DeleteChild(Node<T> node)
        {
            if (children.Contains(node)) children.Remove(node);
        }

        public void DeleteChildAt(int index)
        {
            if (index >= 0 && index <= children.Count) children.RemoveAt(index);
        }

        public override string ToString()
        {
            return Data.ToString();
        }


        public IEnumerator<Node<T>> GetEnumerator()
        {
            return children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
