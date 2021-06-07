namespace AuthenticationService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AuthenticationService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationService.Models.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationService.Models.AuthContext context)
        {
            var user1 = new ApplicationUser() { UserName = "Arun", Password = "arun@123" };
            var user2 = new ApplicationUser() { UserName = "Thomas", Password = "thomas@123" };
            context.ApplicationUsers.AddOrUpdate(user => user.UserName, user1, user2);
        }
    }
}
