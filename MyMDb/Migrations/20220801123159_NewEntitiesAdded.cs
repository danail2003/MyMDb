using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class NewEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TVShowId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TVShowId",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Gross = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVShows_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Episodes_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTVShows",
                columns: table => new
                {
                    TVShowUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTVShows", x => new { x.TVShowId, x.TVShowUserId });
                    table.ForeignKey(
                        name: "FK_UserTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTVShows_Users_TVShowUserId",
                        column: x => x.TVShowUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TVShowActors",
                columns: table => new
                {
                    TVShowActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowActors", x => new { x.ActorId, x.TVShowActorId });
                    table.ForeignKey(
                        name: "FK_TVShowActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowActors_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TVShowActors_TVShows_TVShowActorId",
                        column: x => x.TVShowActorId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_TVShowId",
                table: "Images",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ImageId",
                table: "Episodes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_TVShowId",
                table: "Episodes",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowActors_EpisodeId",
                table: "TVShowActors",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowActors_TVShowActorId",
                table: "TVShowActors",
                column: "TVShowActorId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_ImageId",
                table: "TVShows",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTVShows_TVShowUserId",
                table: "UserTVShows",
                column: "TVShowUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_TVShows_TVShowId",
                table: "Images",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_TVShows_TVShowId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "TVShowActors");

            migrationBuilder.DropTable(
                name: "UserTVShows");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_Images_TVShowId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Genres");
        }
    }
}
