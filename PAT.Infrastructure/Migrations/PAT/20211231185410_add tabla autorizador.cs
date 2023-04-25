using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class addtablaautorizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autorizador",
                table: "Autorizador");

            migrationBuilder.RenameTable(
                name: "Autorizador",
                newName: "ABCAutorizador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABCAutorizador",
                table: "ABCAutorizador",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ABCAutorizador",
                table: "ABCAutorizador");

            migrationBuilder.RenameTable(
                name: "ABCAutorizador",
                newName: "Autorizador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autorizador",
                table: "Autorizador",
                column: "Id");
        }
    }
}
