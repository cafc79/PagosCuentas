using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PAT.Application.Interfaces;
using PAT.Application.Models.Authentication;
using PAT.Application.Models.UserManagement;
using PAT.Common.Extensions;
using PAT.Domain.Interfaces;
using PAT.Models.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PAT.Application.Services;

public class AuthApplication : IAuthApplication
{
    private readonly AuthSettings _settings;
    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthApplication(
        IOptions<AuthSettings> settings,
        IAuthService authService,
        IHttpContextAccessor contextAccessor)
    {
        _authService = authService;
        _settings = settings.Value;
        _contextAccessor = contextAccessor;
    }

    public async Task<AuthenticationResponse> Authenticate(
        AuthenticationRequest request)
    {
        var r = await _authService.Authenticate(request.Email, request.Password);
        return r.User switch
        {
            not null => await AuthenticateInternal(r.Result!, request.Email),
            _ => CreateFailedResponse(request.Email, false, false, true)
        };
    }

    private async Task<AuthenticationResponse> AuthenticateInternal(
        SignInResult r,
        string email)
        => r.Succeeded switch
        {
          true => await _authService.GetUserRoles(email)
                .FlatMap(ur => GenerateJwtToken(email, ur))
                .Map(t => CreateSuccessfulResponse(r, email, t.Token, _authService.GetUsuarioId(email).Result, _authService.GetNombrePila(email).Result, t.Roles)),
            _ => CreateFailedResponse(email, r.IsLockedOut, r.IsNotAllowed, false)
        };

    private async Task<(string Token, IEnumerable<string> Roles)> GenerateJwtToken(
        string email,
        List<string> roles)
    => await GenerateJwtTokenInternal(email, roles)
        .MapV(t => StoreJwtToken(email, t))
        .Map(t => (t, roles));

    private string GenerateJwtTokenInternal(
        string userEmail,
        List<string> userRoles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return GetTokenDescriptor(
                userEmail,
                Encoding.ASCII.GetBytes(_settings.SymetricKey))
            .MapV(td => td.Execute(userRoles, (td, ur)
                => ur.ForEach(r => td.Subject.AddClaim(new("Role", r)))))
            .MapV(td => tokenHandler.CreateToken(td))
            .MapV(t => tokenHandler.WriteToken(t));
    }

    private SecurityTokenDescriptor GetTokenDescriptor(
        string userEmail,
        byte[] key)
        => new()
        {
            Subject = new ClaimsIdentity(new[] { new Claim("Id", userEmail) }),
            Expires = GenerateExpirationDate(DateTime.UtcNow),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

    private async Task<string> StoreJwtToken(
        string email,
        string token)
    {
        var ip = GetRemoteIpAddress(_contextAccessor.HttpContext?.Request);
        var expirationDate = GenerateExpirationDate(DateTime.UtcNow);
        await _authService.SaveJwtToken(email, token, ip, expirationDate);
        return token;
    }

    private static AuthenticationResponse CreateSuccessfulResponse(
        SignInResult r,
        string email,
        string token,
        string UsuarioId,
        string NombrePila,
        IEnumerable<string> roles)
        => new(email, token, true, r.IsLockedOut, r.IsNotAllowed, false, UsuarioId, NombrePila, roles);

    private static AuthenticationResponse CreateFailedResponse(
        string email,
        bool isLockedOut,
        bool isNotAllowed,
        bool doesNotExist)
        => new(
            email,
            null,
            false,
            isLockedOut,
            isNotAllowed,
            doesNotExist,
            null,
            null,
            Enumerable.Empty<string>());
    public async Task<ValidateTokenUserResponse> ValidateJwtTokenLogIn(ValidateTokenUserRequest validateTokenUserRequest)
    {
        var result = await _authService.ValidateJwtTokenLogIn(validateTokenUserRequest.Email, validateTokenUserRequest.Token);
        return new ValidateTokenUserResponse { IsTokenValid=result };

    }
    public async Task<RevokeTokenLogInResponse> RevokeJwtTokenLogIn(RevokeTokenLogInRequest request)
    {
        var result = await _authService.RevokeJwtTokenLogIn(request.Email,request.TokenLogIn);
        return new RevokeTokenLogInResponse {  Success=result.Success, Errors=result.Errors };
    }
    private static string GetRemoteIpAddress(HttpRequest? request)
        => request?.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "";

    private DateTime GenerateExpirationDate(DateTime date)
        => date.Add(TimeSpan.FromHours(_settings.JwtTokenExpiration));
}
