namespace XSLStyleeSheetCatalog
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    class XSLStyleeSheetCatalog
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../catalogue.xslt");
            xslt.Transform("../../../catalogue.xml", "../../../catalogue.html");
        }
    }
}