namespace TradeCompanySearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Company
    {
        public Company(string name)
        {
            this.Name = name;
            this.Articles = new OrderedMultiDictionary<double, Article>(true);
        }

        public void AddArticle(Article arcticle)
        {
            this.Articles.Add(arcticle.Price, arcticle);
        }

        public List<Article> GetArticlesInPriceRange(double from, double to)
        {
            if (this.Articles == null)
            {
                return null;    
            }

            var selectedArticles = this.Articles.Range(from, true, to, true);

            List<Article> articles = new List<Article>();

            foreach (double articlePrice in selectedArticles.Keys)
            {
                foreach (var article in selectedArticles[articlePrice])
                {
                    articles.Add(article);
                }
            }

            return articles;
        }

        public string Name { get; private set; }

        private OrderedMultiDictionary<double, Article> Articles { get; set; }
    }
}