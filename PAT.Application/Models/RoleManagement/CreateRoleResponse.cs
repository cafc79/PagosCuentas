namespace PAT.Application.Models.RoleManagement;

public readonly record struct CreateRoleResponse(
    bool Success,
    IEnumerable<string> Errors);

