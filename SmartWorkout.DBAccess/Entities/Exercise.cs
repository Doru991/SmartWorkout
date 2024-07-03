using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public ICollection<ExerciseLog> Logs { get; set; } = null!;
    }
}
