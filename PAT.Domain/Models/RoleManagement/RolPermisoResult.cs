namespace PAT.Domain.Models.RoleManagement
{
    public readonly record struct RolPermisoResult
    (
        string RoleId,
         string RolName,
         int PermissionId,
         string PermissionName,
         bool Status
        );
}
