using Microsoft.AspNet.Identity.EntityFramework;

namespace News24.Data.Identity
{
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationContext.ApplicationContext context) : base(context)
        {

        }
    }
}
