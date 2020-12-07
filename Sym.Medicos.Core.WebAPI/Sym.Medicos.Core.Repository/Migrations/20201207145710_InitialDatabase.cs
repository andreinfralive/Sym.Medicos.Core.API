using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sym.Medicos.Core.Repository.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    IdConsultorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeConsultorio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EnderecoConsultorio = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TelefoneConsultorio = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.IdConsultorio);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Crm = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    NomeMedico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ValorConsulta = table.Column<decimal>(type: "decimal(19,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SobreNomeUsuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EhAdministrador = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "vinculoMedicoConsultorios",
                columns: table => new
                {
                    IdVinculoMedicoConsultorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    MedicoIdMedico = table.Column<int>(type: "int", nullable: true),
                    IdConsultorio = table.Column<int>(type: "int", nullable: false),
                    ConsultorioIdConsultorio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vinculoMedicoConsultorios", x => x.IdVinculoMedicoConsultorio);
                    table.ForeignKey(
                        name: "FK_vinculoMedicoConsultorios_Consultorios_ConsultorioIdConsulto~",
                        column: x => x.ConsultorioIdConsultorio,
                        principalTable: "Consultorios",
                        principalColumn: "IdConsultorio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vinculoMedicoConsultorios_Medicos_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vinculoMedicoConsultorios_ConsultorioIdConsultorio",
                table: "vinculoMedicoConsultorios",
                column: "ConsultorioIdConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_vinculoMedicoConsultorios_MedicoIdMedico",
                table: "vinculoMedicoConsultorios",
                column: "MedicoIdMedico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "vinculoMedicoConsultorios");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
