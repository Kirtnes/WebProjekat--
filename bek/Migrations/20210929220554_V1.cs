using Microsoft.EntityFrameworkCore.Migrations;

namespace bek.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSale = table.Column<int>(type: "int", nullable: false),
                    BrojRedova = table.Column<int>(type: "int", nullable: false),
                    BrojMestaPoRedu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sediste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sediste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sediste_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojKarte = table.Column<int>(type: "int", nullable: false),
                    SedisteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Osoba_Sediste_SedisteID",
                        column: x => x.SedisteID,
                        principalTable: "Sediste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_SedisteID",
                table: "Osoba",
                column: "SedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Sediste_SalaID",
                table: "Sediste",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "Sediste");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
