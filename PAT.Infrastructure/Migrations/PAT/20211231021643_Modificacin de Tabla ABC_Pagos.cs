using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations.PAT
{
    public partial class ModificacindeTablaABC_Pagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "ABC_Pagos",
                type: "nvarchar(38)",
                maxLength: 38,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedioPago",
                table: "ABC_Pagos",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MontoPago",
                table: "ABC_Pagos",
                type: "float",
                maxLength: 20,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "ABC_Pagos",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumCheque",
                table: "ABC_Pagos",
                type: "nvarchar(38)",
                maxLength: 38,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumOperacion",
                table: "ABC_Pagos",
                type: "nvarchar(38)",
                maxLength: 38,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "ABC_Pagos");

            migrationBuilder.DropColumn(
                name: "MedioPago",
                table: "ABC_Pagos");

            migrationBuilder.DropColumn(
                name: "MontoPago",
                table: "ABC_Pagos");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "ABC_Pagos");

            migrationBuilder.DropColumn(
                name: "NumCheque",
                table: "ABC_Pagos");

            migrationBuilder.DropColumn(
                name: "NumOperacion",
                table: "ABC_Pagos");
        }
    }
}
