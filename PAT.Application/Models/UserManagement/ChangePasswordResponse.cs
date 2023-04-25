namespace PAT.Application.Models.UserManagement;

public readonly record struct ChangePasswordResponse(
    bool Success,
    IEnumerable<string> Errors);

