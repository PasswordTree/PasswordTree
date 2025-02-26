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

        public string Create(int passwordLength)
        {
            string password = "";
            List<TreeNode> previousCat = new List<TreeNode>();
            var prunedLeaves = Settings.Password.Tree.PruneByCheckBoxes().Leaves();

            int maxPassLength = Settings.Password.MaximumLength;
            if (Settings.Password.IsDistinct && passwordLength > maxPassLength)
            {
                throw new ArgumentOutOfRangeException("Sum of all selected leaves is less than password length\n" +
                                                      $"Max length based on selected nodes: {maxPassLength}");
            }

            while (password.Length < passwordLength)
            {
                int randomLeafIndex = random.Next(prunedLeaves.Length);
                TreeNode selectedLeaf = prunedLeaves[randomLeafIndex];
                TreeNode selectedCat = selectedLeaf.GetParentAt(1);

                if (!previousCat.Contains(selectedCat))
                {
                    string value = selectedLeaf.ToString();
                    char selectedChar = value[random.Next(value.Length)];

                    if (!(Settings.Password.IsDistinct && password.Contains(selectedChar)))
                    {
                        password += selectedChar;
                        previousCat.Add(selectedCat);
                        if (previousCat.Count > Settings.PasswordCatagory.CurrentLength)
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
