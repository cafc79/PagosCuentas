namespace PAT.Domain.Models.RoleManagement;

public readonly record struct CreateRoleResult(
    bool Success,
    IEnumerable<string> Errors);

