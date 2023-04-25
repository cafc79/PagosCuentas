namespace PAT.Application.Models.UserManagement;

public readonly record struct CreateUserRequest(
    string JwtToken,
    string Email,
    string NombrePila,
    IEnumerable<string> Roles);
