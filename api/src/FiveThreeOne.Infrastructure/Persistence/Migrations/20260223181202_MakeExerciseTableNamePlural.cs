using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveThreeOne.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeExerciseTableNamePlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistanceExercises_Exercise_ExerciseId",
                table: "AssistanceExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MainExercises_Exercise_ExerciseId",
                table: "MainExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssistanceExercises_Exercises_ExerciseId",
                table: "AssistanceExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainExercises_Exercises_ExerciseId",
                table: "MainExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistanceExercises_Exercises_ExerciseId",
                table: "AssistanceExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MainExercises_Exercises_ExerciseId",
                table: "MainExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssistanceExercises_Exercise_ExerciseId",
                table: "AssistanceExercises",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainExercises_Exercise_ExerciseId",
                table: "MainExercises",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
