using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveThreeOne.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMovementPatternType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovementPatternType",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovementPatternType",
                table: "Exercises");
        }
    }
}
