namespace CatalogOfFreeContentTests
{
    using System;
    using System.Linq;
    using CatalogOfFreeContent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ICatalogTests
    {
        [TestMethod]
        public void AddAndFindItemTest()
        {
            Catalog catalog = new Catalog();
            ContentItem item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item);
            Assert.AreEqual(1, catalog.Count);

            var result = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(1, result.Count());
            Assert.AreSame(item, result.First());
        }

        [TestMethod]
        public void AddDuplicatedItemsTest()
        {
            Catalog catalog = new Catalog();
            ContentItem item1 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item1);

            ContentItem item2 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            catalog.Add(item2);

            Assert.AreEqual(2, catalog.Count);

        }
    }
}