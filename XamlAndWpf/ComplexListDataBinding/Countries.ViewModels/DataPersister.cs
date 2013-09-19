namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    public class DataPersister
    {
        public static IEnumerable<CountryViewModel> GetContriesFromXml(string xmlPath)
        {
            XDocument document = XDocument.Load(xmlPath);
            var root = document.Root;

            var countries = from e in root.Elements("country")
                            select new CountryViewModel()
                            {
                                Name = e.Element("name").Value,
                                NationalFlagPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), e.Element("national-flag").Value),
                                Language = e.Element("language").Value,
                                Towns = e.Element("towns")
                                         .Elements("town")
                                         .AsQueryable()
                                         .Select(TownViewModel.FromXElement)
                            };

            return countries;
        }
    }
}