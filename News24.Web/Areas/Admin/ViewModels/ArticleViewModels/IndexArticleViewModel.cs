
using News24.Web.Models;
using System.Collections.Generic;

namespace News24.Web.Areas.Admin.ViewModels.ArticleViewModels
{
    public class IndexArticleViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public Pager Pager { get; set; }
    }
}