using System.ComponentModel.DataAnnotations;

namespace News24.Web.Areas.Admin.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name="Категория")]
        [MaxLength(50, ErrorMessage ="Вы ввели слишком много символов!")]
        [MinLength(2,ErrorMessage ="Вы ввели слишком мало символов!")]
        public string Name { get; set; }
    }
}