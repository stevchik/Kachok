using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Kachok.Data;

namespace Kachok.Data.Migrations
{
    [DbContext(typeof(KachokContext))]
    [Migration("20160512051752_V1")]
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
        }
    }
}
