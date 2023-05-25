using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_pecano.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoTrabajadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTrabajadores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horasLaboradas = table.Column<int>(type: "int", nullable: false),
                    diasLaborados = table.Column<int>(type: "int", nullable: false),
                    faltas = table.Column<int>(type: "int", nullable: false),
                    tipoTrabajador = table.Column<int>(type: "int", nullable: false),
                    trabajadorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trabajadores_TipoTrabajadores_trabajadorid",
                        column: x => x.trabajadorid,
                        principalTable: "TipoTrabajadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_trabajadorid",
                table: "Trabajadores",
                column: "trabajadorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "TipoTrabajadores");
        }
    }
}
