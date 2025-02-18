using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = @"https://www.flaticon.com/free-icon/hacker_924915?term=hacker&related_id=924915";
            Process.Start(link);
        }
    }
}
