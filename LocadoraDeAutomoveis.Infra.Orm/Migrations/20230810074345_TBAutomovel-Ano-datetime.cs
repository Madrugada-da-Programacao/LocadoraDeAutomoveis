using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TBAutomovelAnodatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Ano",
                table: "TBAutomovel",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ano",
                table: "TBAutomovel",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
