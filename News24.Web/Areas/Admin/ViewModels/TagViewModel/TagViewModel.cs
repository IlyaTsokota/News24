using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News24.Web.Areas.Admin.ViewModels.TagViewModel
{
    public class TagViewModel
    {
        public int TagId { get; set; }

        [Required(ErrorMessage ="Поле не должно быть пустым")]
        [Display(Name = "Теги")]
        public string Value { get; set; }

        public int ArticleId { get; set; }
    }
}