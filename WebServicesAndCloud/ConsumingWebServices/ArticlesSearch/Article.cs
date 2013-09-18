namespace ArticlesSearch
{
    using System.Text;
    using Newtonsoft.Json;

    [JsonObject]
    public class Article
    {
        public Article(string title, string url)
        {
            this.Title = title;
            this.Url = url;
        }

        public override string ToString()
        {
            var article = new StringBuilder();
            article.AppendFormat("Title: {0}\nURL: {1}", this.Title, this.Url);
            
            return article.ToString();
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}