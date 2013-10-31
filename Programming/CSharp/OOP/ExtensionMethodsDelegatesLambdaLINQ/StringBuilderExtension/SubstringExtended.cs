using System;
using System.Linq;
using System.Text;

namespace StringBuilderExtension
{
    public static class SubstringExtended
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length = 0)
        {
            if (length == 0)
            {
                length = str.Length - index;
            }

            StringBuilder strBuilder = new StringBuilder(str.ToString().Substring(index, length));

            return strBuilder;
        }
    }
}
