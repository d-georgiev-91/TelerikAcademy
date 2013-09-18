namespace DirectoryAndFilesToXmlXdocumentXElementXAttribute
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    class DirectoryAndFilesToXmlXdocumentXElementXAttribute
    {
        static void Main()
        {
            string folderLocation = "../../../../";
            DirectoryInfo directory = new DirectoryInfo(folderLocation);
            var xmlInfo = new XElement("directories");
            xmlInfo.Add(DirectoryToXml(directory));
            var xmlDocument = new XDocument(xmlInfo);

            xmlDocument.Save("../../../directory-contet-X.xml");
        }

        private static XElement DirectoryToXml(DirectoryInfo directory)
        {
            var xmlInfo = new XElement("directory", new XAttribute("name", directory.Name));

            var files = directory.GetFiles();
            if (files != null)
            {
                foreach (var file in files)
                {
                    xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
                }
            }

            var subDirectories = directory.GetDirectories().ToList().OrderBy(d => d.Name);

            if (subDirectories != null)
            {
                foreach (var subDirectory in subDirectories)
                {
                    xmlInfo.Add(DirectoryToXml(subDirectory));
                }
            }

            return xmlInfo;
        }
    }
}