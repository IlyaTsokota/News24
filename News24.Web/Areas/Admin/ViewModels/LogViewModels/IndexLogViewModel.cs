using News24.Web.Models;
using System.Collections.Generic;

namespace News24.Web.Areas.Admin.ViewModels.LogViewModels
{
    public class IndexLogViewModel
    {
        public List<LogViewModel> Logs { get; set; }

        public Pager Pager { get; set; }
    }
}