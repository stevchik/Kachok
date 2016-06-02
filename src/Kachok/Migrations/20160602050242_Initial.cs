using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kachok.Migrations
{
    public partial class Initial : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    Status = table.Column<int>(nullable: false),
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<int>(nullable: false),
                    DefaultExerciseUom = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_MuscleGroup_TargetMuscleGroupId",
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_ExerciseEquipment_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
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
                        name: "FK_ExerciseImage_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
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
                        name: "FK_ExerciseTag_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
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
                    Status = table.Column<int>(nullable: false),
                    SubSequenceNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanWorkoutExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanWorkoutExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
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
                    SequenceNumber = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TargetMuscleGroupId",
                table: "Exercises",
                column: "TargetMuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipment_EquipmentId",
                table: "ExerciseEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipment_ExerciseId",
                table: "ExerciseEquipment",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseImage_ExerciseId",
                table: "ExerciseImage",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_ExerciseId",
                table: "ExerciseTag",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_TagId",
                table: "ExerciseTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDay_PlanId",
                table: "PlanDay",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDay_PlanWorkoutId",
                table: "PlanDay",
                column: "PlanWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkout_PlanId",
                table: "PlanWorkout",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkoutExercise_ExerciseId",
                table: "PlanWorkoutExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkoutExercise_PlanWorkoutId",
                table: "PlanWorkoutExercise",
                column: "PlanWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkoutExerciseStep_ExerciseTechniqueId",
                table: "PlanWorkoutExerciseStep",
                column: "ExerciseTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkoutExerciseStep_PlanWorkoutExerciseId",
                table: "PlanWorkoutExerciseStep",
                column: "PlanWorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseEquipment");

            migrationBuilder.DropTable(
                name: "ExerciseImage");

            migrationBuilder.DropTable(
                name: "ExerciseTag");

            migrationBuilder.DropTable(
                name: "PlanDay");

            migrationBuilder.DropTable(
                name: "PlanWorkoutExerciseStep");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "ExerciseTechnique");

            migrationBuilder.DropTable(
                name: "PlanWorkoutExercise");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "PlanWorkout");

            migrationBuilder.DropTable(
                name: "MuscleGroup");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
