using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddTBPlanoDeCobrancaAtualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmDisponiveis",
                table: "TBPlanoDeCobranca");

            migrationBuilder.RenameColumn(
                name: "TipoDoPlano",
                table: "TBPlanoDeCobranca",
                newName: "KmDisponiveisKmControlado");

            migrationBuilder.RenameColumn(
                name: "PrecoKm",
                table: "TBPlanoDeCobranca",
                newName: "PrecoKmPlanoDiario");

            migrationBuilder.RenameColumn(
                name: "PrecoDiaria",
                table: "TBPlanoDeCobranca",
                newName: "PrecoKmExtrapoladoKmControlado");

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoDeAutomoveisId",
                table: "TBPlanoDeCobranca",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiariaKmControlado",
                table: "TBPlanoDeCobranca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiariaKmLivre",
                table: "TBPlanoDeCobranca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiariaPlanoDiario",
                table: "TBPlanoDeCobranca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeAutomoveisId",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeAutomoveisId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomoveis_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoDeCobranca_TBGrupoDeAutomovel",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeAutomoveisId",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "GrupoDeAutomoveisId",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "GrupoDeAutomoveisId1",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "PrecoDiariaKmControlado",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "PrecoDiariaKmLivre",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "PrecoDiariaPlanoDiario",
                table: "TBPlanoDeCobranca");

            migrationBuilder.RenameColumn(
                name: "PrecoKmPlanoDiario",
                table: "TBPlanoDeCobranca",
                newName: "PrecoKm");

            migrationBuilder.RenameColumn(
                name: "PrecoKmExtrapoladoKmControlado",
                table: "TBPlanoDeCobranca",
                newName: "PrecoDiaria");

            migrationBuilder.RenameColumn(
                name: "KmDisponiveisKmControlado",
                table: "TBPlanoDeCobranca",
                newName: "TipoDoPlano");

            migrationBuilder.AddColumn<int>(
                name: "KmDisponiveis",
                table: "TBPlanoDeCobranca",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
