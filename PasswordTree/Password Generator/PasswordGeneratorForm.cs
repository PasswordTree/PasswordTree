using Newtonsoft.Json;
using PasswordTree.Configuration;
using PasswordTree.Help_Section;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PasswordTree.Configuration.Settings;

namespace PasswordTree.Password_Generator
{
    public partial class PasswordGeneratorForm : Form
    {
        List<string> previousPasswordList = new List<string>();

        public PasswordGeneratorForm()
        {
            InitializeComponent();
           
        }

        private async void PasswordGeneratorForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool isSuccesful = await Settings.Password.Read();
                if (!isSuccesful) throw new FileLoadException();
            }
            catch (Exception error)
            {
                if (error is FileNotFoundException || error is FileLoadException || error is JsonReaderException)
                {
                    MessageBox.Show("Tree is not complete\nDon't worry, we assigned default Tree",
                                    "Data Interruption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TreeNode tree = Data.DefaultTree();
                    Settings.Password.Tree = tree;
                }
                else
                {
                    MessageBox.Show(error.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PasswordGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Password.WriteJson();
        }

        private void BeforeAppend()
        {
            if (Settings.Password.PreviousPasswordEnabled)
            {
                if (!string.IsNullOrEmpty(textBoxCurrentPassword.Text))
                {
                    previousPasswordList.Add(textBoxCurrentPassword.Text);
                }

                if (previousPasswordList.Count > Settings.Password.PreviousPasswordCount)
                {
                    previousPasswordList.RemoveAt(0);
                }
            }
        }

        private void AfterAppend()
        {
            textBoxPreviousPasswords.Lines = previousPasswordList.ToArray();
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator();
            string password = passwordGenerator.Create((int)numericPasswordLength.Value);

            BeforeAppend();
            textBoxCurrentPassword.Text = password;
            AfterAppend();
        }

        private void aboutAppsIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutIconForm form = new AboutIconForm())
            {
                form.ShowDialog();
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                form.ShowDialog();
            }
            numericUpDownSelectionCooldown.Maximum = Settings.PasswordCatagory.MaximumLength;
        }

        private void checkBoxPasswordDistinct_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Password.IsDistinct = checkBoxPasswordDistinct.Checked;
        }

        private void numericUpDownSelectionCooldown_ValueChanged(object sender, EventArgs e)
        {
            Settings.PasswordCatagory.CurrentLength = (int)numericUpDownSelectionCooldown.Value;
        }
    }
}
