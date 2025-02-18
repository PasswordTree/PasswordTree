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
            return password;
        }
    }
}
