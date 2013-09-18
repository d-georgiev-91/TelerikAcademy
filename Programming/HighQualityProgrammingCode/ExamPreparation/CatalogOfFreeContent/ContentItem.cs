namespace CatalogOfFreeContent
{
    using System;

    public class ContentItem : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        private string url;

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ContentItemType Type { get; set; }

        public string TextRepresentation { get; set; }

        public ContentItem(ContentItemType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)Acpi.Title];
            this.Author = commandParams[(int)Acpi.Author];
            this.Size = long.Parse(commandParams[(int)Acpi.Size]);
            this.Url = commandParams[(int)Acpi.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;

            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }
              
            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}", 
                this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);
            return output;
        }
    }
}