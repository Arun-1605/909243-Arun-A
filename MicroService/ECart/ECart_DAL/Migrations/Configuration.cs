namespace ECart_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECart_DAL.ECartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECart_DAL.ECartContext context)
        {
            var user1 = new AppUser() { UserName = "Jojo", Password = "Jo@1234" };
            var user2 = new AppUser() { UserName = "Aathma", Password = "At@1234" };
            context.Users.AddOrUpdate(user => user.UserName, user1, user2);

            var product1 = new Product() { ProductName = "Apple Macbook Pro", ProductPrice = 150000, ImageURL="/Images/macbook.jpg" };
            var product2 = new Product() { ProductName = "Dell XPS", ProductPrice = 140000, ImageURL="/Images/dellxps.jpg" };
            context.Products.AddOrUpdate(product => product.ProductName, product1, product2);
        }
    }
}
