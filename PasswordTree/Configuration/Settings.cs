﻿using PasswordTree.Password_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTree.Configuration
{
    internal static class Settings
    {
        internal static class PasswordCatagory
        {
            public static int MaximumLength { get; set; }
            public static int CuerentLength { get; set; }
        }

        internal static class Password
        {
            public static TreeNode Tree { get; set; } = Data.DefaultTree();
            public static bool IsDistinct { get; set; } = false;
            public static bool PreviousPasswordEnabled { get; set; } = true;
            public static int PreviousPasswordCount { get; set; } = 5;
        }
    }
}
