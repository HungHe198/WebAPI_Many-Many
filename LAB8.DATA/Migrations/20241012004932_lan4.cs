using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB8.DATA.Migrations
{
    /// <inheritdoc />
    public partial class lan4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdPeople",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "IdPeople",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPeople",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "IdPeople",
                table: "Cars");
        }
    }
}
