using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikeCars.Infraestructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Adjustingdbobjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_[t-agente]_[t-contato-info]_[id]",
                table: "[t-agente]");

            migrationBuilder.DropForeignKey(
                name: "FK_[t-agente]_[t-documento]_[id]",
                table: "[t-agente]");

            migrationBuilder.DropForeignKey(
                name: "FK_[t-agente]_[t-endereco]_[id]",
                table: "[t-agente]");

            migrationBuilder.DropForeignKey(
                name: "FK_[t-agente]_[t-pessoa-fisica]_[id]",
                table: "[t-agente]");

            migrationBuilder.DropPrimaryKey(
                name: "[id-pessoa]",
                table: "[t-pessoa-fisica]");

            migrationBuilder.DropPrimaryKey(
                name: "[pk-endereco]",
                table: "[t-endereco]");

            migrationBuilder.DropPrimaryKey(
                name: "[pk-documento]",
                table: "[t-documento]");

            migrationBuilder.DropPrimaryKey(
                name: "[pk-contato-info]",
                table: "[t-contato-info]");

            migrationBuilder.DropPrimaryKey(
                name: "[pk-agente]",
                table: "[t-agente]");

            migrationBuilder.RenameTable(
                name: "[t-pessoa-fisica]",
                newName: "t-pessoa-fisica");

            migrationBuilder.RenameTable(
                name: "[t-endereco]",
                newName: "t-endereco");

            migrationBuilder.RenameTable(
                name: "[t-documento]",
                newName: "t-documento");

            migrationBuilder.RenameTable(
                name: "[t-contato-info]",
                newName: "t-contato-info");

            migrationBuilder.RenameTable(
                name: "[t-agente]",
                newName: "t-agente");

            migrationBuilder.RenameColumn(
                name: "[nome]",
                table: "t-pessoa-fisica",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "[nascimento]",
                table: "t-pessoa-fisica",
                newName: "nascimento");

            migrationBuilder.RenameColumn(
                name: "[id]",
                table: "t-pessoa-fisica",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "[dx-pessoa-fisica]",
                table: "t-pessoa-fisica",
                newName: "dx-pessoa-fisica");

            migrationBuilder.RenameColumn(
                name: "[uf]",
                table: "t-endereco",
                newName: "uf");

            migrationBuilder.RenameColumn(
                name: "[ponto-referencia]",
                table: "t-endereco",
                newName: "ponto-referencia");

            migrationBuilder.RenameColumn(
                name: "[numero]",
                table: "t-endereco",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "[logradouro]",
                table: "t-endereco",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "[id-tipo-endereco]",
                table: "t-endereco",
                newName: "id-tipo-endereco");

            migrationBuilder.RenameColumn(
                name: "[cidade]",
                table: "t-endereco",
                newName: "cidade");

            migrationBuilder.RenameColumn(
                name: "[bairro]",
                table: "t-endereco",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "[id]",
                table: "t-endereco",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "[id-tipo-documento]",
                table: "t-documento",
                newName: "id-tipo-documento");

            migrationBuilder.RenameColumn(
                name: "[id-agente]",
                table: "t-documento",
                newName: "id-agente");

            migrationBuilder.RenameColumn(
                name: "[id]",
                table: "t-documento",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "[idx-numero-documento]",
                table: "t-documento",
                newName: "idx-numero-documento");

            migrationBuilder.RenameIndex(
                name: "[idx-id-documento]",
                table: "t-documento",
                newName: "idx-id-documento");

            migrationBuilder.RenameColumn(
                name: "[telefone-residencia]",
                table: "t-contato-info",
                newName: "telefone-residencia");

            migrationBuilder.RenameColumn(
                name: "[email]",
                table: "t-contato-info",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "[celular]",
                table: "t-contato-info",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "[id]",
                table: "t-contato-info",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "[id-tipo-agente]",
                table: "t-agente",
                newName: "id-tipo-agente");

            migrationBuilder.RenameColumn(
                name: "[id-endereco]",
                table: "t-agente",
                newName: "id-endereco");

            migrationBuilder.RenameColumn(
                name: "[id-documento]",
                table: "t-agente",
                newName: "id-documento");

            migrationBuilder.RenameColumn(
                name: "[id-contato-info]",
                table: "t-agente",
                newName: "id-contato-info");

            migrationBuilder.RenameColumn(
                name: "[id]",
                table: "t-agente",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "[idx-agente]",
                table: "t-agente",
                newName: "idx-agente");

            migrationBuilder.AddPrimaryKey(
                name: "id-pessoa",
                table: "t-pessoa-fisica",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk-endereco",
                table: "t-endereco",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk-documento",
                table: "t-documento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk-contato-info",
                table: "t-contato-info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk-agente",
                table: "t-agente",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_t-agente_t-contato-info_id",
                table: "t-agente",
                column: "id",
                principalTable: "t-contato-info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t-agente_t-documento_id",
                table: "t-agente",
                column: "id",
                principalTable: "t-documento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t-agente_t-endereco_id",
                table: "t-agente",
                column: "id",
                principalTable: "t-endereco",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t-agente_t-pessoa-fisica_id",
                table: "t-agente",
                column: "id",
                principalTable: "t-pessoa-fisica",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t-agente_t-contato-info_id",
                table: "t-agente");

            migrationBuilder.DropForeignKey(
                name: "FK_t-agente_t-documento_id",
                table: "t-agente");

            migrationBuilder.DropForeignKey(
                name: "FK_t-agente_t-endereco_id",
                table: "t-agente");

            migrationBuilder.DropForeignKey(
                name: "FK_t-agente_t-pessoa-fisica_id",
                table: "t-agente");

            migrationBuilder.DropPrimaryKey(
                name: "id-pessoa",
                table: "t-pessoa-fisica");

            migrationBuilder.DropPrimaryKey(
                name: "pk-endereco",
                table: "t-endereco");

            migrationBuilder.DropPrimaryKey(
                name: "pk-documento",
                table: "t-documento");

            migrationBuilder.DropPrimaryKey(
                name: "pk-contato-info",
                table: "t-contato-info");

            migrationBuilder.DropPrimaryKey(
                name: "pk-agente",
                table: "t-agente");

            migrationBuilder.RenameTable(
                name: "t-pessoa-fisica",
                newName: "[t-pessoa-fisica]");

            migrationBuilder.RenameTable(
                name: "t-endereco",
                newName: "[t-endereco]");

            migrationBuilder.RenameTable(
                name: "t-documento",
                newName: "[t-documento]");

            migrationBuilder.RenameTable(
                name: "t-contato-info",
                newName: "[t-contato-info]");

            migrationBuilder.RenameTable(
                name: "t-agente",
                newName: "[t-agente]");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "[t-pessoa-fisica]",
                newName: "[nome]");

            migrationBuilder.RenameColumn(
                name: "nascimento",
                table: "[t-pessoa-fisica]",
                newName: "[nascimento]");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "[t-pessoa-fisica]",
                newName: "[id]");

            migrationBuilder.RenameIndex(
                name: "dx-pessoa-fisica",
                table: "[t-pessoa-fisica]",
                newName: "[dx-pessoa-fisica]");

            migrationBuilder.RenameColumn(
                name: "uf",
                table: "[t-endereco]",
                newName: "[uf]");

            migrationBuilder.RenameColumn(
                name: "ponto-referencia",
                table: "[t-endereco]",
                newName: "[ponto-referencia]");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "[t-endereco]",
                newName: "[numero]");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "[t-endereco]",
                newName: "[logradouro]");

            migrationBuilder.RenameColumn(
                name: "id-tipo-endereco",
                table: "[t-endereco]",
                newName: "[id-tipo-endereco]");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "[t-endereco]",
                newName: "[cidade]");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "[t-endereco]",
                newName: "[bairro]");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "[t-endereco]",
                newName: "[id]");

            migrationBuilder.RenameColumn(
                name: "id-tipo-documento",
                table: "[t-documento]",
                newName: "[id-tipo-documento]");

            migrationBuilder.RenameColumn(
                name: "id-agente",
                table: "[t-documento]",
                newName: "[id-agente]");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "[t-documento]",
                newName: "[id]");

            migrationBuilder.RenameIndex(
                name: "idx-numero-documento",
                table: "[t-documento]",
                newName: "[idx-numero-documento]");

            migrationBuilder.RenameIndex(
                name: "idx-id-documento",
                table: "[t-documento]",
                newName: "[idx-id-documento]");

            migrationBuilder.RenameColumn(
                name: "telefone-residencia",
                table: "[t-contato-info]",
                newName: "[telefone-residencia]");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "[t-contato-info]",
                newName: "[email]");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "[t-contato-info]",
                newName: "[celular]");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "[t-contato-info]",
                newName: "[id]");

            migrationBuilder.RenameColumn(
                name: "id-tipo-agente",
                table: "[t-agente]",
                newName: "[id-tipo-agente]");

            migrationBuilder.RenameColumn(
                name: "id-endereco",
                table: "[t-agente]",
                newName: "[id-endereco]");

            migrationBuilder.RenameColumn(
                name: "id-documento",
                table: "[t-agente]",
                newName: "[id-documento]");

            migrationBuilder.RenameColumn(
                name: "id-contato-info",
                table: "[t-agente]",
                newName: "[id-contato-info]");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "[t-agente]",
                newName: "[id]");

            migrationBuilder.RenameIndex(
                name: "idx-agente",
                table: "[t-agente]",
                newName: "[idx-agente]");

            migrationBuilder.AddPrimaryKey(
                name: "[id-pessoa]",
                table: "[t-pessoa-fisica]",
                column: "[id]");

            migrationBuilder.AddPrimaryKey(
                name: "[pk-endereco]",
                table: "[t-endereco]",
                column: "[id]");

            migrationBuilder.AddPrimaryKey(
                name: "[pk-documento]",
                table: "[t-documento]",
                column: "[id]");

            migrationBuilder.AddPrimaryKey(
                name: "[pk-contato-info]",
                table: "[t-contato-info]",
                column: "[id]");

            migrationBuilder.AddPrimaryKey(
                name: "[pk-agente]",
                table: "[t-agente]",
                column: "[id]");

            migrationBuilder.AddForeignKey(
                name: "FK_[t-agente]_[t-contato-info]_[id]",
                table: "[t-agente]",
                column: "[id]",
                principalTable: "[t-contato-info]",
                principalColumn: "[id]",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_[t-agente]_[t-documento]_[id]",
                table: "[t-agente]",
                column: "[id]",
                principalTable: "[t-documento]",
                principalColumn: "[id]",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_[t-agente]_[t-endereco]_[id]",
                table: "[t-agente]",
                column: "[id]",
                principalTable: "[t-endereco]",
                principalColumn: "[id]",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_[t-agente]_[t-pessoa-fisica]_[id]",
                table: "[t-agente]",
                column: "[id]",
                principalTable: "[t-pessoa-fisica]",
                principalColumn: "[id]",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
