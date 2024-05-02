using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddTopUpOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "Options",
        columns: new[] { "Amount" },
        values: new object[,]
        {
            { 5m },
            { 10m },
            { 20m },
            { 30m },
            { 50m },
            { 75m },
            { 100m }
        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
