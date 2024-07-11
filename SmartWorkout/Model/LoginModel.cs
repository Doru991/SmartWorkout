using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.Model
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not correctly formatted")]
        public string? Email { get; set; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string? Password { get; set; } = null!;
    }
}
