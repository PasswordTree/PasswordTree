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
        public int CurrentLength { get; set; }
        public bool IsDistinct { get; set; }
        public bool PreviousPasswordEnabled { get; set; }
        public int PreviousPasswordCount { get; set; }
    }
    internal static class Settings
    {
        private static string pathAtt = "app.config";


        internal static class PasswordCatagory
        {
            private static int currentLength = 1;

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
            private static string treePath = "PasswordTree.json";
            public static int MaximumLength { get => string.Concat(Tree.PruneByCheckBoxes().Leaves().Select(leaf => leaf.Text)).Length; }
            public static TreeNode Tree { get; set; }
            public static bool IsDistinct { get; set; } = true;
            public static bool PreviousPasswordEnabled { get; set; } = true;
            public static int PreviousPasswordCount { get; set; } = 5;

            public static async Task<bool> Read()
            {
                if (!File.Exists(treePath)) throw new FileNotFoundException($"File dosen't exist at {treePath}");

                FileInfo fileInfo = new FileInfo(treePath);
                if (fileInfo.Length == 0) throw new FileLoadException($"Can't load file at {treePath}");

                using (StreamReader sr = new StreamReader(treePath))
                {
                    string json = await sr.ReadToEndAsync();
                    TreeNode tree = JsonConvert.DeserializeObject<TreeNode>(json, TreeNodeConverterCustom.SerializerSettings());
                    Tree = tree;
                    return true;
                }
            }

            public static bool Write()
            {
                if (Tree is null) throw new ArgumentNullException("Given Tree is null!");

                string text = JsonConvert.SerializeObject(Tree, TreeNodeConverterCustom.SerializerSettings());
                File.WriteAllText(treePath, text);
                return true;
            }
        }

        public static bool Read()
        {
            var serializer = new XmlSerializer(typeof(SettingsAttributes));
            using (var stream = new FileStream(pathAtt, FileMode.Open))
            {
                var a =serializer.Deserialize(stream);
            }
            return true;
        }

        public static bool Write()
        {
           SettingsAttributes settings = new SettingsAttributes()
           {
               CurrentLength = PasswordCatagory.CurrentLength,
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
