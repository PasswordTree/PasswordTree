using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PasswordTree.Configuration
{
    internal class TreeNodeConverterCustom : JsonConverter
    {
        public static JsonSerializerSettings SerializerSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new TreeNodeConverterCustom() },
                Formatting = Formatting.Indented
            };
            return settings;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TreeNode node = (TreeNode)value;
            JObject obj = new JObject
            {
                { "Text", node.Text },
                { "Checked", node.Checked },
                { "Nodes", JArray.FromObject(node.Nodes.Cast<TreeNode>().ToList(), serializer) }
            };
            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            TreeNode node = new TreeNode
            {
                Text = (string)obj["Text"],
                Checked = (bool)obj["Checked"]
            };
            foreach (JToken token in obj["Nodes"])
            {
                TreeNode childNode = token.ToObject<TreeNode>(serializer);
                node.Nodes.Add(childNode);
            }
            return node;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TreeNode);
        }
    }

}
