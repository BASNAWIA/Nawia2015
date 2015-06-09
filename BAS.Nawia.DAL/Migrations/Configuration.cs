namespace BAS.Nawia.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BAS.Nawia.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<BAS.Nawia.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BAS.Nawia.DAL.DatabaseContext context)
        {
            var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Sample");
            var context2 = new DAL.ApplicationDbContext();
            var UserManager = new UserManager<UserModel>(new UserStore<UserModel>(context2));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context2));
            IdentityResult roleResult;
            roleResult = RoleManager.Create(new IdentityRole("Admin"));
            var user = new UserModel()
            {
                UserName = "admin",
                Email = "admin@nawia.pl",
                EmailConfirmed = true,
                IsConfirmed = true,
                Name = "admin",
                LastName = "admin",
                Title = "dr in¿."
            };
            var result = UserManager.Create(user, "admin123");
            result = UserManager.AddToRole(user.Id, "Admin");
            roleResult = RoleManager.Create(new IdentityRole("Promotor"));
            user = new UserModel()
            {
                UserName = "promotor",
                Email = "promotor@nawia.pl",
                EmailConfirmed = true,
                IsConfirmed = true,
                Name = "promotor",
                LastName = "promotor",
                Title = "dr in¿."
            };
            result = UserManager.Create(user, "promo123");
            result = UserManager.AddToRole(user.Id, "Promotor");
            roleResult = RoleManager.Create(new IdentityRole("User"));
            user = new UserModel()
            {
                UserName = "user",
                Email = "user@nawia.pl",
                EmailConfirmed = true,
                IsConfirmed = true,
                Name = "user",
                LastName = "user",
                Title = "in¿."
            };
            result = UserManager.Create(user, "user123");
            result = UserManager.AddToRole(user.Id, "User");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
