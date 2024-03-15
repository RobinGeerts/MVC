using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HondenRescue.Migrations
{
    public partial class MIG1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Geboortedatum",
                table: "Hond",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gechipt",
                table: "Hond",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LaatsteVaccinatieDatum",
                table: "Hond",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gechipt",
                table: "Hond");

            migrationBuilder.DropColumn(
                name: "LaatsteVaccinatieDatum",
                table: "Hond");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Geboortedatum",
                table: "Hond",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
