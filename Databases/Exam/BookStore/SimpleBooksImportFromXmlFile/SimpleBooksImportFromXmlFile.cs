namespace SimpleBooksImportFromXmlFile
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Transactions;
    using System.Xml;
    using Bookstore.Data;

    public static class SimpleBooksImportFromXmlFile
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            TransactionScope tran = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });
            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../simple-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                
                foreach (XmlNode bookNode in booksList)
                {
                    string author = bookNode.GetChildText("author");
                    string title = bookNode.GetChildText("title");
                    string isbn = bookNode.GetChildText("isbn");
                    string price = bookNode.GetChildText("price");
                    string webSite = bookNode.GetChildText("web-site");
                    BooksDataAcccessLayer.AddBook(author, title, isbn, price, webSite);
                }

                tran.Complete();
            }
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);

            if (childNode == null)
            {
                return null;
            }

            var innterText = childNode.InnerText.Trim();

            if (string.IsNullOrEmpty(innterText))
            {
                throw new ArgumentException("<" + tagName + "> is empty");
            }

            return innterText;
        }
    }
}