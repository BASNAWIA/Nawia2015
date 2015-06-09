using BAS.Nawia.DAL.Entities;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL
{
    public class DatabaseContext : DataContext
    {
        public DatabaseContext() : base(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Stage>();
            modelBuilder.Entity<Subject>();
            modelBuilder.Entity<SubjectScope>();
            modelBuilder.Entity<Thesis>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<IdentityClaim>();
            modelBuilder.Entity<IdentityLogin>();
            modelBuilder.Entity<IdentityRoles>();
            modelBuilder.Entity<UserRoles>();
        }
    }
}
