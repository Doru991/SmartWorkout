using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWorkout.DBAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartWorkout.DBAccess.Configurations
{
    internal class ExerciseLogConfig : IEntityTypeConfiguration<ExerciseLog>
    {
        public void Configure(EntityTypeBuilder<ExerciseLog> builder)
        {
            builder.HasOne(e => e.Workout).WithMany(w => w.Logs).HasForeignKey(e => e.WorkoutId).HasConstraintName("FK_ExerciseLog_Workout");
            builder.HasOne(e => e.Exercise).WithMany(e => e.Logs).HasForeignKey(e => e.ExerciseId).HasConstraintName("FK_ExerciseLog_Exercise");
            builder.ToTable("ExerciseLog").HasKey(el => new { el.WorkoutId, el.ExerciseId });
        }
    }
}
