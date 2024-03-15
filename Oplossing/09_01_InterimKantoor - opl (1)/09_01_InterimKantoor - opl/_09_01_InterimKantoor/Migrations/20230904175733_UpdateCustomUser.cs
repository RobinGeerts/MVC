using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _09_01_InterimKantoor.Migrations
{
    public partial class UpdateCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Geboortedatum",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gemeente",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeslachtSelect",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Huisnummer",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Straat",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Geboortedatum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gemeente",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GeslachtSelect",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Huisnummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Straat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "AspNetUsers");
        }
    }
}
