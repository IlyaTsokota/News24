using Microsoft.AspNet.Identity.EntityFramework;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News24.Model
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        
        public string LastName { get; set; }

        public byte[] AccountImage { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
