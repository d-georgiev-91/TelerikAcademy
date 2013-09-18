namespace ExtractAlbumPricesPublishedFiveYearsAgo
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class ExtractAlbumPricesPublishedFiveYearsAgo
    {
        static void Main()
        {
            WithoutLinq();
            Console.WriteLine();
            WithLinq();
        }
  
        private static void WithLinq()
        {
            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");

            var albums =
                        from album in xmlDoc.Descendants("album")
                        where int.Parse(album.Element("year").Value) < DateTime.Now.Year - 5
                        select new
                        {
                            Title = album.Element("name").Value,
                            Price = decimal.Parse(album.Element("price").Value)
                        };

            foreach (var album in albums)
            {
                Console.WriteLine("{0} -> {1:C}", album.Title, album.Price);
            }
        }
  
        private static void WithoutLinq()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalogue.xml");

            string xPathQuery = "/catalogue/album[year<" + (DateTime.Now.Year - 5) + "]";
            XmlNodeList priceList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode priceNode in priceList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                decimal price = decimal.Parse(priceNode.SelectSingleNode("price").InnerText);
                Console.WriteLine("{0} -> {1:C}", albumName, price);
            }
        }
    }
}