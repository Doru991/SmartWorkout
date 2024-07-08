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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id);
            builder.Property(u => u.Phone).HasMaxLength(15);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u=>u.RoleId).IsRequired().HasDefaultValue(2);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId).HasConstraintName("FK_User_Role");
            builder.HasOne(u => u.Trainer).WithMany(u => u.Clients).HasForeignKey(u => u.TrainerId).HasConstraintName("FK_Trainer");
        }
    }
}
