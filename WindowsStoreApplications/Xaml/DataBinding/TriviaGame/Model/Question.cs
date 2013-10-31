namespace TriviaGame.Model
{
    using System;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public class Question
    {
        public string Text { get; set; }

        public Category Category { get; set; }

        public static Expression<Func<XElement, Question>> FromXElement
        {
            get
            {
                return q => new Question()
                {
                    Text = q.Element("text").Value,
                    Category = new Category()
                    {
                        Name = q.Attribute("category").Value,
                    }
                };
            }
        }
    }
}