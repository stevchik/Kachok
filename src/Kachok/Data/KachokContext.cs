using System.Collections;
using Kachok.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kachok.Data
{
    public class KachokContext : IdentityDbContext<KachokUser>
    {
     
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public DbSet<ExerciseTag> ExerciseTags { get; set; }
        public DbSet<ExerciseImage> ExerciseImages { get; set; }

        public DbSet<PlanWorkoutExerciseStep> PlanWorkoutExerciseSteps { get; set; }
        public DbSet<PlanWorkoutExercise> PlanWorkoutExercises { get; set; }
        public DbSet<PlanTag> PlanTags { get; set; }
        public DbSet<PlanWorkout> PlanWorkouts { get; set; }
        public DbSet<PlanDay> PlanDays { get; set; }
        public DbSet<Plan> Plans { get; set; }

        public KachokContext(DbContextOptions<KachokContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            setupMuscleGroupModel(modelBuilder);
            setupEquipmentModel(modelBuilder);
            setupTagModel(modelBuilder);         
            setupExerciseEquipmentModel(modelBuilder);
            setupExerciseTagModel(modelBuilder);
            setupExerciseImageModel(modelBuilder);
            setupExerciseModel(modelBuilder);

            setupPlanWorkoutExerciseStepModel(modelBuilder);
            setupPlanWorkoutExerciseModel(modelBuilder);
            setupPlanWorkoutModel(modelBuilder);
            setupPlanTagModel(modelBuilder);
            setupPlanDayModel(modelBuilder);
            setupPlanModel(modelBuilder);
        }

        private void setupPlanModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
              .ToTable("Plan")
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Plan>()
              .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Plan>()
              .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            //modelBuilder.Entity<Plan>()
            //  .Property(p => p.CreatedDate)
                  //.ValueGeneratedOnAdd();

            modelBuilder.Entity<Plan>()
             .Property(p => p.UpdatedDate)            // .ValueGeneratedOnAddOrUpdate()    
                 .IsConcurrencyToken();

            modelBuilder.Entity<Plan>()                
                .HasMany(pt => pt.PlanWorkouts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plan>()
               .HasMany(pt => pt.PlanDays)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        }

        private void setupPlanTagModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanTag>()
                 .ToTable("PlanTag")
                .HasAlternateKey(k => new { k.PlanId, k.TagId });
            modelBuilder.Entity<PlanTag>()
                .HasKey(k => k.Id);
        }

        private void setupPlanDayModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanDay>()
                 .ToTable("PlanDay")
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

             modelBuilder.Entity<PlanDay>()
                 .HasOne(pt => pt.PlanWorkout)
                 .WithOne()
                 .OnDelete(DeleteBehavior.Restrict);
        }

        private void setupPlanWorkoutModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanWorkout>()
                 .ToTable("PlanWorkout")
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<PlanWorkout>()
              .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PlanWorkout>()
              .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

           modelBuilder.Entity<PlanWorkout>()               
                .HasMany(pt => pt.PlanWorkoutExercises)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void setupPlanWorkoutExerciseModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanWorkoutExercise>()
              .ToTable("PlanWorkoutExercise")
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<PlanWorkoutExercise>()
             .Property(p => p.SpecialInstructions)
               .HasMaxLength(1000);

            modelBuilder.Entity<PlanWorkoutExercise>()
                .HasMany(pt => pt.PlanWorkoutExerciseSteps)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void setupPlanWorkoutExerciseStepModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanWorkoutExerciseStep>()
              .ToTable("PlanWorkoutExerciseStep")
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<PlanWorkoutExerciseStep>()
             .Property(p => p.SpecialInstructions)
               .IsRequired()
               .HasMaxLength(1000);

            modelBuilder.Entity<PlanWorkoutExerciseStep>()
                .HasOne(pt => pt.ExerciseTechnique)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }

        private void setupExerciseModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
               .HasKey(k => k.Id);

            modelBuilder.Entity<Exercise>()
              .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Exercise>()
              .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Exercise>()
              .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            //modelBuilder.Entity<Exercise>()
            //  .Property(p => p.CreatedDate)
                  //.ValueGeneratedOnAdd();

            modelBuilder.Entity<Exercise>()
             .Property(p => p.UpdatedDate)
                // .ValueGeneratedOnAddOrUpdate()
                 .IsConcurrencyToken();

            modelBuilder.Entity<Exercise>()
               .HasMany(pt => pt.ExerciseImages)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
              .HasMany(pt => pt.ExerciseTags)
              .WithOne()
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
             .HasMany(pt => pt.ExerciseEquipments)
             .WithOne()
             .OnDelete(DeleteBehavior.Cascade);

        }

        private void setupExerciseImageModel(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<ExerciseImage>()
                 .ToTable("ExerciseImage")
                .HasKey(k => k.Id);           
            modelBuilder.Entity<ExerciseImage>()
                .Property(p => p.Caption)
                    .IsRequired()
                    .HasMaxLength(250);
            modelBuilder.Entity<ExerciseImage>()
              .Property(p => p.ImageUrl)
                  .IsRequired()
                  .HasMaxLength(250);
            modelBuilder.Entity<ExerciseImage>()
              .Property(p => p.Sequence)
                  .IsRequired();
        }

        private void setupExerciseTagModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseTag>()
                 .ToTable("ExerciseTag")
                .HasAlternateKey(k => new { k.ExerciseId, k.TagId });
            modelBuilder.Entity<ExerciseTag>()
                .HasKey(k => k.Id);
        }

        private void setupExerciseEquipmentModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseEquipment>()
                 .ToTable("ExerciseEquipment")
                .HasAlternateKey(k => new { k.ExerciseId, k.EquipmentId });
            modelBuilder.Entity<ExerciseEquipment>()
                .HasKey(k => k.Id);           
        }

        private void setupMuscleGroupModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MuscleGroup>()
                .ToTable("MuscleGroup")
                .Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }

        private void setupEquipmentModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
            .ToTable("Equipment")
            .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void setupTagModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .ToTable("Tag")
                .Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
    
}
