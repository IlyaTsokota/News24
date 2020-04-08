using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using News24.Model;

namespace News24.Data.Identity
{
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(ApplicationContext.ApplicationContext context)
            : base(context)
        {
        }
    }
}
