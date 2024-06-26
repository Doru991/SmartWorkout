using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public double? Weight { get; set; }
        public int? Age { get; set; }
        
        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
    }
}
