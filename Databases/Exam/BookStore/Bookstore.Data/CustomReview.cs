namespace ComplexBooksImportFromXmlFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomReview
    {
        public string AuthorName { get; set; }

        public string Text { get; set; }

        public DateTime? Date { get; set; }

        public CustomReview(string authorName, string text, DateTime? date)
        {
            this.AuthorName = authorName;
            this.Text = text;
            this.Date = date;
        }
    }
}