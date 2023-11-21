using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomisSigma1.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RodzajNadwozia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajNadwozia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RodzajPaliwa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajPaliwa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Samochodzik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaID = table.Column<int>(type: "int", nullable: false),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    RodzajNadwoziaID = table.Column<int>(type: "int", nullable: false),
                    RodzajPaliwaID = table.Column<int>(type: "int", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PojemnośćSilnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Przebieg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochodzik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Samochodzik_Marka_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Marka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochodzik_Model_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Model",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochodzik_RodzajNadwozia_RodzajNadwoziaID",
                        column: x => x.RodzajNadwoziaID,
                        principalTable: "RodzajNadwozia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochodzik_RodzajPaliwa_RodzajPaliwaID",
                        column: x => x.RodzajPaliwaID,
                        principalTable: "RodzajPaliwa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samochodzik_MarkaID",
                table: "Samochodzik",
                column: "MarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Samochodzik_ModelID",
                table: "Samochodzik",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Samochodzik_RodzajNadwoziaID",
                table: "Samochodzik",
                column: "RodzajNadwoziaID");

            migrationBuilder.CreateIndex(
                name: "IX_Samochodzik_RodzajPaliwaID",
                table: "Samochodzik",
                column: "RodzajPaliwaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samochodzik");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "RodzajNadwozia");

            migrationBuilder.DropTable(
                name: "RodzajPaliwa");
        }
    }
}
