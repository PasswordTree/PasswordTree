using PasswordTree.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTree.Password_Generator
{
    internal class PasswordGenerator
    {
        private Random random = new Random();
        private TreeNode tree;

        private int length = 20;
        public int Length { get => length; set => length = value; }
       
        public PasswordGenerator(TreeNode tree)
        {
            this.tree = tree;
        }

        public string Create(int passwordLength)
        {
            string password = "";
            List<TreeNode> previousCat = new List<TreeNode>();
            var treeLeaves = tree.Leaves();

            int maxPasswordLength = string.Concat(treeLeaves.Select(leaf => leaf.Name)).Length;
            if (Settings.Password.IsDistinct && passwordLength > maxPasswordLength)
            {
                throw new IndexOutOfRangeException("Sum of all selected leaves is less than password length");
            }

            while (password.Length < passwordLength)
            {
                int selectedLeafIndex = random.Next(treeLeaves.Length);
                TreeNode selectedLeaf = treeLeaves[selectedLeafIndex];
                TreeNode selectedCat = selectedLeaf.GetParentAt(1);

                if (!previousCat.Contains(selectedCat))
                {
                    string value = selectedLeaf.ToString();
                    char selectedChar = value[random.Next(value.Length)];

                    if (!(Settings.Password.IsDistinct && password.Contains(selectedChar)))
                    {
                        password += selectedChar;
                        previousCat.Add(selectedCat);
                        if (previousCat.Count > Settings.PasswordCatagory.CuerentLength)
                        {
                            previousCat.RemoveAt(0);
                        }
                    }
                }
            }
            return password;
        }
    }
}
