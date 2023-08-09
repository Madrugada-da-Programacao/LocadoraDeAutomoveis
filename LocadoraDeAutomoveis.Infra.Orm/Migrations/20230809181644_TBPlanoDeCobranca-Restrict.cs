using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TBPlanoDeCobrancaRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id");
        }
    }
}
