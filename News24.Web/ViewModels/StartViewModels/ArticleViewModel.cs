using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News24.Web.ViewModels.StartViewModels
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }

        [Display(Name = "Заголовок")]
        [Required]
        [MaxLength(100, ErrorMessage = "Вы ввели слишком много символов!")]
        [MinLength(2, ErrorMessage = "Вы ввели слишком мало символов!")]
        public string Head { get; set; }
        [Required]
        [Display(Name = "Содержимое")]
        [MaxLength(5000, ErrorMessage = "Вы ввели слишком много символов!")]
        [MinLength(2, ErrorMessage = "Вы ввели слишком мало символов!")]
        public string Body { get; set; }

        public ArticleCategoryViewModel Category { get; set; }

        public ContactInfoViewModel User { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PublicationDate { get; set; }

        public byte[] MainImage { get; set; }
    }
}