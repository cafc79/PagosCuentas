using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    public partial class AddedNombrePila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombrePila",
                table: "ABC_Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Nombre de pila del usaurio de la aplicación");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombrePila",
                table: "ABC_Usuario");
        }
    }
}
