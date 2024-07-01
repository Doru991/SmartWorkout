using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Repository
{
    [Obsolete("Replaced by generic repo")]
    public interface IExerciseRepository : IDisposable
    {
        public Task<Exercise[]> GetExercises();
    }
}
