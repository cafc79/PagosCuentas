using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    public partial class tablasenespañol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "TokenUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "RolUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "LoginUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AtributoUsuario");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AtributoRol");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TokenUsuario",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TokenUsuario",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "TokenUsuario",
                newName: "ProveedorInicioSesion");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TokenUsuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuario",
                newName: "NombreUsuario");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "Usuario",
                newName: "HabilitardosFactores");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Usuario",
                newName: "SelloDeSeguridad");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "Usuario",
                newName: "ConfirmacionTelefono");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Usuario",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Usuario",
                newName: "HashContrasena");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "Usuario",
                newName: "NombreUsuarioNormalizado");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "Usuario",
                newName: "CorreoNormalizado");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "Usuario",
                newName: "FechaFinalizaBloqueo");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "Usuario",
                newName: "Bloqueado");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "Usuario",
                newName: "ConfirmacionCorreo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "Usuario",
                newName: "SelloConcurrente");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "Usuario",
                newName: "NumeroIntentosFallido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RolUsuario",
                newName: "RolId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RolUsuario",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "RolUsuario",
                newName: "IX_RolUsuario_RolId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LoginUsuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "LoginUsuario",
                newName: "NombreProveedor");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "LoginUsuario",
                newName: "LlaveProveedor");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "LoginUsuario",
                newName: "ProveedorInicioSesion");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "LoginUsuario",
                newName: "IX_LoginUsuario_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AtributoUsuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AtributoUsuario",
                newName: "ValorAtributo");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AtributoUsuario",
                newName: "TipoAtributo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AtributoUsuario",
                newName: "AtributoUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AtributoUsuario",
                newName: "IX_AtributoUsuario_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "Rol",
                newName: "NombreNormalizado");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rol",
                newName: "NombreRol");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "Rol",
                newName: "EstampaDeConcurrencia");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rol",
                newName: "RolId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AtributoRol",
                newName: "RolId");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AtributoRol",
                newName: "ValorAtributo");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AtributoRol",
                newName: "TipoAtributo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AtributoRol",
                newName: "AtributoRolId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AtributoRol",
                newName: "IX_AtributoRol_RolId");

            migrationBuilder.AlterColumn<string>(
                name: "Valor",
                table: "TokenUsuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el valor",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TokenUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el nombre del token",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProveedorInicioSesion",
                table: "TokenUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establce el proveedor del inicio de sesión",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "TokenUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el id de usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuario",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el nombre de usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HabilitardosFactores",
                table: "Usuario",
                type: "bit",
                nullable: false,
                comment: "Obtiene o establece una bandera indicadora para habilitar la autenticación de dos factores para este usuario",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "SelloDeSeguridad",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Un valor aleatorio que debe cambiar cada vez que cambian las credenciales de un usuario (contraseña a cambiado, inicio de sesión eliminado)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ConfirmacionTelefono",
                table: "Usuario",
                type: "bit",
                nullable: false,
                comment: "Obtiene o establece un indicador si el teléfono fue confirmado",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el numero telefónico",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HashContrasena",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece una representación hash de la contraseña de este usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuarioNormalizado",
                table: "Usuario",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el Nombre normalizado para este usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorreoNormalizado",
                table: "Usuario",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el correo normalizado para este usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FechaFinalizaBloqueo",
                table: "Usuario",
                type: "datetimeoffset",
                nullable: true,
                comment: "Obtiene o establece la fecha y la hora en UTC cuando finaliza el bloqueo de un usuario",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Bloqueado",
                table: "Usuario",
                type: "bit",
                nullable: false,
                comment: "Obtiene o establece un indicador si el usuario fue bloqueado",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ConfirmacionCorreo",
                table: "Usuario",
                type: "bit",
                nullable: false,
                comment: "Obtiene o establece un indicador si el usuario ha confirmado el correo",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el correo de un usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SelloConcurrente",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Un valor aleatorio que debe cambiar cada vez que un usuario persiste en el sitio",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroIntentosFallido",
                table: "Usuario",
                type: "int",
                nullable: false,
                comment: "Obtiene o establece el número de intentos fallidos en la autenticación para este usuario",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el nombre de usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RolId",
                table: "RolUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establce el id del rol",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "RolUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el id del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "LoginUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el id de usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProveedor",
                table: "LoginUsuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el nombre de la UI para el inicio de sesión",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LlaveProveedor",
                table: "LoginUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece la llave del proveedor de inicio de sesión",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProveedorInicioSesion",
                table: "LoginUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece el proveedor del inicio de sesión(e.g facebook, google)",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "AtributoUsuario",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece la llave primaria asociado a este atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ValorAtributo",
                table: "AtributoUsuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establce el valor del atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoAtributo",
                table: "AtributoUsuario",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el tipo de atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtributoUsuarioId",
                table: "AtributoUsuario",
                type: "int",
                nullable: false,
                comment: "Obtiene o establece el id para este atributo",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NombreNormalizado",
                table: "Rol",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el nombre normalizado para este rol",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreRol",
                table: "Rol",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Obtiene o establece el nombre para este rol",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstampaDeConcurrencia",
                table: "Rol",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Un valor aleatorio que debe cambiar cada vez que el rol es persistido en la tabla",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RolId",
                table: "Rol",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece la llave primaria para este rol",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RolId",
                table: "AtributoRol",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Obtiene o establece la llave primaria del rol asociado con este atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ValorAtributo",
                table: "AtributoRol",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el valor para el atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoAtributo",
                table: "AtributoRol",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Obtiene o establece el tipo de atributo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtributoRolId",
                table: "AtributoRol",
                type: "int",
                nullable: false,
                comment: "",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokenUsuario",
                table: "TokenUsuario",
                columns: new[] { "UsuarioId", "ProveedorInicioSesion", "Nombre" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUsuario",
                table: "RolUsuario",
                columns: new[] { "UsuarioId", "RolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginUsuario",
                table: "LoginUsuario",
                columns: new[] { "ProveedorInicioSesion", "LlaveProveedor" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributoUsuario",
                table: "AtributoUsuario",
                column: "AtributoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtributoRol",
                table: "AtributoRol",
                column: "AtributoRolId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuario",
                column: "NombreUsuarioNormalizado",
                unique: true,
                filter: "[NombreUsuarioNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Rol",
                column: "NombreNormalizado",
                unique: true,
                filter: "[NombreNormalizado] IS NOT NULL");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
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

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
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
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TokenUsuario",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "RolUsuario",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "LoginUsuario",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AtributoUsuario",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AtributoRol",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "SelloDeSeguridad",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "SelloConcurrente",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "NumeroIntentosFallido",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "NombreUsuarioNormalizado",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "HashContrasena",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "HabilitardosFactores",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "FechaFinalizaBloqueo",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "CorreoNormalizado",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ConfirmacionTelefono",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "ConfirmacionCorreo",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "Bloqueado",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProveedorInicioSesion",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RolUsuario_RolId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "NombreRol",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NombreNormalizado",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "EstampaDeConcurrencia",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "NombreProveedor",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "LlaveProveedor",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "ProveedorInicioSesion",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_LoginUsuario_UsuarioId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "ValorAtributo",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TipoAtributo",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "AtributoUsuarioId",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AtributoUsuario_UsuarioId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "ValorAtributo",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "TipoAtributo",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "AtributoRolId",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AtributoRol_RolId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el numero telefónico");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Un valor aleatorio que debe cambiar cada vez que cambian las credenciales de un usuario (contraseña a cambiado, inicio de sesión eliminado)");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Un valor aleatorio que debe cambiar cada vez que un usuario persiste en el sitio");

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Obtiene o establece el número de intentos fallidos en la autenticación para este usuario");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el Nombre normalizado para este usuario");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el nombre de usuario");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece una representación hash de la contraseña de este usuario");

            migrationBuilder.AlterColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Obtiene o establece una bandera indicadora para habilitar la autenticación de dos factores para este usuario");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true,
                oldComment: "Obtiene o establece la fecha y la hora en UTC cuando finaliza el bloqueo de un usuario");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el correo normalizado para este usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el correo de un usuario");

            migrationBuilder.AlterColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Obtiene o establece un indicador si el teléfono fue confirmado");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Obtiene o establece un indicador si el usuario ha confirmado el correo");

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Obtiene o establece un indicador si el usuario fue bloqueado");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el nombre de usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AspNetUserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el valor");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el nombre del token");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establce el proveedor del inicio de sesión");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el id de usuario");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establce el id del rol");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el id del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el nombre para este rol");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Obtiene o establece el nombre normalizado para este rol");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Un valor aleatorio que debe cambiar cada vez que el rol es persistido en la tabla");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece la llave primaria para este rol");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el id de usuario");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderDisplayName",
                table: "AspNetUserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el nombre de la UI para el inicio de sesión");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece la llave del proveedor de inicio de sesión");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece el proveedor del inicio de sesión(e.g facebook, google)");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                table: "AspNetUserClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establce el valor del atributo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece la llave primaria asociado a este atributo");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AspNetUserClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el tipo de atributo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Obtiene o establece el id para este atributo")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                table: "AspNetRoleClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el valor para el atributo");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                table: "AspNetRoleClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Obtiene o establece el tipo de atributo");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Obtiene o establece la llave primaria del rol asociado con este atributo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
