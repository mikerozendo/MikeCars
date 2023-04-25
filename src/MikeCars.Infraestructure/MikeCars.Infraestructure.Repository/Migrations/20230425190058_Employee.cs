using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikeCars.Infraestructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "[t-contato-info]",
                columns: table => new
                {
                    id = table.Column<int>(name: "[id]", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefoneresidencia = table.Column<string>(name: "[telefone-residencia]", type: "varchar(20)", maxLength: 20, nullable: true),
                    celular = table.Column<string>(name: "[celular]", type: "varchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(name: "[email]", type: "varchar(25)", maxLength: 25, nullable: true),
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[pk-contato-info]", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "[t-documento]",
                columns: table => new
                {
                    id = table.Column<int>(name: "[id]", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documento = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    idtipodocumento = table.Column<int>(name: "[id-tipo-documento]", type: "int", nullable: false),
                    idagente = table.Column<int>(name: "[id-agente]", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[pk-documento]", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "[t-endereco]",
                columns: table => new
                {
                    id = table.Column<int>(name: "[id]", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(name: "[logradouro]", type: "varchar", nullable: true),
                    numero = table.Column<string>(name: "[numero]", type: "varchar(10)", maxLength: 10, nullable: true),
                    bairro = table.Column<string>(name: "[bairro]", type: "varchar(45)", maxLength: 45, nullable: true),
                    cidade = table.Column<string>(name: "[cidade]", type: "varchar(150)", maxLength: 150, nullable: true),
                    pontoreferencia = table.Column<string>(name: "[ponto-referencia]", type: "varchar(225)", maxLength: 225, nullable: true),
                    uf = table.Column<string>(name: "[uf]", type: "varchar(2)", maxLength: 2, nullable: true),
                    idtipoendereco = table.Column<int>(name: "[id-tipo-endereco]", type: "int", nullable: false),
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[pk-endereco]", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "[t-pessoa-fisica]",
                columns: table => new
                {
                    id = table.Column<int>(name: "[id]", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(name: "[nome]", type: "varchar(300)", maxLength: 300, nullable: false),
                    nascimento = table.Column<DateTime>(name: "[nascimento]", type: "datetime", nullable: false),
                    IdAgenteModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[id-pessoa]", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "[t-agente]",
                columns: table => new
                {
                    id = table.Column<int>(name: "[id]", type: "int", nullable: false),
                    idtipoagente = table.Column<int>(name: "[id-tipo-agente]", type: "int", nullable: false),
                    idendereco = table.Column<int>(name: "[id-endereco]", type: "int", nullable: false),
                    idcontatoinfo = table.Column<int>(name: "[id-contato-info]", type: "int", nullable: false),
                    iddocumento = table.Column<int>(name: "[id-documento]", type: "int", nullable: false),
                    IdPessoaFisicaModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("[pk-agente]", x => x.id);
                    table.ForeignKey(
                        name: "FK_[t-agente]_[t-contato-info]_[id]",
                        column: x => x.id,
                        principalTable: "[t-contato-info]",
                        principalColumn: "[id]",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_[t-agente]_[t-documento]_[id]",
                        column: x => x.id,
                        principalTable: "[t-documento]",
                        principalColumn: "[id]",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_[t-agente]_[t-endereco]_[id]",
                        column: x => x.id,
                        principalTable: "[t-endereco]",
                        principalColumn: "[id]",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_[t-agente]_[t-pessoa-fisica]_[id]",
                        column: x => x.id,
                        principalTable: "[t-pessoa-fisica]",
                        principalColumn: "[id]",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "[idx-agente]",
                table: "[t-agente]",
                column: "[id]",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "[idx-id-documento]",
                table: "[t-documento]",
                column: "[id]");

            migrationBuilder.CreateIndex(
                name: "[idx-numero-documento]",
                table: "[t-documento]",
                column: "documento");

            migrationBuilder.CreateIndex(
                name: "[dx-pessoa-fisica]",
                table: "[t-pessoa-fisica]",
                column: "[id]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "[t-agente]");

            migrationBuilder.DropTable(
                name: "[t-contato-info]");

            migrationBuilder.DropTable(
                name: "[t-documento]");

            migrationBuilder.DropTable(
                name: "[t-endereco]");

            migrationBuilder.DropTable(
                name: "[t-pessoa-fisica]");
        }
    }
}
