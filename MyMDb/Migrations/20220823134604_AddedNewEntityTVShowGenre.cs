using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class AddedNewEntityTVShowGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Genres");

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

            migrationBuilder.CreateTable(
                name: "TVShowGenres",
                columns: table => new
                {
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenres", x => new { x.TVShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TVShowGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowGenres_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreTVShow_TVShowsId",
                table: "GenreTVShow",
                column: "TVShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowGenres_GenreId",
                table: "TVShowGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTVShow");

            migrationBuilder.DropTable(
                name: "TVShowGenres");

            migrationBuilder.AddColumn<Guid>(
                name: "TVShowId",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id");
        }
    }
}
