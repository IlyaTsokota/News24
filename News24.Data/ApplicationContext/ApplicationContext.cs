using Microsoft.AspNet.Identity.EntityFramework;
using News24.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace News24.Data.ApplicationContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {

        public ApplicationContext()
           : base("name=News24")
        { }

        static ApplicationContext()
        {
            Database.SetInitializer(new ApplicationContextInitializer());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Log> Logs { get; set; }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
