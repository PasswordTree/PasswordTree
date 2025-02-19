﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            return DFS(tree).Where(node => node.Nodes.Count == 0).ToArray();
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
    }
}
