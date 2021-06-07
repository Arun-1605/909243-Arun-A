namespace ProductsCatalogService.Migrations
{
    using ProductsCatalogService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsCatalogService.Models.CatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsCatalogService.Models.CatalogContext context)
        {
            var product1 = new Product() { ProductName = "Apple Macbook Pro", ProductPrice = 150000, ProductImageUrl = "/Images/Images/macbook.jpg" };
            var product2 = new Product() { ProductName = "Dell XPS", ProductPrice = 140000, ProductImageUrl = "/Images/Images/dellxps.jpg" };
            var product3 = new Product() { ProductName = "Asus", ProductPrice = 60000, ProductImageUrl = "/Images/Images/macbook.jpg" };
            var product4 = new Product() { ProductName = "Lenovo Zenbook", ProductPrice = 800000, ProductImageUrl = "/Images/Images/dellxps.jpg" };
            var product5 = new Product() { ProductName = "HP", ProductPrice = 90000, ProductImageUrl = "/Images/Images/macbook.jpg" };
            var product6 = new Product() { ProductName = "Dell", ProductPrice = 90000, ProductImageUrl = "/Images/Images/dellxps.jpg" };

            context.Products.AddOrUpdate(product => product.ProductName, product1, product2, product3, product4, product5, product6);
        }
    }
}
