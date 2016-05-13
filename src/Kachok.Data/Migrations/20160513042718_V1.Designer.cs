using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Kachok.Data;

namespace Kachok.Data.Migrations
{
    [DbContext(typeof(KachokContext))]
    [Migration("20160513042718_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kachok.Model.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Equipment");
                });

            modelBuilder.Entity("Kachok.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CreatedDate")
                        .ValueGeneratedOnAdd();

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
                });

            modelBuilder.Entity("Kachok.Model.ExerciseEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EquipmentId");

                    b.Property<int>("ExerciseId");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExerciseId", "EquipmentId");

                    b.HasAnnotation("Relational:TableName", "ExerciseEquipment");
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

                    b.HasAnnotation("Relational:TableName", "ExerciseImage");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExerciseId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExerciseId", "TagId");

                    b.HasAnnotation("Relational:TableName", "ExerciseTag");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTechnique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayFormat");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kachok.Model.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "MuscleGroup");
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

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Plan");
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

                    b.HasAnnotation("Relational:TableName", "PlanDay");
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

                    b.HasAnnotation("Relational:TableName", "PlanWorkout");
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

                    b.Property<int?>("SubSequenceNumber");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "PlanWorkoutExercise");
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

                    b.Property<string>("SpecialInstructions")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<int>("UnitMax");

                    b.Property<int>("UnitMin");

                    b.Property<int>("UnitOfMeasure");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "PlanWorkoutExerciseStep");
                });

            modelBuilder.Entity("Kachok.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Tag");
                });

            modelBuilder.Entity("Kachok.Model.Exercise", b =>
                {
                    b.HasOne("Kachok.Model.MuscleGroup")
                        .WithMany()
                        .HasForeignKey("TargetMuscleGroupId");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseEquipment", b =>
                {
                    b.HasOne("Kachok.Model.Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseImage", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Kachok.Model.ExerciseTag", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("Kachok.Model.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Kachok.Model.PlanDay", b =>
                {
                    b.HasOne("Kachok.Model.Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("Kachok.Model.PlanWorkout")
                        .WithOne()
                        .HasForeignKey("Kachok.Model.PlanDay", "PlanWorkoutId");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkout", b =>
                {
                    b.HasOne("Kachok.Model.Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExercise", b =>
                {
                    b.HasOne("Kachok.Model.Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("Kachok.Model.PlanWorkout")
                        .WithMany()
                        .HasForeignKey("PlanWorkoutId");
                });

            modelBuilder.Entity("Kachok.Model.PlanWorkoutExerciseStep", b =>
                {
                    b.HasOne("Kachok.Model.ExerciseTechnique")
                        .WithOne()
                        .HasForeignKey("Kachok.Model.PlanWorkoutExerciseStep", "ExerciseTechniqueId");

                    b.HasOne("Kachok.Model.PlanWorkoutExercise")
                        .WithMany()
                        .HasForeignKey("PlanWorkoutExerciseId");
                });
        }
    }
}
