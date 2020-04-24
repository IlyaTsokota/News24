using System.ComponentModel.DataAnnotations;

namespace News24.Web.ViewModels
{
    public class ContactInfoViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(\+)?(38)?0([- _():=+]?\d){9}$")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Электронный адрес")]
        [EmailAddress]
        public string Email { get; set; }

        public byte[] Image { get; set; }
    }
}