using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PAT.Common.Extensions;
using PAT.Common.Interfaces;
using PAT.Domain.Interfaces;
using PAT.Domain.Models.UserManagement;
using PAT.Models.Identity;
using System.Text;

namespace PAT.Domain.Services;

public class UserService : IUserService
{
    private readonly ILogger<AuthService> _logger;
    private readonly UserManager<PATUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;


    public UserService(
        ILogger<AuthService> logger,
        UserManager<PATUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _logger = logger;
        _roleManager = roleManager;
    }

    public async Task<ChangePasswordResult> ChangeUserPassword(
      string email,
      string currentPassword,
      string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var result = await _userManager.ChangePasswordAsync(
            user,
            currentPassword,
            newPassword);
        _logger.LogInformation(
            "ChangePassword complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            result.Errors.GetErrors().ToString(","));
        return new(result.Succeeded, result.Errors.GetErrors());
    }
    public async Task<ConfirmUserResult> ConfirmUser(
     string email,
     string decodedToken)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
        _logger.LogInformation(
            "ConfirmEmal complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            result.Errors.GetErrors().ToString(","));

        _ = await _userManager.SetLockoutEnabledAsync(user, false);
        return new(result.Succeeded, result.Errors.GetErrors());
    }
    public AccountConfirmationData CreateAccountConfirmationData(
       string email,
       string encodedAccountConfirmationToken,
       string encodedResetPasswordToken,
       string accountConfirmationUrl)
    {
        var template = new StringBuilder();
        template.AppendLine("<img src=\"data:image/png;base64,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\" />");
        template.AppendLine("<p><strong>Verificaci&oacute;n de cuenta </strong></p>");
        template.AppendLine("<p>Se gener&oacute; la cuenta para {0}</p>");
        template.AppendLine("<p><strong>Si realizaste esta solicitud</strong>, <strong><span style = \"color: #00ccff;\"><a href='{1}?UserId={0}&Code={2}&CodeReset={3}'>usa esta liga para habilitar su cuenta.</a></span></strong></p>");
        template.AppendLine("<p>Si no realizaste esta solicitud, ignora y elimina este correo.</p>");

        var d = new AccountConfirmationData()
        {
            HtmlContent = string.Format(template.ToString(),
                email,
                accountConfirmationUrl,
                encodedAccountConfirmationToken,
                encodedResetPasswordToken)
        };
        return d;
    }

    public ResetPasswordData CreateResetPasswordData(
        string email,
        string encodedToken,
        string resetPasswordUrl)
    {
        var template = new StringBuilder();

        template.AppendLine("<img src=\"data:image/png;base64,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\" />");
        template.AppendLine("<p><strong>Restablecimiento de contrase&ntilde;a</strong></p>");
        template.AppendLine("<p>Enviaste una solicitud para cambiar tu contrase&ntilde;a para la cuenta {0}</p>");
        template.AppendLine("<p><strong>Si realizaste esta solicitud</strong>, <strong><span style = \"color: #00ccff;\"><a href='{1}?UserId={0}&Code={2}'>usa esta liga para continuar.</a></span></strong></p>");
        template.AppendLine("<p>Si no pediste este cambio de contrase&ntilde;a, entonces aseg&uacute;rate que a&uacute;n puedes ingresar a tu cuenta. En caso de que no puedas contacta al administrador.</p>");

        return new()
        {
            HtmlContent = string.Format(template.ToString(),
                email,
                resetPasswordUrl,
                encodedToken)
        };
    }

    public async Task<CreateUserResult> CreateUser(
        string email,
        string name,
        IEnumerable<string> roles)
    {
        var password = string.Format("Z9{0}$z", Guid.NewGuid().ToString()[..5].ToLower());
        var newUser = new PATUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            NombrePila = name
        };
        foreach (var rol in roles)
            if (await _roleManager.FindByNameAsync(rol) == null)
                return new(
           false,
           newUser.Id,
           string.Empty,
           string.Empty,
           new List<string> { String.Format("Rol {0} no encontrado", rol) });

        var result = await _userManager.CreateAsync(
            newUser,
            password);

        if (result.Succeeded)
        {
            _logger.LogInformation(
                "UserCreate complete for {Email}. Success: {Success},  Errors: {Errors}",
                email,
                result.Succeeded,
                result.Errors.GetErrors());

            var rolesResult = await _userManager.AddToRolesAsync(newUser, roles);
            _logger.LogInformation(
                "AddToRolesUser complete for {Email}. Success: {Success},  Errors: {Errors}",
                email,
                rolesResult.Succeeded,
               string.Join(",", result.Errors.GetErrors()));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            _logger.LogInformation(
                "GenerateEmailConfirmationToken complete for {Email}. Success: {Success}",
                email,
                string.IsNullOrEmpty(token));

            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(newUser);

            _logger.LogInformation(
                "GeneratePasswordResetToken complete for {Email}. Success: {Success}",
                email,
                string.IsNullOrEmpty(token));

            return new(
                true,
                newUser.Id,
                token,
                resetPasswordToken,
                rolesResult.Errors.GetErrors());
        }
        else
        {
            _logger.LogInformation(
                "UserCreate complete for {Email}. Success: {Success},  Errors: {Errors}",
                email,
                result.Succeeded,
                result.Errors.GetErrors().ToString(","));

            return new(false, string.Empty, string.Empty, null, result.Errors.GetErrors());
        }
    }

    public async Task<DeleteUserResult> DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(
                false,
                new[] { "Usuario no encontrado" });

        user.Activo = false;
        var deleteResult = await _userManager.UpdateAsync(user);
        var removePasswordResult = await _userManager.RemovePasswordAsync(user);

        _logger.LogInformation(
           "DeleteUser complete for {Email}. Success: {Success},  Errors: {Errors}",
           email,
           deleteResult.Succeeded,
           deleteResult.Errors.GetErrors().ToString(","));
        return new(
            deleteResult.Succeeded,
            deleteResult.Errors.GetErrors().Concat(
                removePasswordResult.Errors.GetErrors()));
    }
    public async Task<EditUserRolResult> EditUserRoles(
         string email,
         IEnumerable<string> roles)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var userroles = await _userManager.GetRolesAsync(user);
        List<string> rolesu = userroles.ToList();

        foreach (var rol in rolesu)
            await _userManager.RemoveFromRoleAsync(user, rol);

        var result = await _userManager.AddToRolesAsync(
            user,
            roles);

        _logger.LogInformation(
            "AddToRoles complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            string.Join(",", result.Errors.GetErrors()));
        return new(result.Succeeded, result.Errors.GetErrors());
    }
    public async Task<IEnumerable<GetUserResult>> GetAllUsers()
    {
        var results = new List<GetUserResult>();
        var users = _userManager.Users.ToList();
        foreach (var u in users)
        {
            var bloqueado =  u.LockoutEnabled ;
            results.Add(new GetUserResult
            {
                Activo = u.Activo,
                Bloqueado = bloqueado,
                EmailConfirmado = u.EmailConfirmed,
                Email = u.Email,
                NombrePila = u.NombrePila,
                Errors = new List<string>(),
                Roles = await _userManager.GetRolesAsync(u),
                UsuarioId=u.Id
            });
        }
        return results;
    }

    public async Task<LockUnlockUserResult> LockUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var result = await _userManager.SetLockoutEnabledAsync(user, true);
        _logger.LogInformation(
            "SetLockoutEnabled complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            result.Errors.GetErrors().ToString(","));
        return new(result.Succeeded, result.Errors.GetErrors());
    }

    public async Task<LockUnlockUserResult> UnlockUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var result = await _userManager.SetLockoutEnabledAsync(user, false);
        _logger.LogInformation(
            "SetLockoutEnabled complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            result.Errors.GetErrors().ToString(","));
        return new(result.Succeeded, result.Errors.GetErrors());
    }

    public async Task<ResetPasswordResult> ResetPassword(
        string email,
        string token,
        string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(
                false,
                string.Empty,
                string.Empty,
                new List<string> { "Usuario no encontrado" });

        var result = await _userManager.ResetPasswordAsync(
            user,
           token,
            password);
        _logger.LogInformation(
            "ResetPassword complete for {Email}. Success: {Success},  Errors: {Errors}",
            email,
            result.Succeeded,
            result.Errors.GetErrors().ToString(","));
        return new(
            result.Succeeded,
            user.Id,
            string.Empty,
            result.Errors.GetErrors());
    }
    public async Task<RevokeTokenResult> RevokeTokenConfirmation(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });
        var result = await _userManager.UpdateSecurityStampAsync(user);
        _logger.LogInformation(
          "Reboke Token complete for {Email}. Success: {Success},  Errors: {Errors}",
          email,
          result.Succeeded,
          string.Join("", result.Errors.GetErrors()));
        return new(result.Succeeded, result.Errors.GetErrors());
    }
    public async Task<RevokeTokenLogInResult> RevokeTokenLogIn(string email, string loginProvider, string providerKey)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new(false, new List<string> { "Usuario no encontrado" });

        var result = await _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
        _logger.LogInformation(
          "Reboke Token complete for {Email}. Success: {Success},  Errors: {Errors}",
          email,
          result.Succeeded,
          string.Join("", result.Errors.GetErrors()));
        return new(result.Succeeded, result.Errors.GetErrors());
    }
    public async Task<ResetPasswordResult> SendPasswordResetLink(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var emailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (user == null || !emailConfirmed)
            return new(
                false,
                string.Empty,
                string.Empty,
                new List<string> { "Usuario no encontrado" });

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        _logger.LogInformation(
            "GeneratePasswordResetToken complete for {Email}. Success: {Success}",
            email,
            string.IsNullOrEmpty(token));
        return new(
            true,
            user.Id,
            token,
            new List<string> { "Token creado para reestablecer contraseña" });
    }

    public async Task<EditUserResult> EditUser(string email, string emailNuevo,
        string telefono, bool telefonoConfirmado, bool emailConfirmado, bool habilitarDosFactores,
        DateTime? fechaFinalizaBloqueo, bool bloqueado,
        int intentosFallidos, string nombrePila)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            _logger.LogInformation("Usuario no encontrado {email}", email);
            return new(false, new List<string> { "Usuario no encontrado" });
        }
        else
        {
            if(!string.IsNullOrEmpty(nombrePila))
            user.NombrePila =nombrePila;
            if (!string.IsNullOrEmpty(emailNuevo))
            {
                user.UserName = emailNuevo;
                user.NormalizedUserName = emailNuevo.ToUpper();
                user.Email = emailNuevo;
                user.NormalizedEmail = emailNuevo.ToUpper();
            }
            if (!string.IsNullOrEmpty(telefono))
                user.PhoneNumber = telefono;
     
            //user.EmailConfirmed = Convert.ToBoolean(emailConfirmado);
            //user.TwoFactorEnabled = Convert.ToBoolean(habilitarDosFactores);
            //user.LockoutEnd = fechaFinalizaBloqueo!=null? Convert.ToDateTime(fechaFinalizaBloqueo):null;
            //user.LockoutEnabled = Convert.ToBoolean(bloqueado);
            //user.PhoneNumberConfirmed = Convert.ToBoolean(telefonoConfirmado);
            user.AccessFailedCount = Convert.ToInt16(intentosFallidos);
            await _userManager.UpdateAsync(user);

            _logger.LogInformation("Se actualizaron datos {email}", email);
            return new(true, new List<string> { "" });
        }

    }

    
}