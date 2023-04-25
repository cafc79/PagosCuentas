namespace PAT.Application.Models.UserManagement;

public readonly record struct ConfirmUserRequest(
    string JwtToken,
    string Email,
    string Token);
