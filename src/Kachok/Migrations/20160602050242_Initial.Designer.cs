using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Kachok.Data;

namespace kachok.Migrations
{
    [DbContext(typeof(KachokContext))]
    [Migration("20160602050242_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kachok.Model.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Kachok.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DefaultExerciseUom");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<int>("ExerciseTarget");

                    b.Property<int>("Experience");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Status");

                    b.Property<int?>("TargetMuscleGroupId")
                        .IsRequired();

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("UpdatedDate")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("TargetMuscleGroupId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EquipmentId");

                    b.Property<int>("ExerciseId");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExerciseId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseEquipment");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.Property<int>("ExerciseId");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseImage");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExerciseId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExerciseId", "TagId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TagId");

                    b.ToTable("ExerciseTag");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTechnique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayFormat");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTechnique");
                });

            modelBuilder.Entity("Kachok.Model.KachokUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kachok.Model.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("MuscleGroup");
                });

            modelBuilder.Entity("Kachok.Model.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("NumberOfDays");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("Kachok.Model.PlanDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayNumber");

                    b.Property<int>("PlanId");

                    b.Property<int?>("PlanWorkoutId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("PlanWorkoutId");

                    b.ToTable("PlanDay");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<bool>("IsRestDay");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("PlanId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanWorkout");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId");

                    b.Property<int?>("PlanWorkoutId");

                    b.Property<int>("SequenceNumber");

                    b.Property<string>("SpecialInstructions")
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<int>("Status");

                    b.Property<int?>("SubSequenceNumber");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("PlanWorkoutId");

                    b.ToTable("PlanWorkoutExercise");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExerciseStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseTechniqueId");

                    b.Property<int>("NumberOfSets");

                    b.Property<int>("PlanWorkoutExerciseId");

                    b.Property<int>("RestInterval");

                    b.Property<int>("SequenceNumber");

                    b.Property<string>("SpecialInstructions")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<int>("UnitMax");

                    b.Property<int>("UnitMin");

                    b.Property<int>("UnitOfMeasure");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTechniqueId");

                    b.HasIndex("PlanWorkoutExerciseId");

                    b.ToTable("PlanWorkoutExerciseStep");
                });

            modelBuilder.Entity("Kachok.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kachok.Model.Exercise", b =>
                {
                    b.HasOne("Kachok.Model.MuscleGroup")
                        .WithMany()
                        .HasForeignKey("TargetMuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.ExerciseEquipment", b =>
                {
                    b.HasOne("Kachok.Model.Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.ExerciseImage", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTag", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kachok.Model.Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.PlanDay", b =>
                {
                    b.HasOne("Kachok.Model.Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kachok.Model.PlanWorkout")
                        .WithOne()
                        .HasForeignKey("Kachok.Model.PlanDay", "PlanWorkoutId");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkout", b =>
                {
                    b.HasOne("Kachok.Model.Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExercise", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kachok.Model.PlanWorkout")
                        .WithMany()
                        .HasForeignKey("PlanWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExerciseStep", b =>
                {
                    b.HasOne("Kachok.Model.ExerciseTechnique")
                        .WithOne()
                        .HasForeignKey("Kachok.Model.PlanWorkoutExerciseStep", "ExerciseTechniqueId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Kachok.Model.PlanWorkoutExercise")
                        .WithMany()
                        .HasForeignKey("PlanWorkoutExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kachok.Model.KachokUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kachok.Model.KachokUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kachok.Model.KachokUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
