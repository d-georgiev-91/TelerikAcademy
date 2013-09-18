using System;
using System.Linq;
using System.Xml;

namespace BookmarksImporter
{
    static class BookmarkImporter
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../items.xml");
            string xPathQuery = "/items/item[@type='beer']";

            XmlNodeList beersList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode boomakrsNode in beersList)
            {
                string username = boomakrsNode.SelectSingleNode("username").InnerText;
                Console.WriteLine(username);
                string title = boomakrsNode.SelectSingleNode("title").InnerText;
                Console.WriteLine(title);
                string url = boomakrsNode.SelectSingleNode("url").InnerText;
                Console.WriteLine(url);
                string notes = boomakrsNode.SelectSingleNode("notes").InnerText;
                Console.WriteLine(notes);
                string allTags = boomakrsNode.SelectSingleNode("tag").InnerText;
                Console.WriteLine(allTags);
                Console.WriteLine(allTags);
                string[] tags = allTags.Split(',');

                for (int i = 0; i < tags.Length; i++)
                {
                    tags[i] = tags[i].Trim();
                }

                AddBookmark(username, title, url, tags, notes);
            }
        }

        private static string GetChildText(this XmlNode node, string tagname)
        {
        }

        private static void AddBookmark(string username, string title, string url, string[] tags, string notes)
        {
            Console.WriteLine("{0}{1}{2}{3}{4}", username, title, url, string.Join(", ", tags), notes);
        }
    }
}