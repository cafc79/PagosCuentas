namespace PAT.Application.Models.UserManagement;

public readonly record struct ConfirmUserResponse(
    bool Success, 
    IEnumerable<string> Errors);
