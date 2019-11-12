using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class MigracionInical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<long>(nullable: false),
                    ValorPrestamo = table.Column<float>(nullable: false),
                    FechaPrestamo = table.Column<string>(nullable: true),
                    PlazoPago = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesCuota = table.Column<int>(nullable: false),
                    ValorCuota = table.Column<float>(nullable: false),
                    CreditoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cuota_Credito_CreditoId",
                        column: x => x.CreditoId,
                        principalTable: "Credito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_CreditoId",
                table: "Cuota",
                column: "CreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "Credito");
        }
    }
}
