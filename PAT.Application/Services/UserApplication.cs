using Microsoft.Extensions.Options;
using PAT.Application.Interfaces;
using PAT.Application.Models.UserManagement;
using PAT.Domain.Interfaces;
using PAT.Models.Configuration;
using PAT.Provider;
using System.Web;

namespace PAT.Application.Services;

public class UserApplication : IUserApplication
{
    private readonly EmailSettings _emailSettings;
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public UserApplication(
        IEmailService emailService,
        IUserService userService,
        IOptions<EmailSettings> emailSettings)
    {
        _userService = userService;
        _emailService = emailService;
        _emailSettings = emailSettings.Value;
    }
    public async Task<ChangePasswordResponse> ChangeUserPassword(
    ChangePasswordRequest request)
    {
        var result = await _userService.ChangeUserPassword(
            request.Email,
            request.CurrentPassword,
            request.NewPassword);
        return new(result.Success, result.Errors);
    }
 
    public async Task<ConfirmUserResponse> ConfirmUser(ConfirmUserRequest request)
    {
        var result = await _userService.ConfirmUser(
            request.Email,
            DecodeToken(request.Token));

        return new(result.Success, result.Errors);
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        var result = await _userService.CreateUser(
            request.Email,
            request.NombrePila,
            request.Roles);

        if (result.Success && result.ConfirmationToken is { } t && result.ResetPasswordToken is { } t2)
        {
            return await SendConfirmationEmail(
                request.Email,
                t,
                t2,
                result.Errors);
        }
        else
        {
            return new(false, false, result.Errors);
        }
    }

    public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request)
    {
        var result = await _userService.DeleteUser(request.Email);
        return new(result.Success, result.Errors);
    }

    public async Task<EditUserRolResponse> EditUserRoles(EditUserRolRequest request)
    {
        var result = await _userService.EditUserRoles(
            request.Email,
            request.Roles);
        return new(result.Success, result.Errors);
    }

    public async Task<LockUnlockUserResponse> LockUser(EmailDataRequest request)
    {
        var result = await _userService.LockUser(request.Email);
        return new(result.Success, result.Errors);
    }
   
    public async Task<ResetPasswordResponse> ResetPassword(
        ResetPasswordRequest request)
    {
        var result = await _userService.ResetPassword(
            request.UserEmail,
            DecodeToken(request.Token),
            request.Password);
        return new(result.Success, result.Errors);
    }

    public async Task<RevokeTokenResponse> RevokeTokenConfirmation(RevokeTokenRequest request)
    {
        var result = await _userService.RevokeTokenConfirmation(request.Email);
        return new(result.Success, result.Errors);
    }
    public async Task<RevokeTokenLogInResponse> RevokeTokenLogIn(RevokeTokenLogInRequest request)
    {
        var result = await _userService.RevokeTokenLogIn(request.Email, request.loginProvider, request.providerKey);
        return new(result.Success, result.Errors);
    }
    public async Task<ResetPasswordResponse> SendPasswordResetLink(
        EmailDataRequest request)
    {
        var result = await _userService.SendPasswordResetLink(request.Email);
        if (result.Success && result.Token is { } t)
            return await SendResetPasswordEmail(request.Email, t);
        else
            return new(false, result.Errors);
    }

    private async Task<CreateUserResponse> SendConfirmationEmail(
        string email,
        string accountConfirmationToken,
        string resetPasswordToken,
        IEnumerable<string> errors)
    {
        var emailData = _userService.CreateAccountConfirmationData(
            email,
            EncodeToken(accountConfirmationToken),
            EncodeToken(resetPasswordToken),
            _emailSettings.AccountConfirmationUrl);

        var sent = await _emailService.SendEmail(new()
        {
            EmailBody = emailData.HtmlContent,
            EmailSubject = "Verificación de cuenta",
            EmailToId = email,
            EmailToName = email
        });

        return new(true, sent.Sent, errors.Concat(sent.Errors));
    }

    private async Task<ResetPasswordResponse> SendResetPasswordEmail(
        string email,
        string token)
    {
        var emailData = _userService.CreateResetPasswordData(
            email,
            EncodeToken(token),
            _emailSettings.ResetPasswordUrl);

        var sent = await _emailService.SendEmail(new()
        {
            EmailBody = emailData.HtmlContent,
            EmailSubject = "Reseteo de Password",
            EmailToId = email,
            EmailToName = email
        });

        return new(sent.Sent, sent.Errors);
    }
    public async Task<LockUnlockUserResponse> UnlockUser(EmailDataRequest request)
    {
        var result = await _userService.UnlockUser(request.Email);
        return new(result.Success, result.Errors);
    }

    public async Task<IEnumerable<GetUserResponse>> GetAllUsers(GetUsersRequest request)
    {
        var result = await _userService.GetAllUsers();
        return result.Select(p => new GetUserResponse
        {
             UsuarioId = p.UsuarioId,
            Activo = p.Activo,
            Bloqueado = p.Bloqueado,
            EmailConfirmado = p.EmailConfirmado,
            Email = p.Email,
            NombrePila = p.NombrePila,
            Roles = p.Roles,
            Errors = p.Errors
        });

    }

    public async Task<EditUserResponse> EditUser(EditUserRequest request)
    {
        var result = await _userService.EditUser(
            request.Email, 
            request.emailNuevo,
            request.telefono,
            request.telefonoConfirmado,
            request.emailConfirmado,
            request.habilitarDosFactores,
            request.fechaFinalizaBloqueo??null, 
            request.bloqueado, 
            request.intentosFallidos,
            request.nombrePila);
        return new(result.Success, result.Errors);
    }
  
    private static string EncodeToken(string token)
        => HttpUtility.UrlEncode(token);

    private static string DecodeToken(string encodedToken)
        => HttpUtility.UrlDecode(encodedToken);

}
