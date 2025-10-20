using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuFitCoach.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipmentos",
                table: "SessoesConversa");

            migrationBuilder.RenameColumn(
                name: "NumeroWhatsapp",
                table: "Usuario",
                newName: "NumeroTelefone");

            migrationBuilder.AddColumn<string>(
                name: "Equipamentos",
                table: "SessoesConversa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoEscolhido",
                table: "SessoesConversa",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipamentos",
                table: "SessoesConversa");

            migrationBuilder.DropColumn(
                name: "PlanoEscolhido",
                table: "SessoesConversa");

            migrationBuilder.RenameColumn(
                name: "NumeroTelefone",
                table: "Usuario",
                newName: "NumeroWhatsapp");

            migrationBuilder.AddColumn<string>(
                name: "Equipmentos",
                table: "SessoesConversa",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
