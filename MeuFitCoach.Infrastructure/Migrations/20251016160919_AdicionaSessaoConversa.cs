using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuFitCoach.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSessaoConversa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempoDeTreino",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SessoesConversa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EstadoAtual = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Objetivo = table.Column<string>(type: "text", nullable: true),
                    Nivel = table.Column<string>(type: "text", nullable: true),
                    Equipmentos = table.Column<string>(type: "text", nullable: false),
                    UltimaInteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessoesConversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessoesConversa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessoesConversa_UsuarioId",
                table: "SessoesConversa",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessoesConversa");

            migrationBuilder.DropColumn(
                name: "TempoDeTreino",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Usuario");
        }
    }
}
