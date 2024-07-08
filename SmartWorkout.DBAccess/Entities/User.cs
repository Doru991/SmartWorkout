using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+", ErrorMessage = "The name is written incorrectly")]
        public string Name { get; set; } = null!;
        [Required]
        [RegularExpression(@"\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+", ErrorMessage = "The surname is written incorrectly")]
        public string Surname { get; set; } = null!;
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not correctly formatted")]
        public string? Email { get; set; }
        [StringLength(15)]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "Unexpected characters in phone number")]
        public string? Phone { get; set; }
        [Range(25, 400, ErrorMessage = "Weight must be between 25 and 400 kg")]
        public double? Weight { get; set; }
        [Range(10, 100, ErrorMessage = "Age must be between 10 and 100")]
        public int? Age { get; set; }
        public int RoleId { get; set; }
        public int? TrainerId { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public UserRole Role { get; set; } = null!;
        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
        public User Trainer { get; set; } = null!;
        public ICollection<User> Clients { get; set; } = null!;
    }
}
