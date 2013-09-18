namespace Countries.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public class TownViewModel
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public static Expression<Func<XElement, TownViewModel>> FromXElement
        {
            get
            {
                return e =>
                    new TownViewModel()
                    {
                        Name = e.Element("name").Value,
                        Population = int.Parse(e.Element("population").Value)
                    };
            }
        }
    }
}
