using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    public partial class tabaenespanolabc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtributoRol_Rol_RolId",
                table: "AtributoRol");

            migrationBuilder.DropForeignKey(
                name: "FK_AtributoUsuario_Usuario_UsuarioId",
                table: "AtributoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginUsuario_Usuario_UsuarioId",
                table: "LoginUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RolUsuario_Rol_RolId",
                table: "RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RolUsuario_Usuario_UsuarioId",
                table: "RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_TokenUsuario_Usuario_UsuarioId",
                table: "TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokenUsuario",
                table: "TokenUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUsuario",
                table: "RolUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginUsuario",
                table: "LoginUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributoUsuario",
                table: "AtributoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtributoRol",
                table: "AtributoRol");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Abc_Usuario");

            migrationBuilder.RenameTable(
                name: "TokenUsuario",
                newName: "Abc_TokenUsuario");

            migrationBuilder.RenameTable(
                name: "RolUsuario",
                newName: "Abc_RolUsuario");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Abc_Rol");

            migrationBuilder.RenameTable(
                name: "LoginUsuario",
                newName: "Abc_LoginUsuario");

            migrationBuilder.RenameTable(
                name: "AtributoUsuario",
                newName: "Abc_AtributoUsuario");

            migrationBuilder.RenameTable(
                name: "AtributoRol",
                newName: "Abc_AtributoRol");

            migrationBuilder.RenameIndex(
                name: "IX_RolUsuario_RolId",
                table: "Abc_RolUsuario",
                newName: "IX_Abc_RolUsuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginUsuario_UsuarioId",
                table: "Abc_LoginUsuario",
                newName: "IX_Abc_LoginUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_AtributoUsuario_UsuarioId",
                table: "Abc_AtributoUsuario",
                newName: "IX_Abc_AtributoUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_AtributoRol_RolId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Abc_TokenUsuario",
                newName: "TokenUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_RolUsuario",
                newName: "RolUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_Rol",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "Abc_LoginUsuario",
                newName: "LoginUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_AtributoUsuario",
                newName: "AtributoUsuario");

            migrationBuilder.RenameTable(
                name: "Abc_AtributoRol",
                newName: "AtributoRol");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_RolUsuario_RolId",
                table: "RolUsuario",
                newName: "IX_RolUsuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_LoginUsuario_UsuarioId",
                table: "LoginUsuario",
                newName: "IX_LoginUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_AtributoUsuario_UsuarioId",
                table: "AtributoUsuario",
                newName: "IX_AtributoUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Abc_AtributoRol_RolId",
                table: "AtributoRol",
                newName: "IX_AtributoRol_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenUsuario",
                table: "TokenUsuario",
                columns: new[] { "UsuarioId", "ProveedorInicioSesion", "Nombre" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUsuario",
                table: "RolUsuario",
                columns: new[] { "UsuarioId", "RolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginUsuario",
                table: "LoginUsuario",
                columns: new[] { "ProveedorInicioSesion", "LlaveProveedor" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributoUsuario",
                table: "AtributoUsuario",
                column: "AtributoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributoRol",
                table: "AtributoRol",
                column: "AtributoRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtributoRol_Rol_RolId",
                table: "AtributoRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtributoUsuario_Usuario_UsuarioId",
                table: "AtributoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginUsuario_Usuario_UsuarioId",
                table: "LoginUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolUsuario_Rol_RolId",
                table: "RolUsuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolUsuario_Usuario_UsuarioId",
                table: "RolUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenUsuario_Usuario_UsuarioId",
                table: "TokenUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
