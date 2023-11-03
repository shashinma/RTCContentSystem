using System.ComponentModel.DataAnnotations;

namespace POSTerminal.ViewModels;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("[a-z0-9._%+-]+@rtc.ru")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; }
}