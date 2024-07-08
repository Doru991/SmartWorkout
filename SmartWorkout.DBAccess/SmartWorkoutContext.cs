using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Configurations;
using SmartWorkout.DBAccess.Entities;

namespace SmartWorkout.DBAccess
{
    public class SmartWorkoutContext : DbContext
    {
        public SmartWorkoutContext() { }
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options) : base(options) { 
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseLog> Logs { get; set; }
        public DbSet<UserRole> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new WorkoutConfiguration().Configure(modelBuilder.Entity<Workout>());
            new ExerciseConfiguration().Configure(modelBuilder.Entity<Exercise>());
            new ExerciseLogConfig().Configure(modelBuilder.Entity<ExerciseLog>());
            new RoleConfiguration().Configure(modelBuilder.Entity<UserRole>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                var ConnectionString =
                    "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SmartWorkoutEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
