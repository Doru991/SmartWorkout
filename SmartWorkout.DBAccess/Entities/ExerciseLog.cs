using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class ExerciseLog
    {
        public int WorkoutId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an exercise type!")]
        public int ExerciseId { get; set; }
        [Range(1, 999)]
        public int? Sets { get; set; }
        [Range(1, 999)]
        public int? Reps { get; set; }
        [Range(1, 500)]
        public double? Weight { get; set; }
        [Range(0, 720)]
        public double? Duration { get; set; }
        [Range(0, 100)]
        public double? Distance { get; set; }
        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}
