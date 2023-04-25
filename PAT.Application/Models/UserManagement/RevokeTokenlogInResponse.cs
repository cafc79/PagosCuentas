namespace PAT.Application.Models.UserManagement;

public readonly  record struct RevokeTokenLogInResponse
    (bool Success,
    IEnumerable<string> Errors);

