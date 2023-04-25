namespace PAT.Domain.Models.UserManagement;

public readonly record struct GetUserRolesResult(
    string E,
    IEnumerable<string> Roles,
    IEnumerable<string> Errors);