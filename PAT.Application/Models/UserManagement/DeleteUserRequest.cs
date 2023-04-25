namespace PAT.Application.Models.UserManagement;

public readonly record struct DeleteUserRequest(
    string JwtToken,
    string Email);
