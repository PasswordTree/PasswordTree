using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PasswordTree.Password_Generator
{
    internal static class Extention
    {
        public static TreeNode[] Leaves(this TreeNode tree)
        {
            List<TreeNode> DFS(TreeNode node)
            {
                List<TreeNode> leaves = new List<TreeNode> { node };
                foreach (TreeNode child in node.Nodes)
                {
                    leaves.AddRange(DFS(child));
                }
                return leaves;
            }

            var temp = DFS(tree);
            return temp.Where(node => node.Nodes.Count == 0).ToArray();
        }

        public static TreeNode GetParentAt(this TreeNode tree, int level)
        {
            List<TreeNode> GetPath(TreeNode node)
            {
                List<TreeNode> l = new List<TreeNode> { node };
                if (!(node.Parent is null))
                {
                    l.AddRange(GetPath(node.Parent));
                }
                return l;
            }

            TreeNode[] nodePath = GetPath(tree).ToArray();
            return nodePath[nodePath.Length - level - 1];
        }

        public static void UpdateNodesCheck(this TreeView tree, TreeNode selectedNode, ref bool cpuCheckedTree)
        {
            cpuCheckedTree = true;

            TraverseCheckBoxNode(selectedNode);

            cpuCheckedTree = false;
        }

        public static void UpdateNodesCheck(this TreeNode selectedNode)
        {
            TraverseCheckBoxNode(selectedNode);
        }

        private static void TraverseCheckBoxNode(TreeNode selectedNode)
        {
            void CheckChildren(TreeNode node)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    child.Checked = selectedNode.Checked;
                    CheckChildren(child);
                }
            }
            CheckChildren(selectedNode);


            void CheckParent(TreeNode node)
            {
                if (!(node.Parent is null))
                {
                    bool isAnyChildrenChecked = node.Parent.Nodes.Cast<TreeNode>().Any(x => x.Checked == true);
                    node.Parent.Checked = isAnyChildrenChecked;
                    CheckParent(node.Parent);
                }
            }
            CheckParent(selectedNode);
        }

        public static TreeNode PruneByCheckBoxes(this TreeNode tree)
        {
            void PruneNode(TreeNode node)
            {
                List<TreeNode> list = new List<TreeNode>();
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Checked)
                    {
                        PruneNode(child);
                    }
                    else
                    {
                        list.Add(child);
                    }
                }

                foreach (TreeNode child in list)
                {
                    child.Remove();
                }
                if (!node.Checked)
                {
                    node.Remove();
                }
            }
            
            TreeNode prunedTree = tree.Copy();
            PruneNode(prunedTree);
            return prunedTree;
        }

        public static TreeNode Copy(this TreeNode tree)
        {
            TreeNode node = new TreeNode()
            {
                Name = tree.Name,
                Checked = tree.Checked,
                Text = tree.Text
            };

            foreach (TreeNode child in tree.Nodes)
            {
                node.Nodes.Add(child.Copy());
            }
           return node;
        }
    }
}
