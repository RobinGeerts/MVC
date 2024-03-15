using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HondenRescue.Migrations
{
    public partial class MIG1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hond_Eigenaar_EigenaarId",
                table: "Hond");

            migrationBuilder.DropIndex(
                name: "IX_Hond_EigenaarId",
                table: "Hond");

            migrationBuilder.DropColumn(
                name: "EigenaarId",
                table: "Hond");

            migrationBuilder.CreateTable(
                name: "HondEigenaar",
                columns: table => new
                {
                    HondEigenaarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HondId = table.Column<int>(type: "int", nullable: false),
                    EigenaarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HondEigenaar", x => x.HondEigenaarId);
                    table.ForeignKey(
                        name: "FK_HondEigenaar_Eigenaar_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "Eigenaar",
                        principalColumn: "EigenaarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HondEigenaar_Hond_HondId",
                        column: x => x.HondId,
                        principalTable: "Hond",
                        principalColumn: "HondId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HondEigenaar_EigenaarId",
                table: "HondEigenaar",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_HondEigenaar_HondId",
                table: "HondEigenaar",
                column: "HondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HondEigenaar");

            migrationBuilder.AddColumn<int>(
                name: "EigenaarId",
                table: "Hond",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hond_EigenaarId",
                table: "Hond",
                column: "EigenaarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hond_Eigenaar_EigenaarId",
                table: "Hond",
                column: "EigenaarId",
                principalTable: "Eigenaar",
                principalColumn: "EigenaarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
