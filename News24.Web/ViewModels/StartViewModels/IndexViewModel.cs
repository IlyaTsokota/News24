using News24.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News24.Web.ViewModels.StartViewModels
{
    public class IndexViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        public List<ArticleViewModel> LastArticles { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        public Pager Pager { get; set; }
        public string Category { get; set; }
    }
}