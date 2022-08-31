using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class EpisodeEntityIsRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShowActors_Episodes_EpisodeId",
                table: "TVShowActors");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_TVShowActors_EpisodeId",
                table: "TVShowActors");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "TVShowActors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "TVShowActors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShowActors_EpisodeId",
                table: "TVShowActors",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TVShowId",
                table: "Episodes",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowActors_Episodes_EpisodeId",
                table: "TVShowActors",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }
    }
}
