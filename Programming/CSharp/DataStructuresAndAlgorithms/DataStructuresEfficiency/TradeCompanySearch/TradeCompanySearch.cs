namespace TradeCompanySearch
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class TradeCompanySearch
    {
        static Random random = new Random();

        public static double GetRandomDouble(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        static void Main()
        {
            var company = new Company("ACME");
            GenerateArticles(company);
            var articles = company.GetArticlesInPriceRange(500, 1000);
            PrintMatchedArticles(articles);
        }
  
        private static void PrintMatchedArticles(List<Article> articles)
        {
            StringBuilder output = new StringBuilder();

            foreach (var article in articles)
            {
                output.AppendLine(article.ToString());    
            }

            Console.WriteLine(output);
        }
  
        private static void GenerateArticles(Company company)
        {
            Console.WriteLine("Generating random articles, pleas wait...");

            for (int i = 1; i <= 500000; i++)
            {
                string name = "Article #" + i;
                double price = GetRandomDouble(0, 10000);
                int barcode = i * 4 % 2 * 14 / 25;
                company.AddArticle(new Article(name, price, barcode, "ACME"));
            }

            Console.Clear();
        }
    }
}