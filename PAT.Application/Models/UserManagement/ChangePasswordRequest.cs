namespace PAT.Application.Models.UserManagement;

public readonly record struct ChangePasswordRequest(
    string JwtToken,
    string Email,
    string CurrentPassword,
    string NewPassword);