using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class RepairedWrongRelationshipsBetweenGenreAndTVShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTVShow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreTVShow",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    TVShowsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTVShow", x => new { x.GenresId, x.TVShowsId });
                    table.ForeignKey(
                        name: "FK_GenreTVShow_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTVShow_TVShows_TVShowsId",
                        column: x => x.TVShowsId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreTVShow_TVShowsId",
                table: "GenreTVShow",
                column: "TVShowsId");
        }
    }
}
