namespace ProductCatalogClient.ProductsViewModels
{
    using System;
    using System.Linq;
    using ProductsCatalogEntities;

    public class ProductViewModel
    {
        public int ModelNumber { get; set; }

        public string ModelName { get; set; }

        public string Category { get; set; }

        public decimal UnitCost { get; set; }

        public string Description { get; set; }

        public static ProductViewModel GetProduct(int id)
        {
            var productCatalogEntities = new ProductsCatalogEntities();

            var productEntity = productCatalogEntities.Products
                .Where(p => p.ProductId == id).FirstOrDefault();

            if (productEntity == null)
            {
                return null;
            }

            var product = new ProductViewModel()
            {
                ModelName = productEntity.ModelName,
                ModelNumber = productEntity.ModelNumber,
                Category = productEntity.Category.Name,
                UnitCost = productEntity.UnitCost,
                Description = productEntity.Description
            };

            return product;
        }
    }
}
