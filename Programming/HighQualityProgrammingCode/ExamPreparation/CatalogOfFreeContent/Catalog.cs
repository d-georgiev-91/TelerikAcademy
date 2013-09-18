namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog(MultiDictionary<string, IContent> url, OrderedMultiDictionary<string, IContent> title)
        {
            this.url = url;
            this.title = title;
        }

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList =
                                                 from c in this.title[title]
                                                 select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            int updateItems = 0;

            List<IContent> contentToList = this.url[old].ToList();

            foreach (ContentItem content in contentToList)
            {
                this.title.Remove(content.Title, content);
                updateItems++; //increase updatedElements
            }
            this.url.Remove(old);

            foreach (IContent content in contentToList)
            {
                content.Url = newUrl;
            }

            //again
            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.Url, content);
            }

            return updateItems;
        }

        public int Count
        {
            get
            {
                return this.title.KeyValuePairs.Count;
            }
        }
    }
}