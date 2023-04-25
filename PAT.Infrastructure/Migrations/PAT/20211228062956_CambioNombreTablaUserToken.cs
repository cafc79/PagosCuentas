using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class CambioNombreTablaUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "ABC_Pagos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "ABC_Pagos",
                newName: "Eliminado");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "ABC_Pagos",
                newName: "FechaActualizacion");

            migrationBuilder.CreateTable(
                name: "ABC_JwtTokenUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionRemota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABC_JwtTokenUsuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABC_JwtTokenUsuario");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "ABC_Pagos",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "FechaActualizacion",
                table: "ABC_Pagos",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Eliminado",
                table: "ABC_Pagos",
                newName: "Deleted");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoteAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });
        }
    }
}
