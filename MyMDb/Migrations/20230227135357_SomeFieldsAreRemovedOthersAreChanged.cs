using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class SomeFieldsAreRemovedOthersAreChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Gross",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gross",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Budget",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
