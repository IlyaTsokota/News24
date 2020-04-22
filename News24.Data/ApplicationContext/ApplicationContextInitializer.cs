using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using News24.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace News24.Data.ApplicationContext
{
    public class ApplicationContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {

            var roles = new List<IdentityRole>
            {
                new IdentityRole("User"),
                new IdentityRole("Admin")
            };
            roles.ForEach(role => context.Roles.Add(role));

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var admin = new User { Email = "gamestore@gmail.com", UserName = "gamestore@gmail.com", FirstName = "Илья", LastName = "Цокота", PhoneNumber = "+380990482560" };
            string password = "13Avtobusus";
            var result = manager.Create(admin, password);
            if (result.Succeeded)
            {
                manager.AddToRole(admin.Id, "Admin");
            }
            base.Seed(context);
        }
    }
}