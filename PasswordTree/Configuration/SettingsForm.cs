using PasswordTree.Password_Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTree.Configuration
{
    public partial class SettingsForm : Form
    {
        private bool cpuCheckedTree = false;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(Settings.Password.Tree);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownPreviousPassCounts.Enabled = checkBoxPreviousPass.Checked;
        }

        private async void buttonOK_Click(object sender, EventArgs e)
        {
            Settings.Password.PreviousPasswordEnabled = checkBoxPreviousPass.Checked;
            Settings.Password.PreviousPasswordCount = (int)numericUpDownPreviousPassCounts.Value;
            Settings.PasswordCatagory.CurrentLength = (int)numericUpDownSelectionCooldown.Value;
            Settings.Password.IsDistinct = checkBoxPasswordDistinct.Checked;

            TreeNode tree = treeView1.Nodes[0];
            Settings.Password.Tree = tree;

            Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (cpuCheckedTree) return;

            treeView1.UpdateNodesCheck(e.Node, ref cpuCheckedTree);
        }
    }
}
