using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Lab1.Migrations
{
    /// <inheritdoc />
    public partial class states : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "States",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "States",
                table: "Departments");
        }
    }
}
