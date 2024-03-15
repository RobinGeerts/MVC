using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HondenRescue.Migrations
{
    public partial class MIG0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hond",
                columns: table => new
                {
                    HondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Geslacht = table.Column<int>(type: "int", nullable: false),
                    Opmerkingen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hond", x => x.HondId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hond");
        }
    }
}
