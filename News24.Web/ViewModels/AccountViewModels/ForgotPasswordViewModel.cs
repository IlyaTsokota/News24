using System.ComponentModel.DataAnnotations;

namespace News24.Web.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [EmailAddress]
        [Display(Name = "Email")]
        [MinLength(5, ErrorMessage = "Вы ввели слишком мало символов")]
        public string Email { get; set; }
    }
}