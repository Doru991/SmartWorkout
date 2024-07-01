using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Repository
{
    [Obsolete("Replaced by generic repo")]
    public class ExerciseRepository : IExerciseRepository, IDisposable
    {
        private SmartWorkoutContext context;
        public ExerciseRepository(SmartWorkoutContext context)
        {
            this.context = context;
        }

        public async Task<Exercise[]> GetExercises()
        {
            return await context.Exercises.ToArrayAsync<Exercise>();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
