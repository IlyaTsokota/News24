using News24.Web.Models;
using System.Collections.Generic;

namespace News24.Web.Areas.Admin.ViewModels.UserViewModels
{
    public class IndexUserViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public Pager Pager { get; set; }

        public bool Blocked { get; set; }
    }
}