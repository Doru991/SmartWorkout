using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class ExerciseLog
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public double? Weight { get; set; }
        public double? Duration { get; set; }
        public double? Distance { get; set; }
        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}
