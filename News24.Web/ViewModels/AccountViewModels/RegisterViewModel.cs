
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace News24.Web.ViewModels.AccountViewModels
{
    public class RegisterViewModel : ContactInfoViewModel
    {
        [Required]
        public HttpPostedFileBase AccountImage { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }



        [Required]
        [DisplayName("Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}