using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MyMDb.Models;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class SeedingOfGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using var dbContext = MyMDbContext.CreateContext();
            using var tran = dbContext.Database.BeginTransaction();

            var cmd = "INSERT INTO Genres ([Name]) VALUES ('Action'), ('Adventure'), ('Comedy'), ('Drama'), ('Sci-Fi'), ('Mystery'), ('Horror'), ('Biography')," +
                "('Western'), ('Science'), ('Animation'), ('Romance'), ('Erotic'), ('Documentary'), ('Music'), ('Thriller'), ('Crime'), ('Fantasy'), ('History'), ('War')";

            try
            {
                dbContext.Database.ExecuteSqlRaw(cmd);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
