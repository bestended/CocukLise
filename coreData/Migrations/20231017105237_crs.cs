using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreData.Migrations
{
    public partial class crs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "birims",
                columns: table => new
                {
                    birimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    birimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birims", x => x.birimID);
                });

            migrationBuilder.CreateTable(
                name: "gorevs",
                columns: table => new
                {
                    gorevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gorevTanim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gorevAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    puan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gorevs", x => x.gorevID);
                });

            migrationBuilder.CreateTable(
                name: "unvans",
                columns: table => new
                {
                    unvanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unvanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unvans", x => x.unvanID);
                });

            migrationBuilder.CreateTable(
                name: "BirimlerGorevler",
                columns: table => new
                {
                    birimlerbirimID = table.Column<int>(type: "int", nullable: false),
                    gorevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirimlerGorevler", x => new { x.birimlerbirimID, x.gorevID });
                    table.ForeignKey(
                        name: "FK_BirimlerGorevler_birims_birimlerbirimID",
                        column: x => x.birimlerbirimID,
                        principalTable: "birims",
                        principalColumn: "birimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirimlerGorevler_gorevs_gorevID",
                        column: x => x.gorevID,
                        principalTable: "gorevs",
                        principalColumn: "gorevID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projes",
                columns: table => new
                {
                    projeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projeBaslangicTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projeBitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gorevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projes", x => x.projeID);
                    table.ForeignKey(
                        name: "FK_projes_gorevs_gorevID",
                        column: x => x.gorevID,
                        principalTable: "gorevs",
                        principalColumn: "gorevID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calisans",
                columns: table => new
                {
                    calisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calisanCinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iseBaslamaTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calisanVardiya = table.Column<bool>(type: "bit", nullable: false),
                    calisanMaas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    calisanPrim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    gorevID = table.Column<int>(type: "int", nullable: false),
                    unvanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calisans", x => x.calisanID);
                    table.ForeignKey(
                        name: "FK_calisans_gorevs_gorevID",
                        column: x => x.gorevID,
                        principalTable: "gorevs",
                        principalColumn: "gorevID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calisans_unvans_unvanID",
                        column: x => x.unvanID,
                        principalTable: "unvans",
                        principalColumn: "unvanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cocuks",
                columns: table => new
                {
                    cocukID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calisanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cocuks", x => x.cocukID);
                    table.ForeignKey(
                        name: "FK_cocuks_calisans_calisanID",
                        column: x => x.calisanID,
                        principalTable: "calisans",
                        principalColumn: "calisanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirimlerGorevler_gorevID",
                table: "BirimlerGorevler",
                column: "gorevID");

            migrationBuilder.CreateIndex(
                name: "IX_calisans_gorevID",
                table: "calisans",
                column: "gorevID");

            migrationBuilder.CreateIndex(
                name: "IX_calisans_unvanID",
                table: "calisans",
                column: "unvanID");

            migrationBuilder.CreateIndex(
                name: "IX_cocuks_calisanID",
                table: "cocuks",
                column: "calisanID");

            migrationBuilder.CreateIndex(
                name: "IX_projes_gorevID",
                table: "projes",
                column: "gorevID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirimlerGorevler");

            migrationBuilder.DropTable(
                name: "cocuks");

            migrationBuilder.DropTable(
                name: "projes");

            migrationBuilder.DropTable(
                name: "birims");

            migrationBuilder.DropTable(
                name: "calisans");

            migrationBuilder.DropTable(
                name: "gorevs");

            migrationBuilder.DropTable(
                name: "unvans");
        }
    }
}
