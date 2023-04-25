using PAT.Domain.Models.UserManagement;

namespace PAT.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthenticateResult> Authenticate(string email, string password);
    Task<List<string>> GetUserRoles(string email);
    Task<string> GetNombrePila(string email);
    Task<string> GetUsuarioId(string email);
    Task SaveJwtToken(string email, string token, string remoteAddress, DateTime expirationDate);
    Task<bool> ValidateJwtTokenLogIn(string email, string token);
    Task<RevokeTokenLogInResult> RevokeJwtTokenLogIn(string email, string tokenLogIn);
}
