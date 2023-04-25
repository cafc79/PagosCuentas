using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class addtablaaurorizacionpago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autorizacion_Pago",
                table: "Autorizacion_Pago");

            migrationBuilder.RenameTable(
                name: "Autorizacion_Pago",
                newName: "ABCAutorizacion_Pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABCAutorizacion_Pago",
                table: "ABCAutorizacion_Pago",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ABCAutorizacion_Pago",
                table: "ABCAutorizacion_Pago");

            migrationBuilder.RenameTable(
                name: "ABCAutorizacion_Pago",
                newName: "Autorizacion_Pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autorizacion_Pago",
                table: "Autorizacion_Pago",
                column: "Id");
        }
    }
}
