using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        public int? NumberOfPages
        {
            get;
            set;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public bool IsEncrypted
        {
            get;
            protected set;
        }

        public string Version
        {
            get;
            protected set;
        }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
