using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveThreeOne.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MainExercises");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AssistanceExercises");

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "MainExercises",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "AssistanceExercises",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainExercises_ExerciseId",
                table: "MainExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssistanceExercises_ExerciseId",
                table: "AssistanceExercises",
                column: "ExerciseId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistanceExercises_Exercise_ExerciseId",
                table: "AssistanceExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MainExercises_Exercise_ExerciseId",
                table: "MainExercises");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_MainExercises_ExerciseId",
                table: "MainExercises");

            migrationBuilder.DropIndex(
                name: "IX_AssistanceExercises_ExerciseId",
                table: "AssistanceExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "MainExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "AssistanceExercises");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MainExercises",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AssistanceExercises",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
