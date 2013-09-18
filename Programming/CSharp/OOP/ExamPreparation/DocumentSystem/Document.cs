using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {

        public string Name
        {
            get;
            protected set;
        }

        public string Content
        {
            get;
            protected set;
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new ArgumentException("Key '" + key + "' not found");
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            StringBuilder propertiesToString = new StringBuilder();
            properties.Sort((a, b) => a.Key.CompareTo(b.Key));
            propertiesToString.Append(this.GetType().Name);
            propertiesToString.Append("[");
            bool isFirst = true;
            foreach (var prop in properties)
            {
                if (prop.Value != null)
                {
                    if (!isFirst)
                    {
                        propertiesToString.Append(";");
                    }
                    propertiesToString.AppendFormat("{0}={1}", prop.Key, prop.Value);
                    isFirst = false;
                }
            }
            propertiesToString.Append("]");
            return propertiesToString.ToString();
        }
    }
}
