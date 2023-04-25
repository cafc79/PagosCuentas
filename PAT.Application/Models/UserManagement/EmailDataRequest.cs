namespace PAT.Application.Models.UserManagement;

public readonly record struct EmailDataRequest(
    string JwtToken,
    string Email);