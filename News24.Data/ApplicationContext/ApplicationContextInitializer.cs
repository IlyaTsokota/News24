using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using News24.Data.Identity;
using News24.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace News24.Data.ApplicationContext
{
    public class ApplicationContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole("User"),
                new IdentityRole("Manager"),
                new IdentityRole("Admin")
            };
            roles.ForEach(role => context.Roles.Add(role));
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User>(context), null, null,null);
            var user = new User { Email = "admin@gmail.com", UserName = "admin@gmail.com", FirstName = "Admin", LastName = "Admin", PhoneNumber = "+380990482560" };
     
            manager.Create(user, "Admin1");
            manager.AddToRole(user.Id, "Admin");
            base.Seed(context);
        }
    }
}