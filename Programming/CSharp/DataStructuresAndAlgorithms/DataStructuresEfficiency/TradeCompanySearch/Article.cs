using System;
using System.Text;

namespace TradeCompanySearch
{
    public class Article: IComparable
    {
        public Article(string title, double price, int barcode = 0, string vendor = "Unknown")
        {
            this.Title = title;
            this.Price = price;
            this.Barcode = barcode;
            this.Vendor = vendor;
        }

        public int Barcode { get; private set; }

        public string Vendor { get; private set; }

        public string Title { get; private set; }

        public double Price { get; private set; }

        public int CompareTo(object obj)
        {
            var article = obj as Article;
            
            if (article == null)
            {
                throw new ArgumentException(string.Format("Cannot compare {0} with {1}", this.GetType(), obj.GetType()));    
            }

            return this.Price.CompareTo(article.Price);
        }

        public override string ToString()
        {
            StringBuilder artricleAsString = new StringBuilder();
            artricleAsString.AppendFormat("Title: {0}\n", this.Title);
            artricleAsString.AppendFormat("Vendor: {0}\n", this.Vendor);
            artricleAsString.AppendFormat("Price: {0:C}\n", this.Price);
            artricleAsString.AppendFormat("Barcode: {0}\n", this.Barcode);

            return artricleAsString.ToString();
        }
    }
}