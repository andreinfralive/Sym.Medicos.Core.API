using Microsoft.EntityFrameworkCore.Migrations;

namespace Sym.Medicos.Core.Repository.Migrations
{
    public partial class AlteracaoTabelaVinculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CRM",
                table: "vinculoMedicoConsultorios",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeConsultorio",
                table: "vinculoMedicoConsultorios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeMedico",
                table: "vinculoMedicoConsultorios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRM",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropColumn(
                name: "NomeConsultorio",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropColumn(
                name: "NomeMedico",
                table: "vinculoMedicoConsultorios");
        }
    }
}
