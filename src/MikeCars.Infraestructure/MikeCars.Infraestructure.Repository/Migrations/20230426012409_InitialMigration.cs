using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikeCars.Infraestructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoAgente = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdContatoInfo = table.Column<int>(type: "int", nullable: false),
                    IdDocumento = table.Column<int>(type: "int", nullable: false),
                    IdPessoaFisicaModel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkAgente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContatoInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneResidencial = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkContatoInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatoInfo_Agente_IdAgente",
                        column: x => x.IdAgente,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Agente_IdAgente",
                        column: x => x.IdAgente,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    IdTipoEndereco = table.Column<int>(type: "int", nullable: false),
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkendereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Agente_IdAgente",
                        column: x => x.IdAgente,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAgenteModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Agente_IdAgenteModel",
                        column: x => x.IdAgenteModel,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idxAgente",
                table: "Agente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoInfo_IdAgente",
                table: "ContatoInfo",
                column: "IdAgente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idxiddocumento",
                table: "Documento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idxnumerodocumento",
                table: "Documento",
                column: "Numero");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_IdAgente",
                table: "Documento",
                column: "IdAgente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdAgente",
                table: "Endereco",
                column: "IdAgente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idxpessoafisica",
                table: "PessoaFisica",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_IdAgenteModel",
                table: "PessoaFisica",
                column: "IdAgenteModel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoInfo");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "Agente");
        }
    }
}
