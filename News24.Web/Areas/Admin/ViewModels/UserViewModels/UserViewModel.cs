using System.ComponentModel.DataAnnotations;

namespace News24.Web.Areas.Admin.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name="Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Залокирован")]
        public bool IsBlocked { get; set; }
    }
}