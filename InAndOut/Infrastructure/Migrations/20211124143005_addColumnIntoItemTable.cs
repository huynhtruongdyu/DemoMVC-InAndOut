using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Infrastructure.Migrations
{
    public partial class addColumnIntoItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lender",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lender",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");
        }
    }
}
