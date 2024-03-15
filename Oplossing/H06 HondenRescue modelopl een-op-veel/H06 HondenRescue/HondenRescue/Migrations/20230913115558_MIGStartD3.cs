using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HondenRescue.Migrations
{
    public partial class MIGStartD3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eigenaar",
                columns: table => new
                {
                    EigenaarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Familienaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eigenaar", x => x.EigenaarId);
                });

            migrationBuilder.CreateTable(
                name: "Hond",
                columns: table => new
                {
                    HondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Geslacht = table.Column<int>(type: "int", nullable: false),
                    Opmerkingen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaatsteVaccinatieDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FotoNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gechipt = table.Column<bool>(type: "bit", nullable: false),
                    EigenaarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hond", x => x.HondId);
                    table.ForeignKey(
                        name: "FK_Hond_Eigenaar_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "Eigenaar",
                        principalColumn: "EigenaarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hond_EigenaarId",
                table: "Hond",
                column: "EigenaarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hond");

            migrationBuilder.DropTable(
                name: "Eigenaar");
        }
    }
}
