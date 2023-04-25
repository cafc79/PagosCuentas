namespace PAT.Domain.Models.RoleManagement;

public readonly record struct RoleResult(
    string RoleId,
    string RoleName,
   string NormalizedName
    );

