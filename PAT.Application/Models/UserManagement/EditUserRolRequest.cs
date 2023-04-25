namespace PAT.Application.Models.UserManagement;

public readonly record struct EditUserRolRequest(
    string JwtToken,
    string Email,
    IEnumerable<string> Roles);
