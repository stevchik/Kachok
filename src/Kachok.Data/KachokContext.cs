using System;
using Kachok.Model;
using Microsoft.Data.Entity;

namespace Kachok.Data
{
    public class KachokContext : DbContext
    {
     
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public DbSet<ExerciseTag> ExerciseTags { get; set; }
        public DbSet<ExerciseImage> ExerciseImages { get; set; }

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

            modelBuilder.Entity<Exercise>()
              .Property(p => p.CreatedDate)
                  .ValueGeneratedOnAdd();

            modelBuilder.Entity<Exercise>()
             .Property(p => p.UpdatedDate)
                 .ValueGeneratedOnAddOrUpdate()
                 .IsConcurrencyToken();
            
        }

        private void setupExerciseImageModel(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<ExerciseImage>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<ExerciseImage>()
                .ToTable("ExerciseImage")
                .HasOne(pt => pt.Exercise)
                .WithMany(p => p.ExerciseImages)
                .HasForeignKey(pt => pt.ExerciseId);
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
                .HasAlternateKey(k => new { k.ExerciseId, k.TagId });
            modelBuilder.Entity<ExerciseTag>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<ExerciseTag>()
                .ToTable("ExerciseTag")
                .HasOne(pt => pt.Exercise)
                .WithMany(p => p.ExerciseTags)
                .HasForeignKey(pt => pt.ExerciseId);

        }

        private void setupExerciseEquipmentModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseEquipment>()                
                .HasAlternateKey(k => new { k.ExerciseId, k.EquipmentId });
            modelBuilder.Entity<ExerciseEquipment>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<ExerciseEquipment>()
                .ToTable("ExerciseEquipment")
                .HasOne(pt => pt.Exercise)
                .WithMany(p => p.ExerciseEquipments)
                .HasForeignKey(pt => pt.ExerciseId);

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
