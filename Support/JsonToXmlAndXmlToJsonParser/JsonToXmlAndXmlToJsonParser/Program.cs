namespace JsonToXmlAndXmlToJsonParser
{
    class Program
    {
        static void Main()
        {
            Parser.ConvertXmlToJson("../../sample.xml", "../../generated-sample.json");
            Parser.ConvertJsonToXml("../../sample.json", "../../generated-sample.xml", "catalog");
        }
    }
}
