namespace PAT.Application.Models.UserManagement;

public readonly record struct DeleteUserResponse(
    bool Success, 
    IEnumerable<string> Errors);
