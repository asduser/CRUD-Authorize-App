using System.ComponentModel.DataAnnotations;

namespace UserSkill.Models
{
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}