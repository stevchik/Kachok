using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Kachok.Data.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ExerciseTechnique",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DisplayFormat = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTechnique", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "MuscleGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroup", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NumberOfDays = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ExerciseTarget = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TargetMuscleGroupId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_MuscleGroup_TargetMuscleGroupId",
                        column: x => x.TargetMuscleGroupId,
                        principalTable: "MuscleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PlanWorkout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    IsRestDay = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanWorkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanWorkout_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ExerciseEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipment", x => x.Id);
                    table.UniqueConstraint("AK_ExerciseEquipment_ExerciseId_EquipmentId", x => new { x.ExerciseId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_ExerciseEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipment_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ExerciseImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseImage_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ExerciseTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTag", x => x.Id);
                    table.UniqueConstraint("AK_ExerciseTag_ExerciseId_TagId", x => new { x.ExerciseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PlanDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayNumber = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: false),
                    PlanWorkoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDay_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDay_PlanWorkout_PlanWorkoutId",
                        column: x => x.PlanWorkoutId,
                        principalTable: "PlanWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "PlanWorkoutExercise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(nullable: false),
                    PlanWorkoutId = table.Column<int>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    SpecialInstructions = table.Column<string>(nullable: true),
                    SubSequenceNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanWorkoutExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanWorkoutExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanWorkoutExercise_PlanWorkout_PlanWorkoutId",
                        column: x => x.PlanWorkoutId,
                        principalTable: "PlanWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PlanWorkoutExerciseStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseTechniqueId = table.Column<int>(nullable: true),
                    NumberOfSets = table.Column<int>(nullable: false),
                    PlanWorkoutExerciseId = table.Column<int>(nullable: false),
                    RestInterval = table.Column<int>(nullable: false),
                    SpecialInstructions = table.Column<string>(nullable: false),
                    UnitMax = table.Column<int>(nullable: false),
                    UnitMin = table.Column<int>(nullable: false),
                    UnitOfMeasure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanWorkoutExerciseStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanWorkoutExerciseStep_ExerciseTechnique_ExerciseTechniqueId",
                        column: x => x.ExerciseTechniqueId,
                        principalTable: "ExerciseTechnique",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlanWorkoutExerciseStep_PlanWorkoutExercise_PlanWorkoutExerciseId",
                        column: x => x.PlanWorkoutExerciseId,
                        principalTable: "PlanWorkoutExercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ExerciseEquipment");
            migrationBuilder.DropTable("ExerciseImage");
            migrationBuilder.DropTable("ExerciseTag");
            migrationBuilder.DropTable("PlanDay");
            migrationBuilder.DropTable("PlanWorkoutExerciseStep");
            migrationBuilder.DropTable("Equipment");
            migrationBuilder.DropTable("Tag");
            migrationBuilder.DropTable("ExerciseTechnique");
            migrationBuilder.DropTable("PlanWorkoutExercise");
            migrationBuilder.DropTable("Exercise");
            migrationBuilder.DropTable("PlanWorkout");
            migrationBuilder.DropTable("MuscleGroup");
            migrationBuilder.DropTable("Plan");
        }
    }
}
