namespace PAT.Application.Models.UserManagement;

public readonly record struct ResetPasswordResponse(
    bool Success,
    IEnumerable<string> Errors);