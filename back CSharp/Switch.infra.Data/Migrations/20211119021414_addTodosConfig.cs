using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.infra.Data.Migrations
{
    public partial class addTodosConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identificacao_usuarios_UsuarioId",
                table: "Identificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Grupo_GrupoId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupo_Grupo_GrupoId",
                table: "UsuarioGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupo_usuarios_UsuarioId",
                table: "UsuarioGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioGrupo",
                table: "UsuarioGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identificacao",
                table: "Identificacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo");

            migrationBuilder.RenameTable(
                name: "UsuarioGrupo",
                newName: "UsuarioGrupos");

            migrationBuilder.RenameTable(
                name: "Identificacao",
                newName: "Identificacaos");

            migrationBuilder.RenameTable(
                name: "Grupo",
                newName: "Grupos");

            migrationBuilder.RenameColumn(
                name: "DataPostagem",
                table: "Postagens",
                newName: "DataPublicacao");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioGrupo_GrupoId",
                table: "UsuarioGrupos",
                newName: "IX_UsuarioGrupos_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Identificacao_UsuarioId",
                table: "Identificacaos",
                newName: "IX_Identificacaos_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "ProcurandoPorId",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusRelacionamentoId",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Postagens",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UrlConteudo",
                table: "Postagens",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioGrupos",
                table: "UsuarioGrupos",
                columns: new[] { "UsuarioId", "GrupoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identificacaos",
                table: "Identificacaos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAmigoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => new { x.UsuarioId, x.UsuarioAmigoId });
                    table.ForeignKey(
                        name: "FK_Amigos_usuarios_UsuarioAmigoId",
                        column: x => x.UsuarioAmigoId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amigos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPublicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    texto = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InstituicaoEnsinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataFormacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicaoEnsinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituicaoEnsinos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocalTrabalhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataAdimissao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmpresaAtual = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTrabalhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalTrabalhos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcurandoPors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcurandoPors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProcurandoPors",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "NaoEspecificado" },
                    { 2, "Namoro" },
                    { 3, "Amizade" },
                    { 4, "RelacionamentoSerio" }
                });

            migrationBuilder.InsertData(
                table: "StatusRelacionamento",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "NaoEspecificado" },
                    { 2, "Solteiro" },
                    { 3, "Casado" },
                    { 4, "EmRelacionamentoSerio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ProcurandoPorId",
                table: "usuarios",
                column: "ProcurandoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_StatusRelacionamentoId",
                table: "usuarios",
                column: "StatusRelacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_UsuarioAmigoId",
                table: "Amigos",
                column: "UsuarioAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituicaoEnsinos_UsuarioId",
                table: "InstituicaoEnsinos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalTrabalhos_UsuarioId",
                table: "LocalTrabalhos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identificacaos_usuarios_UsuarioId",
                table: "Identificacaos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Grupos_GrupoId",
                table: "Postagens",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupos_Grupos_GrupoId",
                table: "UsuarioGrupos",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupos_usuarios_UsuarioId",
                table: "UsuarioGrupos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_ProcurandoPors_ProcurandoPorId",
                table: "usuarios",
                column: "ProcurandoPorId",
                principalTable: "ProcurandoPors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_StatusRelacionamento_StatusRelacionamentoId",
                table: "usuarios",
                column: "StatusRelacionamentoId",
                principalTable: "StatusRelacionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identificacaos_usuarios_UsuarioId",
                table: "Identificacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Grupos_GrupoId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupos_Grupos_GrupoId",
                table: "UsuarioGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupos_usuarios_UsuarioId",
                table: "UsuarioGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_ProcurandoPors_ProcurandoPorId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_StatusRelacionamento_StatusRelacionamentoId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "InstituicaoEnsinos");

            migrationBuilder.DropTable(
                name: "LocalTrabalhos");

            migrationBuilder.DropTable(
                name: "ProcurandoPors");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_ProcurandoPorId",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_StatusRelacionamentoId",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioGrupos",
                table: "UsuarioGrupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identificacaos",
                table: "Identificacaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos");

            migrationBuilder.DeleteData(
                table: "StatusRelacionamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusRelacionamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusRelacionamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusRelacionamento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ProcurandoPorId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "StatusRelacionamentoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "UrlConteudo",
                table: "Postagens");

            migrationBuilder.RenameTable(
                name: "UsuarioGrupos",
                newName: "UsuarioGrupo");

            migrationBuilder.RenameTable(
                name: "Identificacaos",
                newName: "Identificacao");

            migrationBuilder.RenameTable(
                name: "Grupos",
                newName: "Grupo");

            migrationBuilder.RenameColumn(
                name: "DataPublicacao",
                table: "Postagens",
                newName: "DataPostagem");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioGrupos_GrupoId",
                table: "UsuarioGrupo",
                newName: "IX_UsuarioGrupo_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Identificacaos_UsuarioId",
                table: "Identificacao",
                newName: "IX_Identificacao_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Postagens",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioGrupo",
                table: "UsuarioGrupo",
                columns: new[] { "UsuarioId", "GrupoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identificacao",
                table: "Identificacao",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identificacao_usuarios_UsuarioId",
                table: "Identificacao",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Grupo_GrupoId",
                table: "Postagens",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupo_Grupo_GrupoId",
                table: "UsuarioGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupo_usuarios_UsuarioId",
                table: "UsuarioGrupo",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
