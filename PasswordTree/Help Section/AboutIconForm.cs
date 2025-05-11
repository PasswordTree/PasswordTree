using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PasswordTree.Help_Section
{
    public partial class AboutIconForm : Form
    {
        public AboutIconForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenLink()
        {
            string link = @"https://www.flaticon.com/free-icon/hacker_924915?term=hacker&related_id=924915";
            Process.Start(link);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenLink();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLink();
        }
    }
}
