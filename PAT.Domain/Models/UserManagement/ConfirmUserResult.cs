namespace PAT.Domain.Models.UserManagement;

public readonly record struct ConfirmUserResult
    (
    bool Success,
    IEnumerable<string> Errors
    );
