using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Configurations
{
    internal class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workout").HasKey(w => w.Id);
            builder.Property(w => w.Date).IsRequired();
            builder.HasOne(w => w.User).WithMany(u => u.Workouts).HasForeignKey(w => w.UserId).HasConstraintName("FK_Workout_User");
        }
    }
}
