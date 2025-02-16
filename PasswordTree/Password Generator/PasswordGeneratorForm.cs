﻿using PasswordTree.Tree_Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTree.Password_Generator
{
    public partial class PasswordGeneratorForm : Form
    {
        public PasswordGeneratorForm()
        {
            InitializeComponent();
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator(Data.DefaultTree());
            textBoxCurrentPassword.Text += passwordGenerator.Create((int)numericPasswordLength.Value) + "\r\n";
        }
    }
}
