using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class RemovedImageEntityAndMadeChangesInOthersEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Images_ImageId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MovieActorId",
                table: "MoviesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowActorId",
                table: "TVShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_Images_ImageId",
                table: "TVShows");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersActors_Users_ActorUserId",
                table: "UsersActors");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Users_MovieUserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Users_UserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTVShows_Users_TVShowUserId",
                table: "UserTVShows");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.DropIndex(
                name: "IX_UsersMovies_MovieUserId",
                table: "UsersMovies");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_ImageId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_ImageId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "MovieUserId",
                table: "UsersMovies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "TVShowUserId",
                table: "UserTVShows",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTVShows_TVShowUserId",
                table: "UserTVShows",
                newName: "IX_UserTVShows_UserId");

            migrationBuilder.RenameColumn(
                name: "ActorUserId",
                table: "UsersActors",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "TVShows",
                newName: "Video");

            migrationBuilder.RenameColumn(
                name: "TVShowActorId",
                table: "TVShowActors",
                newName: "TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowActors_TVShowActorId",
                table: "TVShowActors",
                newName: "IX_TVShowActors_TVShowId");

            migrationBuilder.RenameColumn(
                name: "MovieActorId",
                table: "MoviesActors",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Movies",
                newName: "Video");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UsersMovies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UsersMovies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Episodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CountryBorn",
                table: "Actors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CityBorn",
                table: "Actors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMovies_UserId1",
                table: "UsersMovies",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowId",
                table: "TVShowActors",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersActors_Users_UserId",
                table: "UsersActors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Users_UserId",
                table: "UsersMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Users_UserId1",
                table: "UsersMovies",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTVShows_Users_UserId",
                table: "UserTVShows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowId",
                table: "TVShowActors");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersActors_Users_UserId",
                table: "UsersActors");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Users_UserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Users_UserId1",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTVShows_Users_UserId",
                table: "UserTVShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.DropIndex(
                name: "IX_UsersMovies_UserId1",
                table: "UsersMovies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersMovies");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTVShows",
                newName: "TVShowUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTVShows_UserId",
                table: "UserTVShows",
                newName: "IX_UserTVShows_TVShowUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersActors",
                newName: "ActorUserId");

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "TVShows",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "TVShowId",
                table: "TVShowActors",
                newName: "TVShowActorId");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowActors_TVShowId",
                table: "TVShowActors",
                newName: "IX_TVShowActors_TVShowActorId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MoviesActors",
                newName: "MovieActorId");

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "Movies",
                newName: "VideoUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UsersMovies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieUserId",
                table: "UsersMovies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "TVShows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Episodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "CountryBorn",
                table: "Actors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CityBorn",
                table: "Actors",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "MovieId", "MovieUserId" });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TVShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Movies_MovieImageId",
                        column: x => x.MovieImageId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMovies_MovieUserId",
                table: "UsersMovies",
                column: "MovieUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_ImageId",
                table: "TVShows",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ImageId",
                table: "Episodes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ActorId",
                table: "Images",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieId",
                table: "Images",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieImageId",
                table: "Images",
                column: "MovieImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_TVShowId",
                table: "Images",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Images_ImageId",
                table: "Episodes",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MovieActorId",
                table: "MoviesActors",
                column: "MovieActorId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowActors_TVShows_TVShowActorId",
                table: "TVShowActors",
                column: "TVShowActorId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_Images_ImageId",
                table: "TVShows",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersActors_Users_ActorUserId",
                table: "UsersActors",
                column: "ActorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Users_MovieUserId",
                table: "UsersMovies",
                column: "MovieUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Users_UserId",
                table: "UsersMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTVShows_Users_TVShowUserId",
                table: "UserTVShows",
                column: "TVShowUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
