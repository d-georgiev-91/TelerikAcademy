namespace SimpleSearchForBooks
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml;
    using Bookstore.Data;

    static class SimpleSearchForBooks
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string xPathQuery = "/query";

            XmlNodeList query = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in query)
            {
                string author = node.GetChildText("author");
                string title = node.GetChildText("title");
                string isbn = node.GetChildText("isbn");
                IList<Book> books = BooksDataAcccessLayer.FindBookByAuthorTitleAndIsbn(author, title, isbn);
                if (books.Count > 0)
                {
                    Console.WriteLine("{0} books found:", books.Count);
                    foreach (var book in books)
                    {
                        Console.Write("{0} --> ", book.Title);

                        if (book.Reviews.Count > 0)
                        {
                            Console.WriteLine("{0} reviews", book.Reviews.Count);
                        }
                        else
                        {
                            Console.WriteLine("no reviews");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
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