using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    public partial class TBLASENESPANOABC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abc_AtributoRol_Abc_Rol_RolId",
                table: "Abc_AtributoRol");

            migrationBuilder.DropForeignKey(
                name: "FK_Abc_AtributoUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_AtributoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Abc_LoginUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_LoginUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Abc_RolUsuario_Abc_Rol_RolId",
                table: "Abc_RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Abc_RolUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Abc_TokenUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_Usuario",
                table: "Abc_Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_TokenUsuario",
                table: "Abc_TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_RolUsuario",
                table: "Abc_RolUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_Rol",
                table: "Abc_Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_LoginUsuario",
                table: "Abc_LoginUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_AtributoUsuario",
                table: "Abc_AtributoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abc_AtributoRol",
                table: "Abc_AtributoRol");

            migrationBuilder.RenameTable(
                name: "Abc_Usuario",
                newName: "ABC_Usuario");

            migrationBuilder.RenameTable(
                name: "Abc_TokenUsuario",
                newName: "ABC_TokenUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_RolUsuario",
                newName: "ABC_RolUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_Rol",
                newName: "ABC_Rol");

            migrationBuilder.RenameTable(
                name: "Abc_LoginUsuario",
                newName: "ABC_LoginUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_AtributoUsuario",
                newName: "ABC_AtributoUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_AtributoRol",
                newName: "ABC_AtributoRol");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_RolUsuario_RolId",
                table: "ABC_RolUsuario",
                newName: "IX_ABC_RolUsuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_LoginUsuario_UsuarioId",
                table: "ABC_LoginUsuario",
                newName: "IX_ABC_LoginUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_AtributoUsuario_UsuarioId",
                table: "ABC_AtributoUsuario",
                newName: "IX_ABC_AtributoUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_AtributoRol_RolId",
                table: "ABC_AtributoRol",
                newName: "IX_ABC_AtributoRol_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_Usuario",
                table: "ABC_Usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_TokenUsuario",
                table: "ABC_TokenUsuario",
                columns: new[] { "UsuarioId", "ProveedorInicioSesion", "Nombre" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_RolUsuario",
                table: "ABC_RolUsuario",
                columns: new[] { "UsuarioId", "RolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_Rol",
                table: "ABC_Rol",
                column: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_LoginUsuario",
                table: "ABC_LoginUsuario",
                columns: new[] { "ProveedorInicioSesion", "LlaveProveedor" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_AtributoUsuario",
                table: "ABC_AtributoUsuario",
                column: "AtributoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ABC_AtributoRol",
                table: "ABC_AtributoRol",
                column: "AtributoRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_AtributoRol_ABC_Rol_RolId",
                table: "ABC_AtributoRol",
                column: "RolId",
                principalTable: "ABC_Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_AtributoUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_AtributoUsuario",
                column: "UsuarioId",
                principalTable: "ABC_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_LoginUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_LoginUsuario",
                column: "UsuarioId",
                principalTable: "ABC_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_RolUsuario_ABC_Rol_RolId",
                table: "ABC_RolUsuario",
                column: "RolId",
                principalTable: "ABC_Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_RolUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_RolUsuario",
                column: "UsuarioId",
                principalTable: "ABC_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ABC_TokenUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_TokenUsuario",
                column: "UsuarioId",
                principalTable: "ABC_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ABC_AtributoRol_ABC_Rol_RolId",
                table: "ABC_AtributoRol");

            migrationBuilder.DropForeignKey(
                name: "FK_ABC_AtributoUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_AtributoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ABC_LoginUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_LoginUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ABC_RolUsuario_ABC_Rol_RolId",
                table: "ABC_RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ABC_RolUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ABC_TokenUsuario_ABC_Usuario_UsuarioId",
                table: "ABC_TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_Usuario",
                table: "ABC_Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_TokenUsuario",
                table: "ABC_TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_RolUsuario",
                table: "ABC_RolUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_Rol",
                table: "ABC_Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_LoginUsuario",
                table: "ABC_LoginUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_AtributoUsuario",
                table: "ABC_AtributoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ABC_AtributoRol",
                table: "ABC_AtributoRol");

            migrationBuilder.RenameTable(
                name: "ABC_Usuario",
                newName: "Abc_Usuario");

            migrationBuilder.RenameTable(
                name: "ABC_TokenUsuario",
                newName: "Abc_TokenUsuario");

            migrationBuilder.RenameTable(
                name: "ABC_RolUsuario",
                newName: "Abc_RolUsuario");

            migrationBuilder.RenameTable(
                name: "ABC_Rol",
                newName: "Abc_Rol");

            migrationBuilder.RenameTable(
                name: "ABC_LoginUsuario",
                newName: "Abc_LoginUsuario");

            migrationBuilder.RenameTable(
                name: "ABC_AtributoUsuario",
                newName: "Abc_AtributoUsuario");

            migrationBuilder.RenameTable(
                name: "ABC_AtributoRol",
                newName: "Abc_AtributoRol");

            migrationBuilder.RenameIndex(
                name: "IX_ABC_RolUsuario_RolId",
                table: "Abc_RolUsuario",
                newName: "IX_Abc_RolUsuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_ABC_LoginUsuario_UsuarioId",
                table: "Abc_LoginUsuario",
                newName: "IX_Abc_LoginUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ABC_AtributoUsuario_UsuarioId",
                table: "Abc_AtributoUsuario",
                newName: "IX_Abc_AtributoUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ABC_AtributoRol_RolId",
                table: "Abc_AtributoRol",
                newName: "IX_Abc_AtributoRol_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_Usuario",
                table: "Abc_Usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_TokenUsuario",
                table: "Abc_TokenUsuario",
                columns: new[] { "UsuarioId", "ProveedorInicioSesion", "Nombre" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_RolUsuario",
                table: "Abc_RolUsuario",
                columns: new[] { "UsuarioId", "RolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_Rol",
                table: "Abc_Rol",
                column: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_LoginUsuario",
                table: "Abc_LoginUsuario",
                columns: new[] { "ProveedorInicioSesion", "LlaveProveedor" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_AtributoUsuario",
                table: "Abc_AtributoUsuario",
                column: "AtributoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abc_AtributoRol",
                table: "Abc_AtributoRol",
                column: "AtributoRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_AtributoRol_Abc_Rol_RolId",
                table: "Abc_AtributoRol",
                column: "RolId",
                principalTable: "Abc_Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_AtributoUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_AtributoUsuario",
                column: "UsuarioId",
                principalTable: "Abc_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_LoginUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_LoginUsuario",
                column: "UsuarioId",
                principalTable: "Abc_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_RolUsuario_Abc_Rol_RolId",
                table: "Abc_RolUsuario",
                column: "RolId",
                principalTable: "Abc_Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_RolUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_RolUsuario",
                column: "UsuarioId",
                principalTable: "Abc_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abc_TokenUsuario_Abc_Usuario_UsuarioId",
                table: "Abc_TokenUsuario",
                column: "UsuarioId",
                principalTable: "Abc_Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
