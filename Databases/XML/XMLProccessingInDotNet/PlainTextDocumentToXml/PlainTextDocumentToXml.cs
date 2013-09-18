namespace PlainTextDocumentToXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    class PlainTextDocumentToXml
    {
        static void Main()
        {
            string addressesDirectoryPath = "../../../addresses.txt";

            var filestream = new FileStream(addressesDirectoryPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);
            var fileReader = new StreamReader(filestream, Encoding.UTF8, true, 128);
            XElement addressesXml = new XElement("people-addresses");
            string name = "";
            string address = "";

            using (fileReader)
            {
                string line;
                int count = 1;
                while ((line = fileReader.ReadLine()) != null)
                {
                    if (count % 3 == 1)
                    {
                        name = line;
                    }
                    else if (count % 3 == 2)
                    {
                        address = line;
                    }
                    else
                    {
                        var phone = line;

                        addressesXml.Add(new XElement("person",
                            new XElement("name", name),
                            new XElement("address", address),
                            new XElement("phone", phone)));
                    }
                    count++;
                }
            }

            addressesXml.Save("../../../adresses.xml");
        }
    }
}