using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAT.Common.Extensions;
using PAT.Models.Identity;

namespace PAT.Infrastructure.Context;

public class ApplicationIdentityContext
        : IdentityDbContext<PATUser, IdentityRole, string>
{
    public ApplicationIdentityContext(
        DbContextOptions<ApplicationIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>()
            .ToTable("ABC_Rol")
            .Execute(b => b.Property(p => p.ConcurrencyStamp)
                .HasColumnName("EstampaDeConcurrencia")
                .HasComment("Un valor aleatorio que debe cambiar cada vez que el rol es persistido en la tabla"))
            .Execute(b => b.Property(p => p.Id)
                .HasColumnName("RolId")
                .HasComment("Obtiene o establece la llave primaria para este rol"))
            .Execute(b => b.Property(p => p.Name)
                .HasColumnName("NombreRol")
                .HasComment("Obtiene o establece el nombre para este rol"))
            .Execute(b => b.Property(p => p.NormalizedName)
                .HasColumnName("NombreNormalizado")
                .HasComment("Obtiene o establece el nombre normalizado para este rol"));

        modelBuilder.Entity<IdentityRoleClaim<string>>()
            .ToTable("ABC_AtributoRol")
            .Execute(b => b.Property(p => p.ClaimType)
                .HasColumnName("TipoAtributo")
                .HasComment("Obtiene o establece el tipo de atributo"))
            .Execute(b => b.Property(p => p.ClaimValue)
                .HasColumnName("ValorAtributo")
                .HasComment("Obtiene o establece el valor para el atributo"))
            .Execute(b => b.Property(p => p.Id)
                .HasColumnName("AtributoRolId")
                .HasComment(""))
            .Execute(b => b.Property(p => p.RoleId)
                .HasColumnName("RolId")
                .HasComment("Obtiene o establece la llave primaria del rol asociado con este atributo"));

        modelBuilder.Entity<PATUser>()
            .ToTable("ABC_Usuario")
            .Execute(b => b.Property(p => p.UserName)
                .HasColumnName("NombreUsuario")
                .HasComment("Obtiene o establece el nombre de usuario"))
            .Execute(b => b.Property(p => p.NombrePila)
                .HasColumnName("NombrePila")
                .HasComment("Nombre de pila del usaurio de la aplicación"))
            .Execute(b => b.Property(p => p.Id)
                .HasColumnName("UsuarioId")
                .HasComment("Obtiene o establece el nombre de usuario"))
            .Execute(b => b.Property(p => p.TwoFactorEnabled)
                .HasColumnName("HabilitardosFactores")
                .HasComment("Obtiene o establece una bandera indicadora para habilitar la autenticación de dos factores para este usuario"))
            .Execute(b => b.Property(p => p.AccessFailedCount)
                .HasColumnName("NumeroIntentosFallido")
                .HasComment("Obtiene o establece el número de intentos fallidos en la autenticación para este usuario"))
            .Execute(b => b.Property(p => p.Email)
                .HasColumnName("Correo")
                .HasComment("Obtiene o establece el correo de un usuario"))
            .Execute(b => b.Property(p => p.EmailConfirmed)
                .HasColumnName("ConfirmacionCorreo")
                .HasComment("Obtiene o establece un indicador si el usuario ha confirmado el correo"))
            .Execute(b => b.Property(p => p.LockoutEnd)
                .HasColumnName("FechaFinalizaBloqueo")
                .HasComment("Obtiene o establece la fecha y la hora en UTC cuando finaliza el bloqueo de un usuario"))
            .Execute(b => b.Property(p => p.LockoutEnabled)
                .HasColumnName("Bloqueado")
                .HasComment("Obtiene o establece un indicador si el usuario fue bloqueado"))
            .Execute(b => b.Property(p => p.NormalizedEmail)
                .HasColumnName("CorreoNormalizado")
                .HasComment("Obtiene o establece el correo normalizado para este usuario"))
            .Execute(b => b.Property(p => p.NormalizedUserName)
                .HasColumnName("NombreUsuarioNormalizado")
                .HasComment("Obtiene o establece el Nombre normalizado para este usuario"))
            .Execute(b => b.Property(p => p.PasswordHash)
                .HasColumnName("HashContrasena")
                .HasComment("Obtiene o establece una representación hash de la contraseña de este usuario"))
            .Execute(b => b.Property(p => p.PhoneNumber)
                .HasColumnName("Telefono")
                .HasComment("Obtiene o establece el numero telefónico"))
            .Execute(b => b.Property(p => p.PhoneNumberConfirmed)
                .HasColumnName("ConfirmacionTelefono")
                .HasComment("Obtiene o establece un indicador si el teléfono fue confirmado"))
            .Execute(b => b.Property(p => p.SecurityStamp)
                .HasColumnName("SelloDeSeguridad")
                .HasComment("Un valor aleatorio que debe cambiar cada vez que cambian las credenciales de un usuario (contraseña a cambiado, inicio de sesión eliminado)"))
            .Execute(b => b.Property(p => p.ConcurrencyStamp)
                .HasColumnName("SelloConcurrente")
                .HasComment("Un valor aleatorio que debe cambiar cada vez que un usuario persiste en el sitio"));

        modelBuilder.Entity<IdentityUserClaim<string>>()
            .ToTable("ABC_AtributoUsuario")
              .Execute(b => b.Property(p => p.UserId)
                .HasColumnName("UsuarioId")
                .HasComment("Obtiene o establece la llave primaria asociado a este atributo"))
              .Execute(b => b.Property(p => p.ClaimType)
                .HasColumnName("TipoAtributo")
                .HasComment("Obtiene o establece el tipo de atributo"))
              .Execute(b => b.Property(p => p.ClaimValue)
                .HasColumnName("ValorAtributo")
                .HasComment("Obtiene o establce el valor del atributo"))
              .Execute(b => b.Property(p => p.Id)
                .HasColumnName("AtributoUsuarioId")
                .HasComment("Obtiene o establece el id para este atributo"));

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .ToTable("ABC_LoginUsuario")
            .Execute(b => b.Property(p => p.LoginProvider)
                .HasColumnName("ProveedorInicioSesion")
                .HasComment("Obtiene o establece el proveedor del inicio de sesión(e.g facebook, google)"))
             .Execute(b => b.Property(p => p.UserId)
                .HasColumnName("UsuarioId")
                .HasComment("Obtiene o establece el id de usuario"))
              .Execute(b => b.Property(p => p.ProviderDisplayName)
                .HasColumnName("NombreProveedor")
                .HasComment("Obtiene o establece el nombre de la UI para el inicio de sesión"))
              .Execute(b => b.Property(p => p.ProviderKey)
                .HasColumnName("LlaveProveedor")
                .HasComment("Obtiene o establece la llave del proveedor de inicio de sesión"));

        modelBuilder.Entity<IdentityUserRole<string>>()
            .ToTable("ABC_RolUsuario")
             .Execute(b => b.Property(p => p.UserId)
                .HasColumnName("UsuarioId")
                .HasComment("Obtiene o establece el id del usuario"))
              .Execute(b => b.Property(p => p.RoleId)
                .HasColumnName("RolId")
                .HasComment("Obtiene o establce el id del rol"));

        modelBuilder.Entity<IdentityUserToken<string>>()
            .ToTable("ABC_TokenUsuario")
             .Execute(b => b.Property(p => p.Name)
                .HasColumnName("Nombre")
                .HasComment("Obtiene o establece el nombre del token"))
              .Execute(b => b.Property(p => p.LoginProvider)
                .HasColumnName("ProveedorInicioSesion")
                .HasComment("Obtiene o establce el proveedor del inicio de sesión"))
               .Execute(b => b.Property(p => p.UserId)
                .HasColumnName("UsuarioId")
                .HasComment("Obtiene o establece el id de usuario"))
                .Execute(b => b.Property(p => p.Value)
                .HasColumnName("Valor")
                .HasComment("Obtiene o establece el valor"));
    }
}
