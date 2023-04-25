using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class ABCEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conceptp",
                table: "ABC_Cuentas_Por_Pagar");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "ABC_Cuentas_Por_Pagar");

            migrationBuilder.RenameColumn(
                name: "Proveedor",
                table: "ABC_Cuentas_Por_Pagar",
                newName: "Concepto");

            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "ABC_Cuentas_Por_Pagar",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "ABC_Cuentas_Por_Pagar",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "ABC_Cuentas_Por_Pagar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "ABC_Cuentas_Por_Pagar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ABC_Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(91)", maxLength: 91, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABC_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ABC_Proveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(91)", maxLength: 91, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABC_Proveedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABC_Empresa");

            migrationBuilder.DropTable(
                name: "ABC_Proveedor");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "ABC_Cuentas_Por_Pagar");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "ABC_Cuentas_Por_Pagar");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "ABC_Cuentas_Por_Pagar");

            migrationBuilder.RenameColumn(
                name: "Concepto",
                table: "ABC_Cuentas_Por_Pagar",
                newName: "Proveedor");

            migrationBuilder.AlterColumn<float>(
                name: "Monto",
                table: "ABC_Cuentas_Por_Pagar",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Conceptp",
                table: "ABC_Cuentas_Por_Pagar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "ABC_Cuentas_Por_Pagar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
