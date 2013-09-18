namespace AlbumsToXml
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml;

    class AlbumsToXml
    {
        static void Main()
        {
            string albumsLocation = "../../../albums.xml";
            Encoding encoding = Encoding.UTF8;
            XmlTextWriter writer = new XmlTextWriter(albumsLocation, encoding);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                string name = string.Empty;
                using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "name"))
                        {
                            name = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                                 (reader.Name == "artist"))
                        {
                            string artist = reader.ReadElementString();
                            WriteAlbum(writer, name, artist);
                        }
                    }
                }

                writer.WriteEndDocument();
            }
        }

        private static void WriteAlbum(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}