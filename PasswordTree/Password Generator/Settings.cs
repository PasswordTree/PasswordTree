using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordTree.Password_Generator
{

    internal static class Settings
    {
        internal static class PasswordCatagory
        {
            public static int Maximum { get; set; }
            public static int Count { get; set; }
        }

        internal static class Password
        {
            public static int Maximum { get; set; }
            public static int Count { get; set; }
            public static bool IsDistinct { get; set; }
        }
    }
}
