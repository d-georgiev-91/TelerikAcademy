using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {

        public int? NumberOfRows
        {
            get;
            set;
        }

        public int? NumberOfColumns
        {
            get;
            set;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.NumberOfRows = int.Parse(value);
            }
            else if (key == "cols" )
            {
                this.NumberOfColumns = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
            base.SaveAllProperties(output);
        }
    }
}
