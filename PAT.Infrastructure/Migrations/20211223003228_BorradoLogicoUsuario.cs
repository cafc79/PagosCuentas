using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    public partial class BorradoLogicoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ABC_Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ABC_Usuario");
        }
    }
}
