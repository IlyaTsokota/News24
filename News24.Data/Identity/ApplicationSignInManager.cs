using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using News24.Model;

namespace News24.Data.Identity
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }
    }
}
