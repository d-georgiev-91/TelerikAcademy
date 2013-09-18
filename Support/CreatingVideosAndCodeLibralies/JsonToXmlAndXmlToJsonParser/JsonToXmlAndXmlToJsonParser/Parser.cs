namespace JsonToXmlAndXmlToJsonParser
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Xml;


    // Creating the static class
    public static class Parser
    {
        // Method to Parse XML to JSON
        public static void ConvertXmlToJson(string xmlFilePath, string jsonFilePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFilePath);
            XmlNode rootNode = xmlDocument.DocumentElement;
            var jsonString = JsonConvert.SerializeXmlNode(rootNode, Newtonsoft.Json.Formatting.Indented, true);
            jsonString = jsonString.Replace("\"@", "\"");

            using (StreamWriter jsonFileStream = new StreamWriter(jsonFilePath))
            {
                jsonFileStream.Write(jsonString);
            }
        }

        // Method to Parse JSON to XML
        public static void ConvertJsonToXml(string jsonFilePath, string xmlFilePath, string rootNodeName)
        {
            var jsonString = File.ReadAllText(jsonFilePath);
            var xmlDocument = JsonConvert.DeserializeXmlNode(jsonString, rootNodeName);
            var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", null, null);
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.Save(xmlFilePath);
        }
    }
}