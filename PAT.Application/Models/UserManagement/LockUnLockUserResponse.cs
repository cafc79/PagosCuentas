namespace PAT.Application.Models.UserManagement;

public readonly record struct LockUnlockUserResponse(
    bool Success,
    IEnumerable<string> Errors);
