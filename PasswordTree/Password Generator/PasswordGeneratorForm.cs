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
                if (!isSuccesful) throw new Exception("Reading Tree, failed");
            }
            catch (Exception error)
            {
                if (error is FileNotFoundException)
                {
                    MessageBox.Show(error.Message, "Tree File, Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (error is FileLoadException)
                {
                    MessageBox.Show(error.Message, "Loading Tree File, Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (error is JsonReaderException)
                {
                    MessageBox.Show(error.Message, "Loading JSON, Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(error.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Settings.Password.Tree = Data.DefaultTree();
                MessageBox.Show("App is using default Tree...", "No Worries", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                bool isSuccesful = Settings.Read();
                if (!isSuccesful) throw new Exception("Reading config file, failed");
            }
            catch (Exception error)
            {
                if (error is FileNotFoundException)
                {
                    MessageBox.Show(error.Message, "Config File, Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(error.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("App is using default Settings...", "No Worries", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            checkBoxPasswordDistinct.Checked = Settings.Password.IsDistinct;
            numericUpDownSelectionCooldown.Maximum = Settings.PasswordCatagory.MaximumLength;
            numericUpDownSelectionCooldown.Value = Settings.PasswordCatagory.CurrentLength;
            numericPasswordLength.Value = Settings.Password.CurrentLength;
        }

        private void PasswordGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool isSuccesful = Settings.Password.Write();
                if (!isSuccesful) throw new Exception("App couldn't save Tree!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Saving Tree, Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                bool isSuccesful = Settings.Write();
                if (!isSuccesful) throw new Exception("App couldn't save config file!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Saving Config File, Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                PasswordGenerator passwordGenerator = new PasswordGenerator();
                string password = passwordGenerator.Create((int)numericPasswordLength.Value);

                BeforeAppend();
                textBoxCurrentPassword.Text = password;
                AfterAppend();
            }
            catch (ArgumentOutOfRangeException error)
            {
                MessageBox.Show(error.Message, "Can't Generate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Somthing went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            int maxCatLen = Settings.PasswordCatagory.MaximumLength;

            numericUpDownSelectionCooldown.Maximum = maxCatLen;
            if (numericUpDownSelectionCooldown.Value > maxCatLen)
            {
                numericUpDownSelectionCooldown.Value = maxCatLen;
            }
        }

        private void checkBoxPasswordDistinct_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Password.IsDistinct = checkBoxPasswordDistinct.Checked;
        }

        private void numericUpDownSelectionCooldown_ValueChanged(object sender, EventArgs e)
        {
            Settings.PasswordCatagory.CurrentLength = (int)numericUpDownSelectionCooldown.Value;
        }

        private void numericPasswordLength_ValueChanged(object sender, EventArgs e)
        {
            Settings.Password.CurrentLength = (int)numericPasswordLength.Value;
        }
    }
}
