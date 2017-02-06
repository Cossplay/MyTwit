using System.ComponentModel.DataAnnotations;

namespace MyTwit.DAL.Entities
{
    public class User
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "Некорректный адрес")]
        //[Remote("IsExist", "Registration", ErrorMessage = "Такой логин уже существует")]
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