using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class ReleaseDateColumnAddedAndCollectionOfImagesInMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Movies_MovieId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_Images_MovieId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MoviesActors",
                newName: "MovieActorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieImageId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieId",
                table: "Images",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieImageId",
                table: "Images",
                column: "MovieImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Movies_MovieId",
                table: "Images",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Movies_MovieImageId",
                table: "Images",
                column: "MovieImageId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MovieActorId",
                table: "MoviesActors",
                column: "MovieActorId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Movies_MovieId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Movies_MovieImageId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesActors_Movies_MovieActorId",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_Images_MovieId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_MovieImageId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MovieImageId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "MovieActorId",
                table: "MoviesActors",
                newName: "MovieId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MovieId",
                table: "Images",
                column: "MovieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Movies_MovieId",
                table: "Images",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesActors_Movies_MovieId",
                table: "MoviesActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
