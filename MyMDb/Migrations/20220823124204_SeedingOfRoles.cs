using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MyMDb.Models;

#nullable disable

namespace MyMDb.Migrations
{
    public partial class SeedingOfRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using var dbContext = MyMDbContext.CreateContext();
            using var tran = dbContext.Database.BeginTransaction();

            var cmd = "INSERT INTO Roles ([Name]) VALUES ('User'), ('Admin')";

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
