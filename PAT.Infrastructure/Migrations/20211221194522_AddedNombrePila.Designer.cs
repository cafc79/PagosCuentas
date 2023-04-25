﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAT.Infrastructure.Context;

#nullable disable

namespace PAT.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationIdentityContext))]
    [Migration("20211221194522_AddedNombrePila")]
    partial class AddedNombrePila
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("RolId")
                        .HasComment("Obtiene o establece la llave primaria para este rol");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EstampaDeConcurrencia")
                        .HasComment("Un valor aleatorio que debe cambiar cada vez que el rol es persistido en la tabla");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreRol")
                        .HasComment("Obtiene o establece el nombre para este rol");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreNormalizado")
                        .HasComment("Obtiene o establece el nombre normalizado para este rol");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NombreNormalizado] IS NOT NULL");

                    b.ToTable("ABC_Rol", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AtributoRolId")
                        .HasComment("");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoAtributo")
                        .HasComment("Obtiene o establece el tipo de atributo");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValorAtributo")
                        .HasComment("Obtiene o establece el valor para el atributo");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("RolId")
                        .HasComment("Obtiene o establece la llave primaria del rol asociado con este atributo");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ABC_AtributoRol", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AtributoUsuarioId")
                        .HasComment("Obtiene o establece el id para este atributo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoAtributo")
                        .HasComment("Obtiene o establece el tipo de atributo");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValorAtributo")
                        .HasComment("Obtiene o establce el valor del atributo");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UsuarioId")
                        .HasComment("Obtiene o establece la llave primaria asociado a este atributo");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ABC_AtributoUsuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ProveedorInicioSesion")
                        .HasComment("Obtiene o establece el proveedor del inicio de sesión(e.g facebook, google)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("LlaveProveedor")
                        .HasComment("Obtiene o establece la llave del proveedor de inicio de sesión");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreProveedor")
                        .HasComment("Obtiene o establece el nombre de la UI para el inicio de sesión");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UsuarioId")
                        .HasComment("Obtiene o establece el id de usuario");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("ABC_LoginUsuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UsuarioId")
                        .HasComment("Obtiene o establece el id del usuario");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("RolId")
                        .HasComment("Obtiene o establce el id del rol");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ABC_RolUsuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UsuarioId")
                        .HasComment("Obtiene o establece el id de usuario");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ProveedorInicioSesion")
                        .HasComment("Obtiene o establce el proveedor del inicio de sesión");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Nombre")
                        .HasComment("Obtiene o establece el nombre del token");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Valor")
                        .HasComment("Obtiene o establece el valor");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("ABC_TokenUsuario", (string)null);
                });

            modelBuilder.Entity("PAT.Models.Identity.PATUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UsuarioId")
                        .HasComment("Obtiene o establece el nombre de usuario");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("NumeroIntentosFallido")
                        .HasComment("Obtiene o establece el número de intentos fallidos en la autenticación para este usuario");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelloConcurrente")
                        .HasComment("Un valor aleatorio que debe cambiar cada vez que un usuario persiste en el sitio");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Correo")
                        .HasComment("Obtiene o establece el correo de un usuario");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("ConfirmacionCorreo")
                        .HasComment("Obtiene o establece un indicador si el usuario ha confirmado el correo");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("Bloqueado")
                        .HasComment("Obtiene o establece un indicador si el usuario fue bloqueado");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("FechaFinalizaBloqueo")
                        .HasComment("Obtiene o establece la fecha y la hora en UTC cuando finaliza el bloqueo de un usuario");

                    b.Property<string>("NombrePila")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombrePila")
                        .HasComment("Nombre de pila del usaurio de la aplicación");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("CorreoNormalizado")
                        .HasComment("Obtiene o establece el correo normalizado para este usuario");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreUsuarioNormalizado")
                        .HasComment("Obtiene o establece el Nombre normalizado para este usuario");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HashContrasena")
                        .HasComment("Obtiene o establece una representación hash de la contraseña de este usuario");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefono")
                        .HasComment("Obtiene o establece el numero telefónico");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("ConfirmacionTelefono")
                        .HasComment("Obtiene o establece un indicador si el teléfono fue confirmado");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelloDeSeguridad")
                        .HasComment("Un valor aleatorio que debe cambiar cada vez que cambian las credenciales de un usuario (contraseña a cambiado, inicio de sesión eliminado)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("HabilitardosFactores")
                        .HasComment("Obtiene o establece una bandera indicadora para habilitar la autenticación de dos factores para este usuario");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreUsuario")
                        .HasComment("Obtiene o establece el nombre de usuario");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NombreUsuarioNormalizado] IS NOT NULL");

                    b.ToTable("ABC_Usuario", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PAT.Models.Identity.PATUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PAT.Models.Identity.PATUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PAT.Models.Identity.PATUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PAT.Models.Identity.PATUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
