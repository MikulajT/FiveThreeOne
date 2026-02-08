using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveThreeOne.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SquatTM = table.Column<float>(type: "real", nullable: false),
                    SquatOneRP = table.Column<float>(type: "real", nullable: false),
                    BenchTM = table.Column<float>(type: "real", nullable: false),
                    BenchOneRP = table.Column<float>(type: "real", nullable: false),
                    DeadliftTM = table.Column<float>(type: "real", nullable: false),
                    DeadliftOneRP = table.Column<float>(type: "real", nullable: false),
                    MilitaryPressTM = table.Column<float>(type: "real", nullable: false),
                    MilitaryPressOneRP = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainExerciseSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Percentage = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Reps = table.Column<int>(type: "integer", nullable: false),
                    MainExerciseId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainExerciseSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainExerciseSets_MainExercises_MainExerciseId",
                        column: x => x.MainExerciseId,
                        principalTable: "MainExercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: false),
                    HighestTM = table.Column<int>(type: "integer", nullable: false),
                    WorkoutNumber = table.Column<int>(type: "integer", nullable: false),
                    MainExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_MainExercises_MainExerciseId",
                        column: x => x.MainExerciseId,
                        principalTable: "MainExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssistanceExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MinRepsAmount = table.Column<int>(type: "integer", nullable: false),
                    MaxRepsAmount = table.Column<int>(type: "integer", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistanceExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistanceExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistanceExercises_WorkoutId",
                table: "AssistanceExercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_MainExerciseSets_MainExerciseId",
                table: "MainExerciseSets",
                column: "MainExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MainExerciseId",
                table: "Workouts",
                column: "MainExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistanceExercises");

            migrationBuilder.DropTable(
                name: "MainExerciseSets");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "MainExercises");
        }
    }
}
