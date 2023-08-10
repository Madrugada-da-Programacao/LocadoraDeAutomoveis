using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TBPlanoDeCobrancaModificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomoveis_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca");

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId1",
                unique: true,
                filter: "[GrupoDeAutomoveisId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomoveis_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId1",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId",
                principalTable: "TBGrupoDeAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
