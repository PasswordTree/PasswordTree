using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PasswordTree.Password_Generator;
using PasswordTree.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static PasswordTree.Configuration.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordTree.Configuration
{
    public class SettingsAttributes
    {
        public int PasswordCatagoryCurrentLength { get; set; }
        public int PasswordCurrentLength { get; set; }
        public bool IsDistinct { get; set; }
        public bool PreviousPasswordEnabled { get; set; }
        public int PreviousPasswordCount { get; set; }
    }
    internal static class Settings
    {
        private static string pathDefault = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\PasswordTree\\";
        private static string pathAtt = pathDefault + "app.config";


        internal static class PasswordCatagory
        {
            private static int currentLength = 1;

            public static int MaximumLength { get => GetMaxCatLen(Password.Tree); }
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
            public static int GetMaxCatLen(TreeNode tree)
            {
                return tree.PruneByCheckBoxes().Nodes.Count - 1;
            }
        }

        internal static class Password
        {
            private static string pathTree = pathDefault + "Tree.json";
            public static int MaximumLength { get => string.Concat(Tree.PruneByCheckBoxes().Leaves().Select(leaf => leaf.Text)).Length; }
            public static int CurrentLength { get; set; } = 20;
            public static TreeNode Tree { get; set; } = Data.DefaultTree();
            public static bool IsDistinct { get; set; } = true;
            public static bool PreviousPasswordEnabled { get; set; } = true;
            public static int PreviousPasswordCount { get; set; } = 5;

            public static async Task<bool> Read()
            {
                if (!File.Exists(pathTree)) throw new FileNotFoundException($"File dosen't exist");

                FileInfo fileInfo = new FileInfo(pathTree);
                if (fileInfo.Length == 0) throw new FileLoadException($"Can't load file");

                using (StreamReader sr = new StreamReader(pathTree))
                {
                    string json = await sr.ReadToEndAsync();
                    TreeNode tree = JsonConvert.DeserializeObject<TreeNode>(json, TreeNodeConverterCustom.SerializerSettings());
                    Tree = tree;
                    return true;
                }
            }

            public static bool Write()
            {
                Directory.CreateDirectory(pathTree);
                if (Tree is null) throw new ArgumentNullException("Given Tree is null!");

                // Grant write permission to the current user
                DirectorySecurity security = Directory.GetAccessControl(pathTree);
                security.AddAccessRule(new FileSystemAccessRule(Environment.UserName,
                    FileSystemRights.Write | FileSystemRights.Modify,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                Directory.SetAccessControl(pathTree, security);

                string text = JsonConvert.SerializeObject(Tree, TreeNodeConverterCustom.SerializerSettings());
                File.WriteAllText(pathTree, text);
                return true;
            }
        }

        public static bool Read()
        {
            if (!File.Exists(pathAtt)) throw new FileNotFoundException($"File dosen't exist");

            var serializer = new XmlSerializer(typeof(SettingsAttributes));
            using (var stream = new FileStream(pathAtt, FileMode.Open))
            {
                SettingsAttributes a = (SettingsAttributes)serializer.Deserialize(stream);

                PasswordCatagory.CurrentLength = a.PasswordCatagoryCurrentLength;
                Password.CurrentLength = a.PasswordCurrentLength;
                Password.IsDistinct = a.IsDistinct;
                Password.PreviousPasswordEnabled = a.PreviousPasswordEnabled;
                Password.PreviousPasswordCount = a.PreviousPasswordCount;
            }
            return true;
        }

        public static bool Write()
        {
            Directory.CreateDirectory(pathAtt);
            SettingsAttributes settings = new SettingsAttributes()
            {
                PasswordCatagoryCurrentLength = PasswordCatagory.CurrentLength,
                PasswordCurrentLength = Password.CurrentLength,
                IsDistinct = Password.IsDistinct,
                PreviousPasswordEnabled = Password.PreviousPasswordEnabled,
                PreviousPasswordCount = Password.PreviousPasswordCount
            };

            var serializer = new XmlSerializer(typeof(SettingsAttributes));
            using (var stream = new FileStream(pathAtt, FileMode.Create))
            {
                serializer.Serialize(stream, settings);
            }
            return true;
        }
    }
    
}
