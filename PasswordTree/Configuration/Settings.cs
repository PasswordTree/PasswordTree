using Newtonsoft.Json;
using PasswordTree.Password_Generator;
using PasswordTree.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PasswordTree.Configuration.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordTree.Configuration
{
    internal static class Settings
    {
        internal static class PasswordCatagory
        {
            private static int currentLength;

            public static int MaximumLength { get => Password.Tree.PruneByCheckBoxes().Nodes.Count - 1; }
            public static int CurrentLength
            {
                get
                {
                    return currentLength; 
                }
                set
                {
                    if (value < 0 || value > MaximumLength)
                    {
                        throw new ArgumentOutOfRangeException($"Currently, Password Catagory Length can be maximum {MaximumLength}");
                    }
                    currentLength = value;
                }
            }
        }

        internal static class Password
        {
            private static string path = "Password_Tree.json";
            public static int MaximumLength { get => string.Concat(Tree.PruneByCheckBoxes().Leaves().Select(leaf => leaf.Name)).Length; }
            public static TreeNode Tree { get; set; }
            public static bool IsDistinct { get; set; }
            public static bool PreviousPasswordEnabled { get; set; }
            public static int PreviousPasswordCount { get; set; }

            public static async Task<bool> Read()
            {
                if (!File.Exists(path)) throw new FileNotFoundException($"File dosen't exist at {path}");

                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Length == 0) throw new FileLoadException($"Can't load file at {path}");

                using (StreamReader sr = new StreamReader(path))
                {
                    string json = await sr.ReadToEndAsync();
                    TreeNode tree = JsonConvert.DeserializeObject<TreeNode>(json, TreeNodeConverterCustom.SerializerSettings());
                    Tree = tree;
                    return true;
                }
            }

            public static void WriteJson()
            {
                if (Tree is null) throw new ArgumentNullException("Given Tree is null!");

                string text = JsonConvert.SerializeObject(Tree, TreeNodeConverterCustom.SerializerSettings());
                File.WriteAllText(path, text);
            }
        }
    }
}
