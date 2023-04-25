namespace PAT.Domain.Models.UserManagement;

public readonly record struct CreateUserResult
    (
    bool Success, 
    string UserId,
    string? ConfirmationToken,
    string? ResetPasswordToken,
    IEnumerable<string> Errors
    );