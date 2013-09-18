namespace ArticlesSearch
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    [JsonObject]
    public class ArticlesCollection : IEnumerable
    {
        [JsonProperty("articles")]
        public IEnumerable<Article> Articles { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Articles.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return Articles.Count();
            }
        }
    }
}