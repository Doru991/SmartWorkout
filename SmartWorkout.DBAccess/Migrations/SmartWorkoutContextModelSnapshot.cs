﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartWorkout.DBAccess;

#nullable disable

namespace SmartWorkout.DBAccess.Migrations
{
    [DbContext(typeof(SmartWorkoutContext))]
    partial class SmartWorkoutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercise", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.ExerciseLog", b =>
                {
                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<double?>("Duration")
                        .HasColumnType("float");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("WorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseLog", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TrainerId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workout", (string)null);
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.ExerciseLog", b =>
                {
                    b.HasOne("SmartWorkout.DBAccess.Entities.Exercise", "Exercise")
                        .WithMany("Logs")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseLog_Exercise");

                    b.HasOne("SmartWorkout.DBAccess.Entities.Workout", "Workout")
                        .WithMany("Logs")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseLog_Workout");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.User", b =>
                {
                    b.HasOne("SmartWorkout.DBAccess.Entities.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.HasOne("SmartWorkout.DBAccess.Entities.User", "Trainer")
                        .WithMany("Clients")
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK_Trainer");

                    b.Navigation("Role");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.Workout", b =>
                {
                    b.HasOne("SmartWorkout.DBAccess.Entities.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Workout_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.Exercise", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.User", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SmartWorkout.DBAccess.Entities.Workout", b =>
                {
                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
