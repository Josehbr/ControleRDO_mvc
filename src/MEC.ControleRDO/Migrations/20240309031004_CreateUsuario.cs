using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEC.ControleRDO.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Fiscais_FiscalId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Rdos_Obras_ObraId",
                table: "Rdos");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Fiscais_FiscalId",
                table: "Obras",
                column: "FiscalId",
                principalTable: "Fiscais",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rdos_Obras_ObraId",
                table: "Rdos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Fiscais_FiscalId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Rdos_Obras_ObraId",
                table: "Rdos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Fiscais_FiscalId",
                table: "Obras",
                column: "FiscalId",
                principalTable: "Fiscais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rdos_Obras_ObraId",
                table: "Rdos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
