using Microsoft.EntityFrameworkCore.Migrations;

namespace Sym.Medicos.Core.Repository.Migrations
{
    public partial class AlteracaoVinculoConsultorioMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vinculoMedicoConsultorios_Consultorios_ConsultorioIdConsulto~",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropForeignKey(
                name: "FK_vinculoMedicoConsultorios_Medicos_MedicoIdMedico",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropIndex(
                name: "IX_vinculoMedicoConsultorios_ConsultorioIdConsultorio",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropIndex(
                name: "IX_vinculoMedicoConsultorios_MedicoIdMedico",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropColumn(
                name: "ConsultorioIdConsultorio",
                table: "vinculoMedicoConsultorios");

            migrationBuilder.DropColumn(
                name: "MedicoIdMedico",
                table: "vinculoMedicoConsultorios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultorioIdConsultorio",
                table: "vinculoMedicoConsultorios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoIdMedico",
                table: "vinculoMedicoConsultorios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vinculoMedicoConsultorios_ConsultorioIdConsultorio",
                table: "vinculoMedicoConsultorios",
                column: "ConsultorioIdConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_vinculoMedicoConsultorios_MedicoIdMedico",
                table: "vinculoMedicoConsultorios",
                column: "MedicoIdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_vinculoMedicoConsultorios_Consultorios_ConsultorioIdConsulto~",
                table: "vinculoMedicoConsultorios",
                column: "ConsultorioIdConsultorio",
                principalTable: "Consultorios",
                principalColumn: "IdConsultorio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vinculoMedicoConsultorios_Medicos_MedicoIdMedico",
                table: "vinculoMedicoConsultorios",
                column: "MedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
