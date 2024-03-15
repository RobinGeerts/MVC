using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HondenRescue.Migrations
{
    public partial class MIG5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoNaam",
                table: "Hond",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoNaam",
                table: "Hond");
        }
    }
}
