using System.ComponentModel.DataAnnotations;

namespace UserSkill.Models
{
    public class EditModel
    {
        public string Email { get; set; }
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string UserName { get; set; }
    }
}