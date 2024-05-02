using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Addusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "Users",
    columns: new[] { "UserName", "VerificationStatus", "Balance" },
    values: new object[,]
    {
            { "User 1", true, 1000 },
            { "User 2", false, 500 }
    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
