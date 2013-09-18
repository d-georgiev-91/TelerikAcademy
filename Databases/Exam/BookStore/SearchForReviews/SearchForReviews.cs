namespace SearchForReviews
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Bookstore.Data;

    static class SearchForReviews
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string fileName = "../../reviews-search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndDocument();
            }
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            foreach (XmlNode query in xmlDoc.SelectNodes("/review-queries/query"))
            {
                string type = query.Attributes["type"].Value;
                IList<Review> reviews;
                if (type == "by-period")
                {
                    DateTime startDate = DateTime.Parse(query.GetChildText("start-date"));
                    DateTime endDate = DateTime.Parse(query.GetChildText("end-date"));
                    reviews = BooksDataAcccessLayer.FindReviewByPeriod(startDate, endDate);
                }
                else
                {
                    string authorName = query.GetChildText("author-name");
                    reviews = BooksDataAcccessLayer.FindReviewByAuthorName(authorName);
                }

                if (reviews.Count > 0)
                {
                    WriteReviews(writer, reviews);
                }
            }
        }

        private static void WriteReviews(
            XmlTextWriter writer, IList<Review> reviews)
        {
            writer.WriteStartElement("result-set");
            if (reviews.Count > 0)
            {
                foreach (var review in reviews)
                {
                    writer.WriteStartElement("review");
                    
                    writer.WriteElementString("date", review.DateOfCreation.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    writer.WriteElementString("content", review.ReviewContent);
                    writer.WriteStartElement("book");
                    
                    writer.WriteElementString("title", review.Book.Title);
                    if (review.Book.Authors.Count > 0)
                    {
                        writer.WriteElementString("authors", string.Join(", ", review.Book.Authors.OrderBy(a => a.AuthorName)));
                    }
                    if (review.Book.ISBN != null)
                    {
                        writer.WriteElementString("isbn", review.Book.ISBN);
                    }
                    if (review.Book.OfficialWebsite != null)
                    {
                        writer.WriteElementString("url", review.Book.OfficialWebsite);
                    }
                    
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private static string GetChildText(
            this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);

            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText.Trim();
        }
    }
}