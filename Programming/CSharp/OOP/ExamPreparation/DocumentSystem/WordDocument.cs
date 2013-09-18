using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem1
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public int? NumberOfCharacters
        {
            get;
            set;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.NumberOfCharacters = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("characters", this.NumberOfCharacters));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
