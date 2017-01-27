using System.ComponentModel.DataAnnotations;

namespace MyTwit.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "Некорректный адрес")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}