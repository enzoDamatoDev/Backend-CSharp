using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.infra.Data.Migrations
{
    public partial class addIdentificacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Postagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_usuarios_UsuarioId",
                table: "Postagens",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_usuarios_UsuarioId",
                table: "Postagens");

            migrationBuilder.DropIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Postagens");
        }
    }
}
