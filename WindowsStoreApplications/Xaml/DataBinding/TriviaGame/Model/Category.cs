namespace TriviaGame.Model
{
    using System;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public class Category
    {
        public string Name { get; set; }

        public static Expression<Func<XAttribute, Category>> FromXAttribute
        {
            get
            {
                return c =>
                new Category()
                {
                    Name = c.Value,
                };
            }
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;

            if (category == null)
            {
                return false;
            }

            return this.Name == category.Name;
        }
    }
}