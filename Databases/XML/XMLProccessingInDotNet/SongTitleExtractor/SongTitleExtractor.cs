namespace SongTitleExtractor
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    static class SongTitleExtractor
    {
        static void Main()
        {
            WithoutXDocumentAndLinq();
            Console.WriteLine();
            WithXDocumentAndLinq();
        }

        private static void WithXDocumentAndLinq()
        {
            XDocument catalogue = XDocument.Load("../../../catalogue.xml");
            var songs =
                       from song in catalogue.Descendants("song")
                       select new
                       {
                           Title = song.Element("title").Value,
                           Artist = song.Parent.Element("artist").Value
                       };
            foreach (var song in songs)
            {
                Console.WriteLine("\"{0}\" by {1}", song.Title, song.Artist);
            }
        }
  
        private static void WithoutXDocumentAndLinq()
        {
            Console.WriteLine("The song in catalogue are: ");

            using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
            {
                string artist = null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "artist")
                        {
                            artist = reader.ReadElementString();
                        }
                          
                        if (reader.Name == "title")
                        {
                            Console.WriteLine("\"{0}\" by {1}", reader.ReadElementString(), artist);
                        }
                    }
                }
            }
        }
    }
}