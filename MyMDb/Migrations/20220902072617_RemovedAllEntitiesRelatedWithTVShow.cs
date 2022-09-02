using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class RemovedAllEntitiesRelatedWithTVShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShowActors");

            migrationBuilder.DropTable(
                name: "TVShowGenres");

            migrationBuilder.DropTable(
                name: "UserTVShows");

            migrationBuilder.DropTable(
                name: "TVShows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gross = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVShowActors",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowActors", x => new { x.ActorId, x.TVShowId });
                    table.ForeignKey(
                        name: "FK_TVShowActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowActors_TVShows_TVShowId",
                        column: x => x.TVShowId,
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

            migrationBuilder.CreateTable(
                name: "UserTVShows",
                columns: table => new
                {
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTVShows", x => new { x.TVShowId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTVShows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShowActors_TVShowId",
                table: "TVShowActors",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowGenres_GenreId",
                table: "TVShowGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTVShows_UserId",
                table: "UserTVShows",
                column: "UserId");
        }
    }
}
