namespace PAT.Application.Models.RoleManagement;

public readonly record struct GetRolesResponse(
    string RoleId,
    string RoleName,
     string NormalizedName
    );