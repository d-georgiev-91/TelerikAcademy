namespace ComplexBooksImportFromXmlFile
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Transactions;
    using System.Xml;
    using Bookstore.Data;

    static class ComplexBooksImportFromXmlFile
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
           
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode bookNode in booksList)
            {
                XmlNode authorsNode = bookNode.SelectSingleNode("authors");
                XmlNode reviewsNode = bookNode.SelectSingleNode("reviews");
                List<string> authorNames = authorsNode.GetChildsAsText("author");
                List<CustomReview> reviews = reviewsNode.GetChildsAsRewiev("review");
                string title = bookNode.GetChildText("title");
                string isbn = bookNode.GetChildText("isbn");
                string price = bookNode.GetChildText("price");
                string webSite = bookNode.GetChildText("web-site");
                TransactionScope tran = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });
                using (tran)
                {
                    BooksDataAcccessLayer.AddBook(authorNames, title, isbn, price, webSite, reviews);
                    tran.Complete();
                }
            }
        }
        
        private static List<string> GetChildsAsText(this XmlNode node, string tagName)
        {
            if (node == null)
            {
                return null;
            }

            if (!node.HasChildNodes)
            {
                throw new NullReferenceException("<" + node.Name + "> is empty");
            }
            
            XmlNodeList childNodes = node.SelectNodes(tagName);

            List<string> nodesText = new List<string>();

            foreach (XmlNode childNode in childNodes)
            {
                nodesText.Add(childNode.InnerText.Trim());
            }

            return nodesText;
        }

        private static List<CustomReview> GetChildsAsRewiev(this XmlNode node, string tagName)
        {
            if (node == null)
            {
                return null;
            }

            if (!node.HasChildNodes)
            {
                throw new NullReferenceException("<" + node.Name + "> is empty");
            }

            XmlNodeList childNodes = node.SelectNodes(tagName);

            List<CustomReview> reviews = new List<CustomReview>();

            foreach (XmlNode childNode in childNodes)
            {
                string authorName = GetAttributeValue(childNode, "author");
                string dateAsString = GetAttributeValue(childNode, "date");
                DateTime? date;

                if (dateAsString != null)
                {
                    date = DateTime.Parse(dateAsString);
                }
                else
                {
                    date = null;
                }

                var review = new CustomReview(authorName,childNode.InnerText.Trim(), date);
                reviews.Add(review);
            }

            return reviews;
        }
  
        private static string GetAttributeValue(XmlNode childNode, string attributeName)
        {
            if (childNode.Attributes[attributeName] == null)
            {
                return null;
            }

            return childNode.Attributes[attributeName].Value;
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);

            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText.Trim();
        }
    }
}