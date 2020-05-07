using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace News24.Model
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public byte[] AccountImage { get; set; }

        public override DateTime? LockoutEndDateUtc { get; set; }

        public virtual List<Article> Articles { get; set; } 

    }
}
