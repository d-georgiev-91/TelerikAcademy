namespace ExtractArtistAndAlbumsCountFromCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class ExtractArtistAndAlbumsCountFromCatalogue
    {
        static void Main()
        {
            ExtractingWithoutXPath();
            ExtractingWithXPath();
        }

        private static void ExtractingWithXPath()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");
            XmlNode rootNode = catalogue.DocumentElement;
            Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();
            string xPathQuery = "catalogue/album";
            XmlNodeList artistList = catalogue.SelectNodes(xPathQuery);

            foreach (XmlNode artist in artistList)
            {
                string artistName = artist.SelectSingleNode("artist").InnerText;

                if (artistsAlbums.ContainsKey(artistName))
                {
                    artistsAlbums[artistName]++;
                }
                else
                {
                    artistsAlbums.Add(artistName, 1);
                }
            }

            foreach (var artistAlbums in artistsAlbums)
            {
                Console.WriteLine("{0} => {1} albums", artistAlbums.Key, artistAlbums.Value);
            }
        }

        private static void ExtractingWithoutXPath()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("..  /../../catalogue.xml");
            XmlNode rootNode = catalogue.DocumentElement;
            Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artist = node["artist"].InnerText;

                if (artistsAlbums.ContainsKey(artist))
                {
                    artistsAlbums[artist]++;
                }
                else
                {
                    artistsAlbums.Add(artist, 1);
                }
            }

            foreach (var artistAlbums in artistsAlbums)
            {
                Console.WriteLine("{0} => {1} albums", artistAlbums.Key, artistAlbums.Value);
            }
        }
    }
}