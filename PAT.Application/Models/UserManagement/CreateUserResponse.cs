namespace PAT.Application.Models.UserManagement;

public readonly record struct CreateUserResponse(
    bool UserCreated,
    bool EmailSent,
    IEnumerable<string> Errors);
