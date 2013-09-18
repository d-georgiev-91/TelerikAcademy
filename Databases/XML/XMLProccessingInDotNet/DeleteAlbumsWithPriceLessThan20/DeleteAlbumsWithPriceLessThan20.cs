namespace DeleteAlbumsWithPriceLessThan20
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml;
    
    class DeleteAlbumsWithPriceLessThan20
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../catalogue.xml");

            foreach (XmlNode node in catalogue.DocumentElement)
            {
                if (decimal.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }

            catalogue.Save("../../../catalogueWithCheaperAlbum.xml");
        }
    }
}