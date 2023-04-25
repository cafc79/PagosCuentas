namespace PAT.Domain.Models.UserManagement;

public readonly record struct DeleteUserResult(
    bool Success,
    IEnumerable<string> Errors);