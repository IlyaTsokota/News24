﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Areas.Admin.ViewModels.ArticleViewModels
{
    public class CreateArticleViewModel : ArticleViewModel
    {
        [Required]
        public HttpPostedFileBase Image { get; set; }


        public List<SelectListItem> CategoriesList { get; set; }
    }
}