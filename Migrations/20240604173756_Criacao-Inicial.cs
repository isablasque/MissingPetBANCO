using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissingPet.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalRaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalCor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalObservacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalDtDesaparecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalDtEncontro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observacao",
                columns: table => new
                {
                    ObservacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservacaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacaoLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacaoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacao", x => x.ObservacaoId);
                    table.ForeignKey(
                        name: "FK_Observacao_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId");
                    table.ForeignKey(
                        name: "FK_Observacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_UsuarioId",
                table: "Animal",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacao_AnimalId",
                table: "Observacao",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacao_UsuarioId",
                table: "Observacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observacao");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
