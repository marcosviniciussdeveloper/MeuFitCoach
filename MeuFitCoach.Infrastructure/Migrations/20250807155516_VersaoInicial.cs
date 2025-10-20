using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuFitCoach.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VersaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeExercicio = table.Column<string>(type: "text", nullable: false),
                    DescricaoExercicio = table.Column<string>(type: "text", nullable: false),
                    IntrucoesExercicio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Altura = table.Column<double>(type: "double precision", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    NumeroWhatsapp = table.Column<string>(type: "text", nullable: false),
                    Objetivo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoDeTreino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeTreino = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ObjetivoDoTreino = table.Column<string>(type: "text", nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataDeTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanoAtivo = table.Column<bool>(type: "boolean", nullable: false),
                    FrequenciaSemanal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeTreino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoDeTreino_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessaoDeTreino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanoDeTreinoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    NomeSessaoTreino = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessaoDeTreino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessaoDeTreino_PlanoDeTreino_PlanoDeTreinoId",
                        column: x => x.PlanoDeTreinoId,
                        principalTable: "PlanoDeTreino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioDaSessao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessaoDeTreinoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExercicioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Series = table.Column<int>(type: "integer", nullable: false),
                    Repeticao = table.Column<string>(type: "text", nullable: false),
                    OrdemDaSessao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioDaSessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercicioDaSessao_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExercicioDaSessao_SessaoDeTreino_SessaoDeTreinoId",
                        column: x => x.SessaoDeTreinoId,
                        principalTable: "SessaoDeTreino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioDaSessao_ExercicioId",
                table: "ExercicioDaSessao",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioDaSessao_SessaoDeTreinoId",
                table: "ExercicioDaSessao",
                column: "SessaoDeTreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDeTreino_UsuarioId",
                table: "PlanoDeTreino",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SessaoDeTreino_PlanoDeTreinoId",
                table: "SessaoDeTreino",
                column: "PlanoDeTreinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioDaSessao");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "SessaoDeTreino");

            migrationBuilder.DropTable(
                name: "PlanoDeTreino");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
