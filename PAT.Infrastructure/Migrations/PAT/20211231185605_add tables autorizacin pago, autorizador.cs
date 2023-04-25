using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class addtablesautorizacinpagoautorizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ABCAutorizador",
                table: "ABCAutorizador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABCAutorizacion_Pago",
                table: "ABCAutorizacion_Pago");

            migrationBuilder.RenameTable(
                name: "ABCAutorizador",
                newName: "ABC_Autorizador");

            migrationBuilder.RenameTable(
                name: "ABCAutorizacion_Pago",
                newName: "ABC_Autorizacion_Pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_Autorizador",
                table: "ABC_Autorizador",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_Autorizacion_Pago",
                table: "ABC_Autorizacion_Pago",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_Autorizador",
                table: "ABC_Autorizador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_Autorizacion_Pago",
                table: "ABC_Autorizacion_Pago");

            migrationBuilder.RenameTable(
                name: "ABC_Autorizador",
                newName: "ABCAutorizador");

            migrationBuilder.RenameTable(
                name: "ABC_Autorizacion_Pago",
                newName: "ABCAutorizacion_Pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABCAutorizador",
                table: "ABCAutorizador",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABCAutorizacion_Pago",
                table: "ABCAutorizacion_Pago",
                column: "Id");
        }
    }
}
