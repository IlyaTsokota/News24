using News24.Web.Models;
using System.Collections.Generic;

namespace News24.Web.Areas.Admin.ViewModels.CategoryViewModels
{
    public class IndexCategoryViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public Pager Pager { get; set; }
    }
}