namespace PAT.Application.Models.UserManagement;

public readonly record struct ResetPasswordRequest(
    string JwtToken,
    string UserEmail,
    string Token,
    string Password);
