using PasswordTree.Password_Generator;
using System;
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(Settings.Password.Tree.Copy());
            checkBoxPreviousPass.Checked = Settings.Password.PreviousPasswordEnabled;
            numericUpDownPreviousPassCounts.Value = Settings.Password.PreviousPasswordCount;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownPreviousPassCounts.Enabled = checkBoxPreviousPass.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Settings.PasswordCatagory.GetMaxCatLen(treeView1.Nodes[0]) < 0)
            {
                MessageBox.Show("Please select at least one leaf", "Node Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Settings.Password.PreviousPasswordEnabled = checkBoxPreviousPass.Checked;
            Settings.Password.PreviousPasswordCount = (int)numericUpDownPreviousPassCounts.Value;

            Settings.Password.Tree = treeView1.Nodes[0];

            Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (cpuCheckedTree) return;

            treeView1.UpdateNodesCheck(e.Node, ref cpuCheckedTree);
        }
    }
}
