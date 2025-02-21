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
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(Data.DefaultTree());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBoxPreviousPass.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Settings.Password.PreviousPasswordEnabled = checkBoxPreviousPass.Checked;
            Settings.Password.PreviousPasswordCount = (int)numericUpDown1.Value;

            Close();
        }
    }
}
