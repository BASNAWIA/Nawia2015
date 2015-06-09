using BAS.Nawia.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString)
        {
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().ToTable("User").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IdentityLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IdentityClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRoles");
        }
    }
}
