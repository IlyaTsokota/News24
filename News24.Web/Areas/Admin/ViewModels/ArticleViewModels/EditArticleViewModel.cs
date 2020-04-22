using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Areas.Admin.ViewModels.ArticleViewModels
{
    public class EditArticleViewModel : ArticleViewModel
    {

        public HttpPostedFileBase Image { get; set; }


        public List<SelectListItem> CategoriesList { get; set; }
    }
}