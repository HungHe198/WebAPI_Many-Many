using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB8.DATA.Migrations
{
    /// <inheritdoc />
    public partial class lan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCar",
                table: "Peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLaptop",
                table: "Peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCar",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "IdLaptop",
                table: "Peoples");
        }
    }
}
