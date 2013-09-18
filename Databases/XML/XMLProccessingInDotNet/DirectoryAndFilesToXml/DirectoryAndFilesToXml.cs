namespace DirectoryAndFilesToXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    class DirectoryAndFilesToXml
    {
        static void Main()
        {
            string folderLocation = @"C:\Windows\System32";
            string outpitFile = "../../../directory-content.xml";
            DirectoryInfo directory = new DirectoryInfo(folderLocation);
            Encoding encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(outpitFile, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                try
                {
                    WriteDirectroyToXml(writer, directory);
                }
                catch (UnauthorizedAccessException)
                {
                }
                writer.WriteEndDocument();
            }

            Console.WriteLine("Document {0} created.", outpitFile);
        }

        private static void WriteDirectroyToXml(XmlTextWriter writer, DirectoryInfo directory)
        {
            writer.WriteStartElement("directory");
            writer.WriteAttributeString("name", directory.Name);

            var subDirectories = directory.GetDirectories().ToList().OrderBy(d => d.Name);
            if (subDirectories == null)
            {
                return;
            }

            foreach (var subDirectory in subDirectories)
            {
                WriteDirectroyToXml(writer, subDirectory);
            }

            var files = directory.GetFiles().OrderBy(f => f.Name);
            if (files != null)
            {
                foreach (var file in files)
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", file.Name);
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
        }
    }
}