using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PasswordTree.Tree_Structure
{
    public class Node<T> : IEnumerable<Node<T>> where T : IEquatable<T>
    {
        public T Data { get; set; }
        public string Name { get; set; }

        private Node<T> Parent {  get; set; }
        public bool HasParent { get => !(Parent is null); }

        public List<Node<T>> Children { get; private set; }
        public int ChildrenCount { get => Children.Count; }
        public bool IsLeaf { get => Children.Count == 0; }
        
        public Node(T data)
        {
            Data = data;
            Children = new List<Node<T>>();
        }

        public Node(T data, params Node<T>[] children) : this(data)
        {
            AddChildren(children);
        }

        public void AddChild(Node<T> child)
        {
            if (child is null) throw new ArgumentNullException("Given node is Null!");
            if (child.HasParent) throw new ArgumentException("Given node has parent!");

            child.Parent = this;
            Children.Add(child);
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
            if (node is null) throw new ArgumentNullException("Given node is Null!");
            if (!Children.Contains(node)) throw new ArgumentOutOfRangeException("Given node is there!");
            
            Children.Remove(node);
        }

        public void DeleteChildAt(int index)
        {
            if (index < 0 || index > Children.Count) throw new ArgumentOutOfRangeException("Given index is out of range!");
            
            Children.RemoveAt(index);
        }

        public Node<T> GetParentAt(int level)
        {
            List<Node<T>> GetPath(Node<T> node)
            {
                List<Node<T>> l = new List<Node<T>> { node };
                if (node.HasParent)
                {
                    l.AddRange(GetPath(node.Parent));
                }
                return l;
            }

            List<Node<T>> nodePath = GetPath(this);
            return nodePath[nodePath.Count - level - 1];
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Node<T> node)
            {
                return EqualityComparer<T>.Default.Equals(Data, node.Data);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
