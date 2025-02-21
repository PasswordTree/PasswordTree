using PasswordTree.Configuration;
using PasswordTree.Help_Section;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            PasswordGenerator passwordGenerator = new PasswordGenerator(Data.DefaultTree());
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
        }

        
    }
}
