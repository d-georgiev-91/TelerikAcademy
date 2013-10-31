namespace TriviaGame.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using TriviaGame.Model;
    using Windows.ApplicationModel;

    public class DataPersister
    {
        private static readonly string questionsPath = Path.Combine(Package.Current.InstalledLocation.Path, "Data/questions.xml");

        public static IEnumerable<Category> GetAllCategories()
        {
            XDocument doc = XDocument.Load(questionsPath);
            var root = doc.Root;

            var questions = root.Elements("question");

            var categories = questions.Attributes("category")
                                      .AsQueryable()
                                      .Select(Category.FromXAttribute)
                                      .Distinct();

            return categories;
        }

        public static IEnumerable<Question> GetQuestions(string categoryName = null)
        {
            XDocument doc = XDocument.Load(questionsPath);
            var root = doc.Root;

            var questions = root.Elements("question")
                                .AsQueryable()
                                .Select(Question.FromXElement);

            if (categoryName == null)
            {
                return questions;
            }

            return questions.Where(q => q.Category.Name == categoryName);
        }
    }
}