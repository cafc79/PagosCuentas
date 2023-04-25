namespace PAT.Application.Models.UserManagement;

public readonly  record struct RevokeTokenResponse
    (bool Success,
    IEnumerable<string> Errors);

